using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace EquipoControlador_Proyecto
{
    public partial class Opciones : Form
    {
        private TcpClient client;
        private StreamWriter writer;
        private StreamReader reader;
        private CapturaPantalla capturaPantallaForm;

        public Opciones(TcpClient connectedClient)
        {
            InitializeComponent();
            client = connectedClient;
            NetworkStream stream = client.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
            StartListeningForResponses(); // Comenzamos a escuchar respuestas del servidor
            EnableAllActionButtons();
            capturaPantallaForm = new CapturaPantalla();
        }
        private async Task StartListeningForResponses()
        {
            try
            {
                while (client.Connected)
                {
                    var response = await reader.ReadLineAsync();
                    if (response != null)
                    {
                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show(response);
                        }));
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error en la operación del flujo: " + ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
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
            capturaPantallaForm?.Close();
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
            EnviarComandoAlServidor("GET_TIME_DATE");
        }
        private void Procesos_ejecucion_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("GET_TOTAL_PROCESS");
        }
        //private async void Captura_Pantalla_Click_1(object sender, EventArgs e)
        //{
        //    EnviarComandoAlServidor("TAKE_SCREENSHOT");
        //    await ReceiveAndDisplayScreenshot();
        //}
        private  void Captura_Pantalla_Click_1(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("TAKE_SCREENSHOT");
        }

        private void Enviar_mensaje_Click(object sender, EventArgs e)
        {
            Mensaje formularioMensaje = new Mensaje();
            formularioMensaje.setTextLabel("Ingrese el mensaje que desea enviar al computador remoto");
            formularioMensaje.ShowDialog(); // Esto hará que el formulario de mensaje sea modal
            string mensaje = formularioMensaje.getMensajeBox();
            if (!string.IsNullOrEmpty(mensaje))
            {
                EnviarComandoAlServidor($"SEND_MESSAGE {mensaje}");
            }
        }

        private void Subir_volumen_Click_1(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("INCREASE_VOLUMEN");
        }

        private void Bajar_volumen_Click_1(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("DECREASE_VOLUMEN");
        }

        private void Silenciar_sonido_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("MUTE");
        }

        private void Apagar_equipo_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("TURN_OFF");
            Application.Exit();
        }

        private void Reiniciar_equipo_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("RESET");
            Application.Exit();
        }
        private void Cerrar_sesion_Windows_Click(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("CLOSE_SESION");
            Application.Exit();
        }
        private void Finalizar_Procesos_Click(object sender, EventArgs e)
        {
            Mensaje formularioMensaje = new Mensaje();
            formularioMensaje.setTextLabel("Ingrese el ID del proceso a finalizar");
            formularioMensaje.ShowDialog();
            string idProcesoTexto = formularioMensaje.getMensajeBox();
            if (int.TryParse(idProcesoTexto, out int idProceso))
            {
                FinalizarProcesoPorID(idProceso);
            }
            else if (string.IsNullOrWhiteSpace(formularioMensaje.getMensajeBox()))
            {
                // simplemente no hace nada
            }
            else
            {
                MessageBox.Show("ID de proceso no válido.");
            }
        }

        private void Desconectar_Click_1(object sender, EventArgs e)
        {
            EnviarComandoAlServidor("DISCONNECT");
            Application.Exit();
        }
        private void FinalizarProcesoPorID(int processID)
        {
            EnviarComandoAlServidor($"KILL_PROCESS {processID}");
        }
        //private async Task ReceiveAndDisplayScreenshot()
        //{
        //    try
        //    {
        //        if (client != null && client.Connected)
        //        {
        //            // Lee el nombre del archivo primero
        //            byte[] fileNameLengthBytes = new byte[sizeof(int)];
        //            await reader.BaseStream.ReadAsync(fileNameLengthBytes, 0, fileNameLengthBytes.Length);
        //            int fileNameLength = BitConverter.ToInt32(fileNameLengthBytes, 0);

        //            byte[] fileNameBytes = new byte[fileNameLength];
        //            await reader.BaseStream.ReadAsync(fileNameBytes, 0, fileNameBytes.Length);
        //            string fileName = Encoding.UTF8.GetString(fileNameBytes);

        //            // Lee los datos de la imagen
        //            using (MemoryStream memoryStream = new MemoryStream())
        //            {
        //                byte[] buffer = new byte[1024];
        //                int bytesRead;

        //                while ((bytesRead = await reader.BaseStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        //                {
        //                    memoryStream.Write(buffer, 0, bytesRead);
        //                }

        //                // Reinicia el MemoryStream al principio
        //                memoryStream.Seek(0, SeekOrigin.Begin);

        //                // Muestra la captura de pantalla en el formulario
        //                ShowScreenshotInForm(memoryStream);
        //            }
        //        }
        //    }
        //    catch (OutOfMemoryException ex)
        //    {
        //        MessageBox.Show($"Error de memoria al recibir y mostrar la captura de pantalla: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error al recibir y mostrar la captura de pantalla: {ex.Message}");
        //    }
        //}

        //private void ShowScreenshotInForm(MemoryStream memoryStream)
        //{
        //    try
        //    {
        //        using (Image screenshot = Image.FromStream(memoryStream))
        //        {
        //            capturaPantallaForm.setScreenshot(screenshot);

        //            if (!capturaPantallaForm.Visible)
        //            {
        //                capturaPantallaForm.Show();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error al mostrar la captura de pantalla: {ex.Message}");
        //    }
        //}
        //public void CloseForm()
        //{
        //    if (capturaPantallaForm.GetImage() != null)
        //    {
        //        capturaPantallaForm.GetImage().Dispose();
        //    }
        //    this.Close();
        //}

    }
}
