// Elaborar un programa consola en C# que fuese capaz de agregar, modificar, dar baja, buscar y listar 
// registros de empleados con los siguientes datos: IdEmpleado, Nombre completo, Fecha de Ingreso, cargo y salario.
//  Manejar todas las excepciones posibles e implementar la modularidad. Validar todo lo que este sujeto a validación. 
// Las fechas de ingresos no pueden ser menores a el 1 de enero de 1926 ni superieriores a la fecha actual que deberán de retomar
//  del sistema. El salario debe estar entre 7188 y 370000. El almacenamiento permanente debe hacerse en un archivo .dat o 
// .txt llamado Empleados. Los nombres de los empleados no pueden tener números ni caracteres especiales. Validar que en la fecha
//  los días no superen los 31, los meses no pueden superar los 12. Considerar que febrero puede tener entre 28 y 29 días 
// si el año es bisiesto.

// EL ID un numer0  3-4 es el ideal 
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

class Program
{
    struct Empleado
    {
        public string idEmpleado;
        public string nombreCompleto;
        public string fechaIngreso;
        public string cargo;
        public decimal salario;
    }

    static string archivoEmpleados = "Empleados.txt";

    static void Main(string[] args)
    {
        try
        {
            CrearArchivoSiNoExiste();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- GESTION DE EMPLEADOS ---");
                Console.WriteLine("1. Agregar empleado");
                Console.WriteLine("2. Modificar empleado");
                Console.WriteLine("3. Dar de baja a empleado");
                Console.WriteLine("4. Buscar empleado");
                Console.WriteLine("5. Listar empleados");
                Console.WriteLine("6. Salir");

                int opcion = SolicitarEntero("Seleccione una opcion: ", 1, 6);

                switch (opcion)
                {
                    case 1: 
                        AgregarEmpleado(); 
                        break;
                    case 2: 
                        ModificarEmpleado(); 
                        break;
                    case 3: 
                        DarBajaEmpleado(); 
                        break;
                    case 4: 
                        BuscarEmpleado(); 
                        break;
                    case 5: 
                        MenuListarEmpleados(); 
                        break;
                    case 6: 
                        continuar = false; 
                        break;
                    default: 
                        Console.WriteLine("Error: Opcion invalida."); 
                        break;
                }

                if (continuar)
                {
                    continuar = ConfirmarAccion("\n¿Desea realizar otra operacion en el sistema? (SI/NO): ");
                }
            }
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("Error critico: Memoria insuficiente en el sistema.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrio un error critico en el sistema: " + ex.Message);
        }
    }

    static void CrearArchivoSiNoExiste()
    {
        try
        {
            if (!File.Exists(archivoEmpleados))
            {
                using (FileStream fs = File.Create(archivoEmpleados)) { }
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Error de E/S al intentar inicializar el archivo.");
        }
    }

    static List<Empleado> CargarEmpleados()
    {
        List<Empleado> lista = new List<Empleado>();
        if (!File.Exists(archivoEmpleados)) return lista;

        try
        {
            string[] lineas = File.ReadAllLines(archivoEmpleados);
            foreach (string linea in lineas)
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    string[] partes = linea.Split('|');
                    if (partes.Length == 5)
                    {
                        if (decimal.TryParse(partes[4], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal salario))
                        {
                            lista.Add(new Empleado 
                            { 
                                idEmpleado = partes[0], 
                                nombreCompleto = partes[1], 
                                fechaIngreso = partes[2], 
                                cargo = partes[3], 
                                salario = salario 
                            });
                        }
                    }
                }
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Error: No se pudo leer el archivo debido a un bloqueo o fallo de acceso.");
        }
        catch (Exception)
        {
            Console.WriteLine("Error inesperado al procesar los registros del archivo.");
        }
        return lista;
    }

    static void GuardarEmpleados(List<Empleado> lista)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(archivoEmpleados, false))
            {
                foreach (var emp in lista)
                {
                    string salarioStr = emp.salario.ToString(CultureInfo.InvariantCulture);
                    sw.WriteLine($"{emp.idEmpleado}|{emp.nombreCompleto}|{emp.fechaIngreso}|{emp.cargo}|{salarioStr}");
                }
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Error: El archivo está abierto en otra aplicación o no hay permisos de escritura.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al guardar los datos: " + ex.Message);
        }
    }

    static void AgregarEmpleado()
    {
        bool repetir = true;
        while (repetir)
        {
            Console.WriteLine("\n--- AGREGAR EMPLEADO ---");
            List<Empleado> lista = CargarEmpleados();
            Empleado nuevo = new Empleado();

            while (true)
            {
                nuevo.idEmpleado = SolicitarEntero("Ingrese el Id del Empleado: ", 1, int.MaxValue).ToString();
                if (BuscarPosicionPorId(lista, nuevo.idEmpleado) == -1) break;
                Console.WriteLine("Error: Ya existe un empleado registrado con ese Id.");
            }

            nuevo.nombreCompleto = SolicitarTexto("Ingrese el Nombre completo: ");
            nuevo.fechaIngreso = SolicitarFechaIngreso();
            nuevo.cargo = SolicitarTexto("Ingrese el Cargo: ");
            nuevo.salario = SolicitarSalario();

            lista.Add(nuevo);
            GuardarEmpleados(lista);
            Console.WriteLine("Empleado agregado exitosamente.");

            repetir = ConfirmarAccion("\n¿Desea agregar otro empleado? (SI/NO): ");
        }
    }

    static void ModificarEmpleado()
    {
        List<Empleado> lista = CargarEmpleados();
        if (lista.Count == 0) 
        { 
            Console.WriteLine("\nNo hay empleados registrados en el sistema."); 
            return; 
        }

        bool repetir = true;
        while (repetir)
        {
            Console.WriteLine("\n--- MODIFICAR EMPLEADO ---");
            string idBuscado = SolicitarEntero("Ingrese el Id del empleado a modificar: ", 1, int.MaxValue).ToString();
            int pos = BuscarPosicionPorId(lista, idBuscado);

            if (pos == -1)
            {
                Console.WriteLine("No se encontro ningun empleado con ese Id.");
            }
            else
            {
                Console.WriteLine("\nDatos actuales del empleado:");
                MostrarEmpleado(lista[pos]);

                Console.WriteLine("\nIngrese los nuevos datos:");
                Empleado emp = lista[pos];
                emp.nombreCompleto = SolicitarTexto("Ingrese el nuevo Nombre completo: ");
                emp.fechaIngreso = SolicitarFechaIngreso();
                emp.cargo = SolicitarTexto("Ingrese el nuevo Cargo: ");
                emp.salario = SolicitarSalario();
                lista[pos] = emp;

                GuardarEmpleados(lista);
                Console.WriteLine("Registro modificado exitosamente.");
            }
            repetir = ConfirmarAccion("\n¿Desea modificar otro empleado? (SI/NO): ");
        }
    }

    static void DarBajaEmpleado()
    {
        bool repetir = true;
        while (repetir)
        {
            Console.WriteLine("\n--- DAR DE BAJA A EMPLEADO ---");
            List<Empleado> lista = CargarEmpleados();
            if (lista.Count == 0) 
            { 
                Console.WriteLine("No hay empleados registrados."); 
                return; 
            }

            string idBuscado = SolicitarEntero("Ingrese el Id del empleado a dar de baja: ", 1, int.MaxValue).ToString();
            int pos = BuscarPosicionPorId(lista, idBuscado);

            if (pos == -1)
            {
                Console.WriteLine("No se encontro ningun empleado con ese Id.");
            }
            else
            {
                MostrarEmpleado(lista[pos]);
                if (ConfirmarAccion("¿Seguro que desea dar de baja a este empleado? (SI/NO): "))
                {
                    lista.RemoveAt(pos);
                    GuardarEmpleados(lista);
                    Console.WriteLine("Empleado dado de baja correctamente.");
                }
                else
                {
                    Console.WriteLine("Operacion cancelada.");
                }
            }

            if (CargarEmpleados().Count == 0)
            {
                Console.WriteLine("Ya no quedan empleados registrados en el sistema.");
                repetir = false;
            }
            else
            {
                repetir = ConfirmarAccion("\n¿Desea dar de baja a otro empleado? (SI/NO): ");
            }
        }
    }

    static void BuscarEmpleado()
    {
        List<Empleado> lista = CargarEmpleados();
        if (lista.Count == 0) 
        { 
            Console.WriteLine("No hay empleados registrados."); 
            return; 
        }

        Console.WriteLine("1. Buscar por IdEmpleado (Busqueda Binaria)");
        Console.WriteLine("2. Buscar por Nombre (Busqueda Secuencial)");
        int opcionBusqueda = SolicitarEntero("Seleccione el metodo de busqueda: ", 1, 2);

        switch (opcionBusqueda)
        {
            case 1:
                string idBuscado = SolicitarEntero("Ingrese el Id a buscar: ", 1, int.MaxValue).ToString();
                OrdenarEmpleadosPorId(lista);
                int pos = BusquedaBinariaPorId(lista, idBuscado);

                if (pos != -1)
                {
                    Console.WriteLine("\nEmpleado encontrado:");
                    MostrarEmpleado(lista[pos]);
                }
                else
                {
                    Console.WriteLine("No existe ningun empleado con ese Id.");
                }
                break;

            case 2:
                string nombreBuscado = SolicitarTexto("Ingrese el nombre o parte del nombre a buscar: ");
                BusquedaSecuencialPorNombre(lista, nombreBuscado);
                break;

            default:
                Console.WriteLine("Opcion invalida.");
                break;
        }
    }

    static void MenuListarEmpleados()
    {
        List<Empleado> lista = CargarEmpleados();
        if (lista.Count == 0) 
        { 
            Console.WriteLine("No hay registros para mostrar."); 
            return; 
        }

        Console.WriteLine("1. Orden de registro");
        Console.WriteLine("2. Ordenados por Id (Ascendente)");
        int opcion = SolicitarEntero("Seleccione opcion: ", 1, 2);

        switch (opcion)
        {
            case 1:
                foreach (var emp in lista) 
                {
                    MostrarEmpleado(emp);
                }
                break;

            case 2:
                OrdenarEmpleadosPorId(lista);
                foreach (var emp in lista) 
                {
                    MostrarEmpleado(emp);
                }
                break;

            default:
                Console.WriteLine("Opcion invalida.");
                break;
        }
    }

    static int SolicitarEntero(string mensaje, int min, int max)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            if (entrada == null) { Console.WriteLine("Error: Entrada nula."); continue; }

            if (int.TryParse(entrada.Trim(), out valor) && valor >= min && valor <= max)
            {
                return valor;
            }
            Console.WriteLine($"Error: Ingrese un valor entero valido entre {min} y {max}.");
        }
    }

    static string SolicitarTexto(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            if (entrada == null) { Console.WriteLine("Error: Entrada nula."); continue; }

            string txt = entrada.Trim();
            if (!string.IsNullOrEmpty(txt))
            {
                if (txt.Length >= 2 && EsSoloLetras(txt))
                {
                    return LimpiarEspacios(txt);
                }
            }
            Console.WriteLine("Error: Solo letras, tildes y espacios (minimo 2 caracteres).");
        }
    }

    static decimal SolicitarSalario()
    {
        decimal salario;
        while (true)
        {
            Console.Write("Ingrese el Salario (7188 - 370000): ");
            string entrada = Console.ReadLine();
            if (entrada == null) { Console.WriteLine("Error: Entrada nula."); continue; }

            string limpio = entrada.Trim().Replace(',', '.');
            if (decimal.TryParse(limpio, NumberStyles.Any, CultureInfo.InvariantCulture, out salario))
            {
                if (salario >= 7188 && salario <= 370000)
                {
                    return salario;
                }
                Console.WriteLine("Error: El salario debe estar entre 7188 y 370000.");
            }
            else
            {
                Console.WriteLine("Error: Formato numerico invalido.");
            }
        }
    }

    static string SolicitarFechaIngreso()
    {
        DateTime hoy = DateTime.Now.Date;
        DateTime minFec = new DateTime(1926, 1, 1);

        while (true)
        {
            Console.WriteLine($"\n--- Fecha de Ingreso (01/01/1926 - {hoy:dd/MM/yyyy}) ---");
            int anio = SolicitarEntero("Año (YYYY): ", 1926, hoy.Year);
            int mes = SolicitarEntero("Mes (1 - 12): ", 1, 12);
            int dia = SolicitarEntero("Dia (1 - 31): ", 1, 31);

            int maxDias = (mes == 2) 
                ? (((anio % 4 == 0 && anio % 100 != 0) || (anio % 400 == 0)) ? 29 : 28) 
                : ((mes == 4 || mes == 6 || mes == 9 || mes == 11) ? 30 : 31);

            if (dia > maxDias)
            {
                Console.WriteLine($"Error: El mes {mes} del año {anio} solo tiene {maxDias} dias.");
                continue;
            }

            try
            {
                DateTime fecha = new DateTime(anio, mes, dia);
                if (fecha >= minFec && fecha <= hoy)
                {
                    return $"{dia:D2}/{mes:D2}/{anio:D4}";
                }
                Console.WriteLine("Error: La fecha esta fuera del rango permitido (1926 - Hoy).");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error: La fecha especificada no es válida en el calendario.");
            }
        }
    }

    static bool ConfirmarAccion(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            if (entrada == null) return false;

            string r = entrada.Trim().ToLower();
            if (r == "si" || r == "s") return true;
            if (r == "no" || r == "n") return false;
            Console.WriteLine("Error: Debe ingresar SI o NO.");
        }
    }

    static void MostrarEmpleado(Empleado emp)
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Id: {emp.idEmpleado} | Nombre: {emp.nombreCompleto}");
        Console.WriteLine($"Fecha Ingreso: {emp.fechaIngreso} | Cargo: {emp.cargo}");
        Console.WriteLine($"Salario: {emp.salario.ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine("--------------------------------------------------");
    }

    static int BuscarPosicionPorId(List<Empleado> lista, string id)
    {
        for (int i = 0; i < lista.Count; i++) 
        {
            if (lista[i].idEmpleado == id) 
            {
                return i;
            }
        }
        return -1;
    }

    static void OrdenarEmpleadosPorId(List<Empleado> lista)
    {
        for (int i = 0; i < lista.Count - 1; i++)
        {
            for (int j = 0; j < lista.Count - i - 1; j++)
            {
                if (Convert.ToInt32(lista[j].idEmpleado) > Convert.ToInt32(lista[j + 1].idEmpleado))
                {
                    Empleado tmp = lista[j]; 
                    lista[j] = lista[j + 1]; 
                    lista[j + 1] = tmp;
                }
            }
        }
    }

    static int BusquedaBinariaPorId(List<Empleado> lista, string idBuscado)
    {
        int ini = 0;
        int fin = lista.Count - 1;
        int objetivo = Convert.ToInt32(idBuscado);

        while (ini <= fin)
        {
            int med = ini + (fin - ini) / 2;
            int actual = Convert.ToInt32(lista[med].idEmpleado);

            if (actual == objetivo) return med;
            if (actual < objetivo) ini = med + 1; 
            else fin = med - 1;
        }
        return -1;
    }

    static void BusquedaSecuencialPorNombre(List<Empleado> lista, string textoBusqueda)
    {
        bool hallado = false;
        string textoMinusc = textoBusqueda.ToLower();

        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].nombreCompleto.ToLower().Contains(textoMinusc))
            {
                MostrarEmpleado(lista[i]);
                hallado = true;
            }
        }

        if (!hallado)
        {
            Console.WriteLine("No se encontraron coincidencias para el nombre ingresado.");
        }
    }

    static bool EsSoloLetras(string texto)
    {
        foreach (char c in texto)
        {
            bool esLetraBasica = (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
            bool esTilde = c == 'á' || c == 'é' || c == 'í' || c == 'ó' || c == 'ú' ||
                           c == 'Á' || c == 'É' || c == 'Í' || c == 'Ó' || c == 'Ú' ||
                           c == 'ü' || c == 'Ü' || c == 'ñ' || c == 'Ñ';
            bool esEspacio = (c == ' ');

            if (!esLetraBasica && !esTilde && !esEspacio)
            {
                return false;
            }
        }
        return true;
    }

    static string LimpiarEspacios(string texto)
    {
        string res = "";
        bool esp = false;
        foreach (char c in texto)
        {
            if (c == ' ') 
            { 
                if (!esp) 
                { 
                    res += c; 
                    esp = true; 
                } 
            }
            else 
            { 
                res += c; 
                esp = false; 
            }
        }
        return res;
    }
}