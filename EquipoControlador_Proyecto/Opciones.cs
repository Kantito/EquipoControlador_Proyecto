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
            ejecutarComando("powershell -c \"(Get-WmiObject -Namespace root\cimv2 -Class Win32_VideoController).CurrentHorizontalResolution, (Get-WmiObject -Namespace root\cimv2 -Class Win32_VideoController).CurrentVerticalResolution");
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

        private void Plataforma_SO_Click(object sender, EventArgs e)
        {
            String mensaje = Environment.OSVersion.Platform.ToString();
            MessageBox.Show(mensaje, "Plataforma del Sistema Operativo", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            
        }

        private void Version_SO_Click(object sender, EventArgs e)
        {
            String mensaje = Environment.OSVersion.Version.ToString();
            MessageBox.Show(mensaje, "Version del Sistema Operativo", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void Nombre_Equipo_Click(object sender, EventArgs e)
        {
            String mensaje = Environment.MachineName;
            MessageBox.Show(mensaje, "Nombre del equipo", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void Info_Procesador(object sender, EventArgs e)
        {
            ejecutarComando("wmic cpu get caption, deviceid, name, numberofcores, maxclockspeed");
        }

        private void Total_RAM_Click(object sender, EventArgs e)
        {
            ejecutarComando("powershell -c \"Get-WmiObject Win32_PhysicalMemory | Measure-Object -Property Capacity -Sum | Select-Object @{Name='TotalGB';Expression={$_.Sum / 1GB}}");
        }

        private void Nombre_Usuario_Click(object sender, EventArgs e)
        {
            WindowsIdentity identidad = WindowsIdentity.GetCurrent();
            if (identidad != null)
            {
                MessageBox.Show(identidad.Name, "Nombre del usuario actual", MessageBoxButtons.OK,
           MessageBoxIcon.Information);
            }
        }

        private void ejecutarComando(string comando)
        {
            System.Diagnostics.ProcessStartInfo info = null;
            System.Diagnostics.Process proceso = null;

            info = new System.Diagnostics.ProcessStartInfo("cmd", "/c" + comando);
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;

            proceso = new System.Diagnostics.Process();
            proceso.StartInfo = info;
            proceso.Start();
        }
    }
}