namespace Boceto_Tzanalt_Coffee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Variable para controlar qué pantalla está abierta actualmente
        private Form formularioActivo = null;

        private void AbrirFormularioEnPanel(Form formularioHijo)
        {
            // Si ya hay un formulario abierto, lo cerramos
            if (formularioActivo != null)
                formularioActivo.Close();

            formularioActivo = formularioHijo;

            // Le quitamos las propiedades de ventana independiente
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            // Lo agregamos dentro de tu panel crema
            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Si hay una pantalla abierta, la cierra y deja ver la bienvenida original
            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo = null;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormAdmCuentas());
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
