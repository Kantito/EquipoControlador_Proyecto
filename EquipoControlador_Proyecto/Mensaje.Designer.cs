namespace EquipoControlador_Proyecto
{
    partial class Mensaje
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
            label1 = new Label();
            txt_mensaje = new TextBox();
            btn_limpiar = new Button();
            btn_cancelar = new Button();
            btn_aceptar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 51);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 0;
            label1.Text = "Aca va la informacion";
            label1.Click += label1_Click;
            // 
            // txt_mensaje
            // 
            txt_mensaje.Location = new Point(35, 104);
            txt_mensaje.Multiline = true;
            txt_mensaje.Name = "txt_mensaje";
            txt_mensaje.Size = new Size(731, 124);
            txt_mensaje.TabIndex = 1;
            // 
            // btn_limpiar
            // 
            btn_limpiar.Location = new Point(333, 319);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(125, 54);
            btn_limpiar.TabIndex = 3;
            btn_limpiar.Text = "Limpiar";
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += btn_limpiar_Click;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Location = new Point(641, 319);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(125, 54);
            btn_cancelar.TabIndex = 4;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = true;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // btn_aceptar
            // 
            btn_aceptar.Location = new Point(35, 319);
            btn_aceptar.Name = "btn_aceptar";
            btn_aceptar.Size = new Size(125, 54);
            btn_aceptar.TabIndex = 5;
            btn_aceptar.Text = "Aceptar";
            btn_aceptar.UseVisualStyleBackColor = true;
            btn_aceptar.Click += btn_aceptar_Click;
            // 
            // Mensaje
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_aceptar);
            Controls.Add(btn_cancelar);
            Controls.Add(btn_limpiar);
            Controls.Add(txt_mensaje);
            Controls.Add(label1);
            Name = "Mensaje";
            Text = "Mensaje";
            Load += Mensaje_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_mensaje;
        private Button btn_limpiar;
        private Button btn_cancelar;
        private Button btn_aceptar;
    }
}