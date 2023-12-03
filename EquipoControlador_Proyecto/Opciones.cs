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
    public partial class Opciones : Form
    {
        public Opciones()
        {
            InitializeComponent();
        }

        private void Desconectar_Click(object sender, EventArgs e)
        {

        }

        private void Resolucion_pantalla_Click(object sender, EventArgs e)
        {

        }

        private void Bajar_volumen_Click(object sender, EventArgs e)
        {

        }

        private void Nombre_SO_Click(object sender, EventArgs e)
        {
            String mensaje = Environment.OSVersion.VersionString;
            MessageBox.Show(mensaje, "Nombre Sistema Operativo", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
    }
}
