using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace EquipoControlador_Proyecto
{
    public partial class Opciones : Form
    {
        private TcpClient client;
        private StreamWriter writer;
        private StreamReader reader;

        public Opciones(TcpClient connectedClient)
        {
            InitializeComponent();
            client = connectedClient;
            NetworkStream stream = client.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);

            EnableAllActionButtons();
        }


        private void Resolucion_pantalla_Click(object sender, EventArgs e)
        {
            EnviarComandoAlSever("GetResolution");
        }

        private void Nombre_Usuario_Click(object sender, EventArgs e)
        {

            EnviarComandoAlSever("GetUserName");
        }

        private StreamReader GetReader()
        {
            return reader;
        }

        private void LeerRespuestaDelServidor(StreamReader reader)
        {
            if (client != null && client.Connected)
            {
                string response = reader.ReadLine(); // Leer la respuesta del servidor
                MessageBox.Show(response); // Mostrar la respuesta en un MessageBox
            }
            else
            {
                MessageBox.Show("No conectado al servidor.");
            }
        }




        private void EnviarComandoAlSever(string command)
        {
            if (client != null && client.Connected)
            {
                writer.WriteLine(command);
                writer.Flush();
            }
            else
            {
                MessageBox.Show("No conectado al servidor.");
            }
        }


        private void EnableAllActionButtons()
        {
            Resolucion_pantalla.Enabled = true;
            Nombre_Usuario.Enabled = true;
            Total_RAM.Enabled = true;
        }

        private void DisableAllActionButtons()
        {
            Resolucion_pantalla.Enabled = false;
            Nombre_Usuario.Enabled = false;
            Total_RAM.Enabled = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            writer?.Close();
            reader?.Close();
            client?.Close();
        }

        private void Nombre_SO_Click(object sender, EventArgs e)
        {
            EnviarComandoAlSever("GET_OS_NAME"); // Enviar el comando para obtener el nombre del SO
            LeerRespuestaDelServidor(GetReader());
        }

        private void Plataforma_SO_Click(object sender, EventArgs e)
        {
            EnviarComandoAlSever("GET_OS_PLATFORM");
            LeerRespuestaDelServidor(GetReader());
        }

        private void Version_SO_Click(object sender, EventArgs e)
        {
            EnviarComandoAlSever("GET_OS_VERSION");
            LeerRespuestaDelServidor(GetReader());
        }

        private void Nombre_Equipo_Click(object sender, EventArgs e)
        {
            EnviarComandoAlSever("GET_COMPUTER_NAME");
            LeerRespuestaDelServidor(GetReader());
        }

        private void Info_Procesador_Click(object sender, EventArgs e)
        {
            EnviarComandoAlSever("GET_PROCESSOR_INFO");
            LeerRespuestaDelServidor(GetReader());
        }

        private void Total_RAM_Click(object sender, EventArgs e)
        {
            EnviarComandoAlSever("GET_TOTAL_RAM");
            LeerRespuestaDelServidor(GetReader());
        }

        private void Lista_Unidades_Disco_Duro_Click(object sender, EventArgs e)
        {
            EnviarComandoAlSever("GET_LIST_DD");
            LeerRespuestaDelServidor(GetReader());
        }
    }
}
