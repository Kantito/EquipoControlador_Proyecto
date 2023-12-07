namespace EquipoControlador_Proyecto
{
    partial class CapturaPantalla
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pict_Captura = new PictureBox();
            btn_Aceptar = new Button();
            ((System.ComponentModel.ISupportInitialize)pict_Captura).BeginInit();
            SuspendLayout();
            // 
            // pict_Captura
            // 
            pict_Captura.Location = new Point(1, 1);
            pict_Captura.Name = "pict_Captura";
            pict_Captura.Size = new Size(1321, 578);
            pict_Captura.TabIndex = 0;
            pict_Captura.TabStop = false;
            // 
            // btn_Aceptar
            // 
            btn_Aceptar.Location = new Point(580, 596);
            btn_Aceptar.Name = "btn_Aceptar";
            btn_Aceptar.Size = new Size(187, 92);
            btn_Aceptar.TabIndex = 1;
            btn_Aceptar.Text = "Aceptar";
            btn_Aceptar.UseVisualStyleBackColor = true;
            btn_Aceptar.Click += btn_Aceptar_Click;
            // 
            // CapturaPantalla
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1323, 700);
            Controls.Add(btn_Aceptar);
            Controls.Add(pict_Captura);
            Name = "CapturaPantalla";
            Text = "CapturaPantalla";
            ((System.ComponentModel.ISupportInitialize)pict_Captura).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pict_Captura;
        private Button btn_Aceptar;
    }
}