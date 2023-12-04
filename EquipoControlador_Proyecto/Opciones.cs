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
            StartListeningForResponses(); // Comenzamos a escuchar respuestas del servidor
            EnableAllActionButtons();
        }
        private async Task StartListeningForResponses()
        {
            try
            {
                while (client.Connected)
                {
                    // Espera hasta que la línea sea leída antes de continuar.
                    var response = await reader.ReadLineAsync();
                    if (response != null)
                    {
                        // Asegúrate de que las actualizaciones de la interfaz de usuario ocurran en el hilo de la interfaz de usuario.
                        this.Invoke(new Action(() => {
                            MessageBox.Show(response);
                        }));
                    }
                }
            }
            catch (IOException ex)
            {
                // Captura y maneja la excepción de E/S.
                MessageBox.Show("Error en la operación del flujo: " + ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                // El flujo fue cerrado y se intentó una operación en él.
                MessageBox.Show("Flujo cerrado: " + ex.Message);
            }
        }

        private void ShowResponse(string response)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowResponse), new object[] { response });
            }
            else
            {
                MessageBox.Show(response, "Respuesta del servidor");
            }
        }

        private StreamReader GetReader()
        {
            return reader;
        }






        private void EnviarComandoAlServidor(string command)
        {
            if (client != null && client.Connected)
            {
                try
                {
                    writer.WriteLine(command);
                    writer.Flush();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error al enviar el comando: " + ex.Message);
                }
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
            EnviarComandoAlServidor("CLIENT_DISCONNECTING"); // Avisa al servidor que el cliente se desconectará
            base.OnFormClosing(e);
            writer?.Close();
            reader?.Close();
            client?.Close();
        }

        private void Nombre_SO_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("GET_OS_NAME");
        }

        private void Plataforma_SO_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("GET_OS_PLATFORM");
        }

        private void Version_SO_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("GET_OS_VERSION");
        }

        private void Nombre_Equipo_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("GET_COMPUTER_NAME");
        }

        private void Info_Procesador_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("GET_PROCESSOR_INFO");
        }

        private void Total_RAM_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("GET_TOTAL_RAM");
        }

        private void Lista_Unidades_Disco_Duro_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("GET_LIST_DD");
        }

        private void Resolucion_pantalla_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("GET_RESOLUTION");
        }

        private void Nombre_Usuario_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("GET_USER_NAME");
        }

        private void Zona_horaria_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("GET_TIME_ZONE");
        }

        private void Fecha_Hora_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("GET_DATE_TIME");
        }
        private void Subir_volumen_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("INCREASE_VOLUME");
        }

        private void Bajar_volumen_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("DECREASE_VOLUME");
        }

        private void Captura_Pantalla_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("TAKE_SCREENSHOT");
        }

        private void Desconectar_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("DISCONNECT");
            Close(); // Cierra la ventana de opciones después de desconectar
        }
    }
}
