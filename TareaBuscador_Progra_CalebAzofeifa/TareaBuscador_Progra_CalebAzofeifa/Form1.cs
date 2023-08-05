using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TareaBuscador_Progra_CalebAzofeifa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void VNPrincipal_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.ShowBalloonTip(25);
            this.MostrarLogin();
        }

        private void MostrarLogin()
        {
            try
            {
                VentanaLog vnlog = new VentanaLog();
                vnlog.ShowDialog();
                vnlog.Dispose();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        private void EjecutarAplicacion(string AppName)
        {
            try
            {
                System.Diagnostics.Process.Start(AppName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void documentoDeTextoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.EjecutarAplicacion("Winword.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void documentoDeTextoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                this.EjecutarAplicacion("Winword.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.EjecutarAplicacion("Winword.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarPantallaProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarPantallaProductos()
        {
            try
            {
                VentanaBuscadorProductos frmProductos = new VentanaBuscadorProductos();
                frmProductos.ShowDialog();
                frmProductos.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MostrarPantallaUsuarios()
        {
            try
            {
                VentanaBuscadorUsuarios frmUsuarios = new VentanaBuscadorUsuarios();
                frmUsuarios.ShowDialog();
                frmUsuarios.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarPantallaUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    } //cierre clase
} //cierre namespace
