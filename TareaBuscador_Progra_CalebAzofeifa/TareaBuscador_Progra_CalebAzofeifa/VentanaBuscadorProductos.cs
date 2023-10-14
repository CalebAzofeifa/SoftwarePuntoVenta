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
    public partial class VentanaBuscadorProductos : Form
    {

        private Conexion objConexion = null;


        public VentanaBuscadorProductos()
        {
            InitializeComponent();
            objConexion = new Conexion();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Txtdescripcion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BuscarProduct(this.Txtdescripcion.Text.Trim());
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarProduct(string desc)
        {
            try
            {
                this.dtgDatos.DefaultCellStyle.Font = new Font("Times New Roman", 14);
                this.dtgDatos.DefaultCellStyle.ForeColor = Color.Black;
                this.dtgDatos.DataSource = objConexion.BuscarProductos(desc).Tables[0];
                this.dtgDatos.AutoResizeColumns();
                this.dtgDatos.ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        private void dtgDatos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarUIProductos(0);
                //permite actualizar la lista de productos después de incluir nuevos productos
                this.BuscarProduct("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarUIProductos(int funcion)
        {
            FRMUI_Products frm = new FRMUI_Products();
            //proceso de modificar
            if (funcion == 1)
            {
                //el producto que vamos a modificar
                Producto temp = new Producto();
                temp.ID = int.Parse(this.dtgDatos.SelectedRows[0].Cells["ID"].Value.ToString());
                temp.CodigoBarra = this.dtgDatos.SelectedRows[0].Cells["CodigoBarras"].Value.ToString();
                temp.Descripcion = this.dtgDatos.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                temp.PrecioCompra = decimal.Parse(this.dtgDatos.SelectedRows[0].Cells["PrecioCompra"].Value.ToString());
                temp.Impuesto = decimal.Parse(this.dtgDatos.SelectedRows[0].Cells["Impuesto"].Value.ToString());
                //se le envian los datos del producto al formulario
                frm.CargarDatosProducto(temp);
            }
            //se asigna el valor para la funcion a realizar
            frm.funcion = funcion;
            frm.ShowDialog();
            frm.Dispose();  
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgDatos.SelectedRows.Count <= 0) 
                {
                    throw new Exception("Seleccione la fila del producto a eliminar");
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar el producto seleccionado?","Confirmar"
                        ,MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.EliminarProd(int.Parse(this.dtgDatos.SelectedRows[0].Cells["ID"].Value.ToString()));
                        this.BuscarProduct("");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        
        private void EliminarProd(int id)
        {
            try
            {
                this.objConexion.EliminarProducto(id);
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
                if (this.dtgDatos.SelectedRows.Count <= 0)
                {
                    throw new Exception("Seleccione la fila del producto a modificar. ");
                }
                else
                {
                    //valor 1 indica modificar
                    this.MostrarUIProductos(1);

                    //actualiza la lista
                    this.BuscarProduct("");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }//Cierre clase
}//Cierre namespace
