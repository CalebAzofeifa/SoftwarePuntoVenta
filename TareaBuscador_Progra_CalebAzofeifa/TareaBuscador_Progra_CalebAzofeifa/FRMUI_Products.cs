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
                this.GuardarProducto();
                MessageBox.Show("Producto registrado","Proceso realizado", MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }//cierre de clase
}//cierre del namespace
