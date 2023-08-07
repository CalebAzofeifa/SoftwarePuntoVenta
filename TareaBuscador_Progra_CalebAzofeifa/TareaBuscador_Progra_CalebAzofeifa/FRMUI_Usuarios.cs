using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace TareaBuscador_Progra_CalebAzofeifa
{
    public partial class FRMUI_Usuarios : Form
    {
        private Usuario objUsuario= null;
        private Conexion objConexion = null;
        public FRMUI_Usuarios()
        {
            InitializeComponent();
            objConexion=new Conexion();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuardarUsuario()
        {
            try
            {
                objUsuario = new Usuario();
                objUsuario.Email = this.TxtEmail.Text.Trim();
                objUsuario.NombreCompleto = this.TxtFullName.Text.Trim();
                objUsuario.password = this.TxtPassW.Text.Trim();
                objConexion.GuardarUsuario(objUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.TxtPassW.Text == this.TxtConfirmPassW.Text)
            {
                try
                {
                    this.GuardarUsuario();
                    MessageBox.Show("Usuario registrado", "Proceso realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                throw new Exception("Error de confirmación, digite la contraseña correctamente");
            }
        }


    }//cierre de la clase
}//cierre del namespace
