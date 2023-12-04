using System.Net;
using System.Net.Sockets;

namespace EquipoControlador_Proyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            try
            {

                TcpClient remoto = new TcpClient();
                remoto.Connect(tb_ip.Text, 8888);//Se utiliza localhost
                MessageBox.Show("Conexion establecida con el servidor en localhost.");

                Opciones opcionesForm = new Opciones(remoto);
                opcionesForm.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }

}