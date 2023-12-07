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
    public partial class CapturaPantalla : Form
    {
        public CapturaPantalla()
        {
            InitializeComponent();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void setScreenshot(Image image)
        {
            pict_Captura.Image = image;
        }
        public Image GetImage()
        {
            return pict_Captura.Image;
        }
    }
    
}
