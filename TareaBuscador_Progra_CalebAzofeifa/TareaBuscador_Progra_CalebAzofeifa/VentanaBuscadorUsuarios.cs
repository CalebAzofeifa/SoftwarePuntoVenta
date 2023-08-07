using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DAL;

namespace TareaBuscador_Progra_CalebAzofeifa
{
    public partial class VentanaBuscadorUsuarios : Form
    {
        private Conexion objConexion = null;

        public VentanaBuscadorUsuarios()
        {
            InitializeComponent();
            objConexion = new Conexion();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TxtNames_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BuscarUser(this.Txtnames.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarUser(string name)
        {
            try
            {
                this.dtgUsuarios.DefaultCellStyle.ForeColor = Color.Black;
                this.dtgUsuarios.DataSource = objConexion.BuscarUsuarios(name).Tables[0];
                this.dtgUsuarios.AutoResizeColumns();
                this.dtgUsuarios.ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dtgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarUIUser();
                //permite actualizar la lista de productos después de incluir nuevos productos
                this.BuscarUser("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarUIUser()
        {
            try
            {
                FRMUI_Usuarios frmuser = new FRMUI_Usuarios();
                frmuser.ShowDialog();
                frmuser.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }//cierre de la clase
}//cierre del namespace
