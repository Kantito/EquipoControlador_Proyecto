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
            string direccionIP = tb_ip.Text;

            try
            {

                 
                using (TcpClient remoto = new TcpClient())
                {
                    remoto.Connect(direccionIP, 8888);
                    Console.WriteLine("Conexión establecida con el equipo remoto.");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar al equipo remoto: " + ex.Message);
            }


        }
    }
}