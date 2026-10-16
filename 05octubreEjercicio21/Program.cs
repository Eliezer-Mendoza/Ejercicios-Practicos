using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

namespace AgendaTelefonica
{
    // =====================================================
    // CLASE CONTACTO
    // =====================================================

    class Contacto
    {
        public double Salario { get; set; }
        public string IDEmpleado { get; set; }
        public string FechaIngreso { get; set; }
        public string NumeroTelefono { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public string Cargo { get; set; }

        public Contacto(
            string numeroTelefono,
            string nombreCompleto,
            string direccion,
            string idEmpleado,
            string cargo,
            string fechaIngreso,
            double salario
            )
        {
            NumeroTelefono = numeroTelefono;
            NombreCompleto = nombreCompleto;
            Direccion = direccion;
            IDEmpleado = idEmpleado;
            Cargo = cargo;
            FechaIngreso = fechaIngreso;
            Salario = salario;
        }

        public override string ToString()
        {
            return string.Join(
                "|",
                NumeroTelefono,
                NombreCompleto,
                Direccion,
                IDEmpleado,
                Cargo,
                FechaIngreso,
                Salario.ToString()
            );
                   
    }

    // =====================================================
    // PROGRAMA PRINCIPAL
    // =====================================================

    class Program
    {
        static List<Contacto> contactos =
            new List<Contacto>();

        const string ARCHIVO =
            "agenda.txt";

        static void Main(string[] args)
        {
            int opcion;

            Console.Title =
                "Agenda Telefónica";

            // =============================================
            // CARGAR CONTACTOS DESDE EL ARCHIVO
            // =============================================

            CargarContactos();

            do
            {
                MostrarMenu();

                opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        AgregarContacto();
                        break;

                    case 2:
                        EliminarContacto();
                        break;

                    case 3:
                        ModificarContacto();
                        break;

                    case 4:
                        BuscarContacto();
                        break;

                    case 5:
                        MostrarContactos();
                        break;

                    case 6:
                        Console.WriteLine();
                        Console.WriteLine(
                            "Saliendo de la agenda..."
                        );
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine(
                            "ERROR: Opción no válida."
                        );
                        break;
                }

            } while (opcion != 6);

            Console.WriteLine();
            Console.WriteLine(
                "Presione una tecla para finalizar..."
            );

            Console.ReadKey();
        }

        // =====================================================
        // MOSTRAR MENÚ
        // =====================================================

        static void MostrarMenu()
        {
            Console.Clear();

            Console.WriteLine(
                "================================================="
            );

            Console.WriteLine(
                "              AGENDA TELEFÓNICA"
            );

            Console.WriteLine(
                "================================================="
            );

            Console.WriteLine(
                "1. Agregar contacto"
            );

            Console.WriteLine(
                "2. Eliminar contacto"
            );

            Console.WriteLine(
                "3. Modificar contacto"
            );

            Console.WriteLine(
                "4. Buscar contacto por número de teléfono"
            );

            Console.WriteLine(
                "5. Mostrar contactos"
            );

            Console.WriteLine(
                "6. Salir"
            );

            Console.WriteLine(
                "================================================="
            );
        }

        // =====================================================
        // LEER OPCIÓN
        // =====================================================

        static int LeerOpcion()
        {
            while (true)
            {
                Console.Write(
                    "Seleccione una opción: "
                );

                string entrada =
                    Console.ReadLine();

                try
                {
                    if (string.IsNullOrWhiteSpace(entrada))
                    {
                        throw new ArgumentException(
                            "La opción no puede estar vacía."
                        );
                    }

                    if (!int.TryParse(
                        entrada,
                        out int opcion))
                    {
                        throw new FormatException(
                            "Debe ingresar un número entero."
                        );
                    }

                    return opcion;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(
                        "ERROR: " + ex.Message
                    );
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(
                        "ERROR: " + ex.Message
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        "ERROR inesperado: "
                        + ex.Message
                    );
                }
            }
        }

        // =====================================================
        // AGREGAR CONTACTO
        // =====================================================

        static void AgregarContacto()
        {
            Console.Clear();

            Console.WriteLine(
                "================================================="
            );

            Console.WriteLine(
                "               AGREGAR CONTACTO"
            );

            Console.WriteLine(
                "================================================="
            );

            string telefono =
                LeerTelefono();

            // Verificar si el teléfono ya existe
            Contacto contactoExistente =
                contactos.FirstOrDefault(
                    c => c.NumeroTelefono == telefono
                );

            if (contactoExistente != null)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "ERROR: Ya existe un contacto "
                    + "con ese número."
                );

                Pausar();
                return;
            }

            string nombre =
                LeerTexto(
                    "Ingrese el nombre completo: "
                );

            string direccion =
                LeerTexto(
                    "Ingrese la dirección: "
                );

            string idEmpleado =
                LeerTexto(
                    "Ingrese el ID del empleado: "
                );

            string cargo =
                LeerTexto(
                    "Ingrese el cargo: "
                );

            string fechaIngreso =
                LeerFechaIngreso();

            double salario =
                VerificarSalario();

            Contacto nuevoContacto =
                new Contacto(
                    telefono,
                    nombre,
                    direccion,
                    idEmpleado,
                    cargo,
                    fechaIngreso,
                    salario
                );

            contactos.Add(
                nuevoContacto
            );

            GuardarContactos();

            Console.WriteLine();
            Console.WriteLine(
                "Contacto agregado correctamente."
            );

            Pausar();
        }

        // =====================================================
        // ELIMINAR CONTACTO
        // =====================================================

        static void EliminarContacto()
        {
            Console.Clear();

            Console.WriteLine(
                "================================================="
            );

            Console.WriteLine(
                "              ELIMINAR CONTACTO"
            );

            Console.WriteLine(
                "================================================="
            );

            string telefono =
                LeerTelefono();

            Contacto contacto =
                contactos.FirstOrDefault(
                    c => c.NumeroTelefono == telefono
                );

            if (contacto == null)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Contacto no encontrado."
                );

                Pausar();
                return;
            }

            Console.WriteLine();
            MostrarContacto(contacto);

            Console.WriteLine();
            Console.Write(
                "¿Está seguro de eliminarlo? (S/N): "
            );

            string respuesta =
                Console.ReadLine();

            if (
                respuesta.Equals(
                    "S",
                    StringComparison.OrdinalIgnoreCase))
            {
                contactos.Remove(contacto);

                GuardarContactos();

                Console.WriteLine();
                Console.WriteLine(
                    "Contacto eliminado correctamente."
                );
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Operación cancelada."
                );
            }

            Pausar();
        }

        // =====================================================
        // MODIFICAR CONTACTO
        // =====================================================

        static void ModificarContacto()
        {
            Console.Clear();

            Console.WriteLine(
                "================================================="
            );

            Console.WriteLine(
                "              MODIFICAR CONTACTO"
            );

            Console.WriteLine(
                "================================================="
            );

            string telefono =
                LeerTelefono();

            Contacto contacto =
                contactos.FirstOrDefault(
                    c => c.NumeroTelefono == telefono
                );

            if (contacto == null)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Contacto no encontrado."
                );

                Pausar();
                return;
            }

            Console.WriteLine();
            Console.WriteLine(
                "Datos actuales:"
            );

            MostrarContacto(contacto);

            Console.WriteLine();
            Console.WriteLine(
                "Ingrese los nuevos datos."
            );

            string nuevoCargo =
                LeerTexto(
                    "Nuevo cargo: "
                );

            double nuevoSalario =
                VerificarSalario();

            contacto.Cargo =
                nuevoCargo;

            contacto.Salario =
                nuevoSalario;

            GuardarContactos();

            Console.WriteLine();
            Console.WriteLine(
                "Contacto modificado correctamente."
            );

            Pausar();
        }

        // =====================================================
        // BUSCAR CONTACTO
        // =====================================================

        static void BuscarContacto()
        {
            Console.Clear();

            Console.WriteLine(
                "================================================="
            );

            Console.WriteLine(
                "       BUSCAR CONTACTO POR TELÉFONO"
            );

            Console.WriteLine(
                "================================================="
            );

            string telefono =
                LeerTelefono();

            Contacto contacto =
                contactos.FirstOrDefault(
                    c => c.NumeroTelefono == telefono
                );

            Console.WriteLine();

            if (contacto == null)
            {
                Console.WriteLine(
                    "Contacto no encontrado."
                );
            }
            else
            {
                Console.WriteLine(
                    "CONTACTO ENCONTRADO"
                );

                Console.WriteLine();

                MostrarContacto(contacto);
            }

            Pausar();
        }

        // =====================================================
        // MOSTRAR TODOS LOS CONTACTOS
        // =====================================================

        static void MostrarContactos()
        {
            Console.Clear();

            Console.WriteLine(
                "================================================="
            );

            Console.WriteLine(
                "             LISTA DE CONTACTOS"
            );

            Console.WriteLine(
                "================================================="
            );

            if (contactos.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "No existen contactos registrados."
                );

                Pausar();
                return;
            }

            Console.WriteLine();

            for (int i = 0; i < contactos.Count; i++)
            {
                Console.WriteLine(
                    "Contacto #" + (i + 1)
                );

                Console.WriteLine(
                    "---------------------------------------------"
                );

                MostrarContacto(
                    contactos[i]
                );

                Console.WriteLine(
                    "---------------------------------------------"
                );

                Console.WriteLine();
            }

            Console.WriteLine(
                "Total de contactos: "
                + contactos.Count
            );

            Pausar();
        }

        // =====================================================
        // MOSTRAR UN CONTACTO
        // =====================================================

        static void MostrarContacto(
            Contacto contacto)
        {
            Console.WriteLine(
                "Número de teléfono: "
                + contacto.NumeroTelefono
            );

            Console.WriteLine(
                "Nombre completo: "
                + contacto.NombreCompleto
            );

            Console.WriteLine(
                "Dirección: "
                + contacto.Direccion
            );

            Console.WriteLine(
                "ID del empleado: "
                + contacto.IDEmpleado
            );

            Console.WriteLine(
                "Cargo: "
                + contacto.Cargo
            );

            Console.WriteLine(
                "Fecha de ingreso: "
                + (string.IsNullOrEmpty(contacto.FechaIngreso)
                    ? "No especificada"
                    : contacto.FechaIngreso)
            );

            Console.WriteLine(
                "Salario: C$"
                + contacto.Salario
            );
        }
        static double VerificarSalario()
        {
            while (true)
            {
                Console.Write("Ingrese el salario (C$0 a C$100,000): ");
                string entrada = Console.ReadLine();
                double salario;

                if (double.TryParse(entrada, out salario)
                    && salario >= 0
                    && salario <= 100000)
                {
                    return salario;
                }

                Console.WriteLine(
                    "Entrada no válida. El salario debe estar entre C$0 y C$100,000."
                );
            }
        }

        static string LeerFechaIngreso()
        {
            while (true)
            {
                Console.Write("Ingrese la fecha de ingreso (dd/MM/aaaa): ");
                string entrada = Console.ReadLine();
                DateTime fecha;

                if (DateTime.TryParseExact(
                    entrada,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out fecha))
                {
                    return fecha.ToString(
                        "yyyy-MM-dd",
                        CultureInfo.InvariantCulture
                    );
                }

                Console.WriteLine(
                    "Fecha no válida. Use el formato dd/MM/aaaa."
                );
            }
        }

        // =====================================================
        // LEER TELÉFONO
        // =====================================================

        static string LeerTelefono()
        {
            while (true)
            {
                Console.Write(
                    "Ingrese el número de teléfono: "
                );

                string telefono =
                    Console.ReadLine();

                try
                {
                    if (string.IsNullOrWhiteSpace(telefono))
                    {
                        throw new ArgumentException(
                            "El teléfono no puede estar vacío."
                        );
                    }

                    if (!telefono.All(
                        char.IsDigit))
                    {
                        throw new FormatException(
                            "El teléfono debe contener "
                            + "solamente números."
                        );
                    }

                    if (telefono.Length < 8 ||
                        telefono.Length > 15)
                    {
                        throw new ArgumentOutOfRangeException(
                            "El teléfono debe tener "
                            + "entre 8 y 15 dígitos."
                        );
                    }

                    return telefono;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(
                        "ERROR: " + ex.Message
                    );
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(
                        "ERROR: " + ex.Message
                    );
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(
                        "ERROR: " + ex.Message
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        "ERROR inesperado: "
                        + ex.Message
                    );
                }
            }
        }

        // =====================================================
        // LEER TEXTO
        // =====================================================

        static string LeerTexto(
            string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);

                string texto =
                    Console.ReadLine();

                try
                {
                    if (string.IsNullOrWhiteSpace(texto))
                    {
                        throw new ArgumentException(
                            "El campo no puede estar vacío."
                        );
                    }

                    return texto.Trim();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(
                        "ERROR: " + ex.Message
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        "ERROR inesperado: "
                        + ex.Message
                    );
                }
            }
        }

        // =====================================================
        // GUARDAR CONTACTOS EN ARCHIVO
        // =====================================================

        static void GuardarContactos()
        {
            try
            {
                using (StreamWriter escritor =
                    new StreamWriter(
                        ARCHIVO,
                        false))
                {
                    foreach (
                        Contacto contacto
                        in contactos)
                    {
                        escritor.WriteLine(
                            contacto.ToString()
                        );
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "ERROR al guardar el archivo: "
                    + ex.Message
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "ERROR inesperado al guardar: "
                    + ex.Message
                );
            }
        }

        // =====================================================
        // CARGAR CONTACTOS DESDE ARCHIVO
        // =====================================================

        static void CargarContactos()
        {
            try
            {
                if (!File.Exists(ARCHIVO))
                {
                    return;
                }

                string[] lineas =
                    File.ReadAllLines(
                        ARCHIVO
                    );

                foreach (string linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea))
                    {
                        continue;
                    }

                    string[] datos =
                        linea.Split('|');

                    if (datos.Length == 3)
                    {
                        Contacto contacto =
                            new Contacto(
                                datos[0],
                                datos[1],
                                datos[2], 
                                string.Empty,
                                string.Empty,
                                string.Empty,
                                0
                            );

                        contactos.Add(
                            contacto
                        );
                    }
                    else if (datos.Length == 7
                        && double.TryParse(
                            datos[6],
                            NumberStyles.Number,
                            CultureInfo.InvariantCulture,
                            out double salario)
                        && salario >= 0
                        && salario <= 100000)
                    {
                        Contacto contacto =
                            new Contacto(
                                datos[0],
                                datos[1],
                                datos[2],
                                datos[3],
                                datos[4],
                                datos[5],
                                salario
                            );

                        contactos.Add(
                            contacto
                        );
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(
                    "ERROR al cargar el archivo: "
                    + ex.Message
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "ERROR inesperado al cargar: "
                    + ex.Message
                );
            }
        }

        // =====================================================
        // PAUSAR
        // =====================================================

        static void Pausar()
        {
            Console.WriteLine();
            Console.WriteLine(
                "Presione una tecla para continuar..."
            );

            Console.ReadKey();
        }
    }
}
}