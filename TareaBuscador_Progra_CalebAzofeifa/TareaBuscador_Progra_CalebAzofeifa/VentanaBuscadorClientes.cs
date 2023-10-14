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
using BLL;
using DAL;

namespace TareaBuscador_Progra_CalebAzofeifa
{
    public partial class VentanaBuscadorClientes : Form
    {
        private Conexion objConexion = null;

        public VentanaBuscadorClientes()
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
                BuscarClientes(this.Txtnames.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarClientes(string name)
        {
            try
            {
                this.dtgClientes.DefaultCellStyle.ForeColor = Color.Black;
                this.dtgClientes.DataSource = objConexion.BuscarClientes(name).Tables[0];
                this.dtgClientes.AutoResizeColumns();
                this.dtgClientes.ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarUIClientes(0);

                this.BuscarClientes("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarUIClientes(int funcion)
        {
            FRMUI_Clientes frm = new FRMUI_Clientes();
            if (funcion == 1)
            {
                Clientes temp = new Clientes();
                temp.Cedula = this.dtgClientes.SelectedRows[0].Cells["Cedula"].Value.ToString();
                temp.Nombre = this.dtgClientes.SelectedRows[0].Cells["NombreCompleto"].Value.ToString();
                temp.Telefono = this.dtgClientes.SelectedRows[0].Cells["Telefono"].Value.ToString();
                temp.LCredito = decimal.Parse(this.dtgClientes.SelectedRows[0].Cells["LimiteCredito"].Value.ToString());
                temp.Email = this.dtgClientes.SelectedRows[0].Cells["Email"].Value.ToString();
                temp.FechaNacimiento = DateTime.Parse(this.dtgClientes.SelectedRows[0].Cells["FechaNacimiento"].Value.ToString());
                frm.CargarDatosCliente(temp);
            }
            frm.funcion = funcion;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgClientes.SelectedRows.Count <= 0)
                {
                    throw new Exception("Seleccione la fila del cliente a eliminar");
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar el cliente seleccionado?", "Confirmar"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.EliminarCliente(this.dtgClientes.SelectedRows[0].Cells["Cedula"].Value.ToString());
                        this.BuscarClientes("");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void EliminarCliente(string Cedula)
        {
            try
            {
                this.objConexion.EliminarCliente(Cedula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgClientes.SelectedRows.Count <= 0)
                {
                    throw new Exception("Seleccione la fila del producto a modificar. ");
                }
                else
                {
                    this.MostrarUIClientes(1);

                    this.BuscarClientes("");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }//cierre de la clase
}//cierre del namespace
