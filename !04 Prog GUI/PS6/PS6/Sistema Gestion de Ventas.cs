// Elaborar una aplicación GUI que sea capaz de gestionar el calculo de pago por ventas ya sea }
// con descuento o sin descuento. Solicitar el subtotal de la venta (1 - 50000).
// Consultar el tipo de pago que puede ser: Efectivo, Tarjeta, Transferencia o Retiro sin Tarjeta.
// Si el pago es en efectivo puede aplicar a descuento.
// En caso de que haya descuento el mismo será dependiendo del monto del subtotal.
// Subtotal entre 1 -2000 2% descuento. 2001-3500 3% de descuento. Mayores a 3501 5% de descuento.
// Validar todo lo que este sujeto a validacion.

using System;
using System.Globalization;
using System.Windows.Forms;

namespace PS6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += textBox1_KeyPress;
            button1.Click += button1_Click;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == '.' || e.KeyChar == ',') && (textBox1.Text.Contains(".") || textBox1.Text.Contains(",")))
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1 == null || lblResultado == null)
                {
                    throw new NullReferenceException("Uno de los controles de la interfaz no está inicializado.");
                }

                string textoSubtotal = textBox1.Text?.Trim().Replace(',', '.');

                if (string.IsNullOrEmpty(textoSubtotal))
                {
                    throw new ArgumentNullException(nameof(textBox1.Text), "El campo del subtotal no puede estar vacío.");
                }

                if (!decimal.TryParse(textoSubtotal, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal subtotal))
                {
                    throw new FormatException("El valor ingresado no tiene un formato numérico válido.");
                }

                if (subtotal < 1 || subtotal > 50000)
                {
                    throw new ArgumentOutOfRangeException(nameof(subtotal), "El subtotal debe estar estrictamente entre 1 y 50000.");
                }

                string metodoPago = "";
                bool aplicaDescuento = false;

                if (radioButton2 != null && radioButton2.Checked)
                {
                    metodoPago = "Efectivo";
                    aplicaDescuento = true;
                }
                else if (radioButton3 != null && radioButton3.Checked)
                {
                    metodoPago = "Tarjeta";
                }
                else if (radioButton1 != null && radioButton1.Checked)
                {
                    metodoPago = "Transferencia";
                }
                else if (radioButton4 != null && radioButton4.Checked)
                {
                    metodoPago = "Retiro sin Tarjeta";
                }
                else
                {
                    throw new InvalidOperationException("Debe seleccionar obligatoriamente un método de pago.");
                }

                decimal porcentajeDescuento = 0m;
                if (aplicaDescuento)
                {
                    if (subtotal >= 1 && subtotal <= 2000)
                    {
                        porcentajeDescuento = 0.02m;
                    }
                    else if (subtotal >= 2001 && subtotal <= 3500)
                    {
                        porcentajeDescuento = 0.03m;
                    }
                    else if (subtotal > 3500)
                    {
                        porcentajeDescuento = 0.05m;
                    }
                }

                decimal montoDescuento = checked(subtotal * porcentajeDescuento);
                decimal totalPagar = checked(subtotal - montoDescuento);

                lblResultado.Text = "Resultados del Cálculo:\n" +
                                    $"• Subtotal: C$ {subtotal.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                                    $"• Método de Pago: {metodoPago}\n" +
                                    $"• Descuento: {(porcentajeDescuento * 100)}% (C$ {montoDescuento.ToString("F2", CultureInfo.InvariantCulture)})\n" +
                                    $"• Total a Pagar: C$ {totalPagar.ToString("F2", CultureInfo.InvariantCulture)}";

                textBox1.Focus();
                textBox1.SelectAll();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Error de Datos Nulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1?.Focus();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (textBox1 != null)
                {
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("El valor numérico ingresado es demasiado grande o pequeño para ser procesado.", "Desbordamiento Numérico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (textBox1 != null)
                {
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Error de Rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (textBox1 != null)
                {
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Operación Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Error crítico de referencia: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}