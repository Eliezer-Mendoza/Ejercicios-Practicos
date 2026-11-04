using static System.Net.Mime.MediaTypeNames;

namespace PS6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            button1 = new Button();
            lblResultado = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(268, 9);
            label1.Name = "label1";
            label1.Size = new Size(204, 20);
            label1.TabIndex = 0;
            label1.Text = "Sistema de Gestion de Ventas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 45);
            label2.Name = "label2";
            label2.Size = new Size(302, 20);
            label2.TabIndex = 1;
            label2.Text = "Ingrese el subtotal de la venta | C$1 - 50,000";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 119);
            label3.Name = "label3";
            label3.Size = new Size(190, 20);
            label3.TabIndex = 2;
            label3.Text = "Seleccione el tipo de pago:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(57, 226);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(117, 24);
            radioButton1.TabIndex = 3;
            radioButton1.TabStop = true;
            radioButton1.Text = "Transferencia";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(57, 164);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(83, 24);
            radioButton2.TabIndex = 4;
            radioButton2.TabStop = true;
            radioButton2.Text = "Efectivo";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(57, 194);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(74, 24);
            radioButton3.TabIndex = 5;
            radioButton3.TabStop = true;
            radioButton3.Text = "Tarjeta";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(57, 256);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(139, 24);
            radioButton4.TabIndex = 6;
            radioButton4.TabStop = true;
            radioButton4.Text = "Retiro sin tarjeta";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(57, 306);
            button1.Name = "button1";
            button1.Size = new Size(133, 58);
            button1.TabIndex = 7;
            button1.Text = "Calcular Pago";
            button1.UseVisualStyleBackColor = true;
            // 
            // lblResultado
            // 
            lblResultado.BorderStyle = BorderStyle.FixedSingle;
            lblResultado.Location = new Point(404, 54);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(350, 310);
            lblResultado.TabIndex = 8;
            lblResultado.Text = "Resultados del Cálculo:\r\n\r\nSubtotal: C$ 0.00\r\n";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(57, 79);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(302, 27);
            textBox1.TabIndex = 9;
          
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(lblResultado);
            Controls.Add(button1);
            Controls.Add(radioButton4);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }


        private Label label1;
        private Label label2;
        private Label label3;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private Button button1;
        private Label lblResultado;
        private TextBox textBox1;
    }
}
