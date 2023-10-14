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
    public partial class FRMUI_Clientes : Form
    {
        private Clientes objCliente = null;
        private Conexion objConexion = null;
        public int funcion = 0;

        public FRMUI_Clientes()
        {
            InitializeComponent();
            objConexion = new Conexion();
        }

        private void GuardarCliente()
        {
            try
            {
                objCliente = new Clientes();
                objCliente.Cedula = this.TxtCedula.Text.Trim();
                objCliente.Nombre = this.TxtFullN.Text.Trim();
                objCliente.Telefono = this.TxtTelef.Text.Trim();
                objCliente.LCredito = decimal.Parse(this.TxtLCredito.Text.Trim());
                objCliente.Email = this.TxtEmail.Text.Trim();
                objCliente.FechaNacimiento = DateTime.Parse(this.TxtFechaN.Text.Trim());
                objConexion.GuardarCliente(objCliente);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAcciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.funcion  == 0) 
                {
                    this.GuardarCliente();
                    MessageBox.Show("Cliente registrado", "Proceso realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    this.ModificarCliente();
                    MessageBox.Show("Cliente modificado", "Proceso realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRMUI_Products_Load(object sender, EventArgs e)
        {
            try
            {
                if (funcion == 1)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarDatosCliente(Clientes temp)
        {
            try
            {
                this.TxtCedula.Text = temp.Cedula;
                this.TxtFullN.Text = temp.Nombre;
                this.TxtTelef.Text = temp.Telefono;
                this.TxtLCredito.Text = temp.LCredito.ToString();
                this.TxtEmail.Text = temp.Email;
                this.TxtFechaN.Text = temp.FechaNacimiento.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarCliente()
        {
            try
            {
                Clientes temp = new Clientes();
                temp.Cedula = this.TxtCedula.Text;
                temp.Nombre = this.TxtFullN.Text;
                temp.Telefono = this.TxtTelef.Text;
                temp.LCredito = decimal.Parse(this.TxtLCredito.Text);
                temp.Email = this.TxtEmail.Text;
                temp.FechaNacimiento = DateTime.Parse(this.TxtFechaN.Text);
                this.objConexion.ModificarCliente(temp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }//cierre de clase
}//cierre del namespace
