using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                this.MostrarUIProductos();
                //permite actualizar la lista de productos después de incluir nuevos productos
                this.BuscarProduct("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarUIProductos()
        {
            FRMUI_Products frm = new FRMUI_Products();
            frm.ShowDialog();
            frm.Dispose();  
        }


    }//Cierre clase
}//Cierre namespace
