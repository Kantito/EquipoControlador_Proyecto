using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipoControlador_Proyecto
{
    public partial class Mensaje : Form
    {

        public Mensaje()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_mensaje.Text = "";
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_mensaje.Text = "";
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public string getMensajeBox()
        {
            return txt_mensaje.Text;
        }
        public void setTextLabel(String mensaje)
        {
            label1.Text = mensaje;
        }

        private void Mensaje_Load(object sender, EventArgs e)
        {

        }
    }
}
