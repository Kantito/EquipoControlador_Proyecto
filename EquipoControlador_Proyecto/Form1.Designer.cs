namespace EquipoControlador_Proyecto
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_Controlador = new Label();
            lbl_ip = new Label();
            btn_conectar = new Button();
            tb_ip = new TextBox();
            SuspendLayout();
            // 
            // lbl_Controlador
            // 
            lbl_Controlador.AutoSize = true;
            lbl_Controlador.Location = new Point(150, 27);
            lbl_Controlador.Name = "lbl_Controlador";
            lbl_Controlador.Size = new Size(124, 17);
            lbl_Controlador.TabIndex = 0;
            lbl_Controlador.Text = "Equipo Controlador";
            // 
            // lbl_ip
            // 
            lbl_ip.AutoSize = true;
            lbl_ip.Location = new Point(95, 120);
            lbl_ip.Name = "lbl_ip";
            lbl_ip.Size = new Size(18, 17);
            lbl_ip.TabIndex = 1;
            lbl_ip.Text = "IP";
            // 
            // btn_conectar
            // 
            btn_conectar.Location = new Point(168, 187);
            btn_conectar.Name = "btn_conectar";
            btn_conectar.Size = new Size(75, 26);
            btn_conectar.TabIndex = 2;
            btn_conectar.Text = "Conectar";
            btn_conectar.UseVisualStyleBackColor = true;
            btn_conectar.Click += btn_conectar_Click;
            // 
            // tb_ip
            // 
            tb_ip.Location = new Point(161, 117);
            tb_ip.Name = "tb_ip";
            tb_ip.Size = new Size(100, 25);
            tb_ip.TabIndex = 3;
            tb_ip.TextChanged += tb_ip_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(450, 286);
            Controls.Add(tb_ip);
            Controls.Add(btn_conectar);
            Controls.Add(lbl_ip);
            Controls.Add(lbl_Controlador);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Controlador;
        private Label lbl_ip;
        private Button btn_conectar;
        private TextBox tb_ip;
    }
}