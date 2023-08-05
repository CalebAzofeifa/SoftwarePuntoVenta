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
    public partial class VentanaLog : Form
    {
        private Usuario objUsuario = null;

        private Conexion objConexion = null;

        public VentanaLog()
        {
            InitializeComponent();
            objConexion = new Conexion();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void IntentoAutenticacion()
        {
            try
            {
                objUsuario = new Usuario();
                objUsuario.Email = this.DatosUsuario.Text.Trim();
                objUsuario.password = this.DatosContraseña.Text.Trim();

                if (objUsuario.Email.Equals("admin@gmail.com") & objUsuario.password.Equals("admin"))
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("Usuario o contraseña incorrectos");
                }

            }

            catch (Exception ex) 
            {

                throw ex;
            }

        }

        private void IntentoAutenticacionDB()
        {
            try
            {
                this.objUsuario = this.objConexion.ValidarAutenticacion(this.DatosUsuario.Text.Trim(), this.DatosContraseña.Text.Trim());

                if (this.objUsuario == null)
                {
                    throw new Exception("Usuario o Contraseña incorrectos. . .");
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }  


            }




        private void BtnIsesion_Click(object sender, EventArgs e)
        {
            try
            {
                IntentoAutenticacionDB();

            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }//cierre de clase
}//cierre del namespace
