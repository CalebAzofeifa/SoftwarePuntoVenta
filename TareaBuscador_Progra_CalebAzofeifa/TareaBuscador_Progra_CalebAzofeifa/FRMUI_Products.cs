using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//las 2 clases utilizadas
using BLL;
using DAL;
namespace TareaBuscador_Progra_CalebAzofeifa
{
    public partial class FRMUI_Products : Form
    {
        //objeto producto
        private Producto objProduc = null;
        //objeto conexion
        private Conexion objConexion = null;
        //lo que determina si se modifica o se añade un producto nuevo
        public int funcion = 0;

        //variable para controlar la ID del producto
        public int IDProducto = 0;

        public FRMUI_Products()
        {
            InitializeComponent();
            objConexion = new Conexion();
        }

        private void GuardarProducto()
        {
            try
            {
                //se instancia el objeto producto
                objProduc = new Producto();
                objProduc.CodigoBarra = this.TxtCodBarra.Text.Trim();
                objProduc.Descripcion = this.TxtDescrip.Text.Trim();
                objProduc.PrecioCompra = decimal.Parse(this.TxtPrecComp.Text.Trim());
                objProduc.Impuesto = decimal.Parse(this.TxtImp.Text.Trim());
                objConexion.GuardarProducto(objProduc);
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
                if (this.funcion  == 0) //quiere decir si es el proceso guardar
                {
                    this.GuardarProducto();
                    MessageBox.Show("Producto registrado", "Proceso realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else //proceso modificar
                {
                    this.Modificar();
                    MessageBox.Show("Producto modificado", "Proceso realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //si es 1 quiere decir que es modificar, si es 0 es añadir nuevo producto
                if (funcion == 1)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarDatosProducto(Producto temp)
        {
            try
            {
                //se rellena el front end con los datos del object
                this.IDProducto = temp.ID;
                this.TxtCodBarra.Text = temp.CodigoBarra;
                this.TxtDescrip.Text = temp.Descripcion;
                this.TxtPrecComp.Text = temp.PrecioCompra.ToString();
                this.TxtImp.Text = temp.Impuesto.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Modificar()
        {
            try
            {
                Producto temp = new Producto();
                temp.ID = this.IDProducto; //id del producto a modificar
                temp.CodigoBarra = this.TxtCodBarra.Text;
                temp.Descripcion = this.TxtDescrip.Text;
                temp.PrecioCompra = decimal.Parse(this.TxtPrecComp.Text);
                temp.Impuesto = decimal.Parse(this.TxtImp.Text);
                this.objConexion.ModificarProducto(temp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }//cierre de clase
}//cierre del namespace
