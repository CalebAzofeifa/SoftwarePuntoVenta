using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//drivers sql
using System.Data.SqlClient;

using BLL;
using Microsoft.Win32;
using System.Data;

namespace DAL
{
    public class Conexion
    {
        private SqlConnection _connection;
        private SqlCommand _command;    
        private SqlDataReader _reader;  
        private SqlDataAdapter _adapter;
        private string StringDeConexion;


        public Conexion()
        {
            StringDeConexion = "Data source = CALEB; initial catalog = DbPuntoVenta; user id = UserPuntoVenta; password = uh2023";
        }

        public Usuario ValidarAutenticacion(string pEmail, string pPW)
        {
            try
            {
                Usuario temp = null;
                //se envian los parametros para la conexion
                _connection = new SqlConnection(this.StringDeConexion);

                //se abre la conexion
                _connection.Open();
                //se instancia el comando
                _command = new SqlCommand();
                //asignar conexion al comando
                _command.Connection = _connection;
                //tipo de comando
                _command.CommandType = System.Data.CommandType.Text;
                //se indica el transac-sql a ejecutar
                _command.CommandText = "select Email,NombreCompleto,Password,FechaRegistro,Estado from TblUsuarios where Email = '" + pEmail + "' and Password = '"+ pPW +"'";
                //se ejecuta el comando y se almacena los datos leidos
                _reader = _command.ExecuteReader(); 

                if (_reader.Read())
                {
                    temp = new Usuario();

                    temp.Email = _reader.GetValue(0).ToString();
                    temp.NombreCompleto = _reader.GetValue(1).ToString();
                    temp.password = _reader.GetValue(2).ToString();
                    temp.FechaRegistro = DateTime.Parse(_reader.GetValue(3).ToString());
                    temp.Estado = char.Parse(_reader.GetValue(4).ToString());


                }
                //se cierra la conexion
                _connection.Close();

                _connection.Dispose();
                _command.Dispose();
                _reader = null;


                return temp;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public DataSet BuscarProductos(string descrip)
        {
            try
            {
                DataSet datos = new DataSet();

                _connection = new SqlConnection(StringDeConexion);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Sp_Cns_Productos]";

                _command.Parameters.AddWithValue("@Descrip", descrip);
                _adapter = new SqlDataAdapter();
                _adapter.SelectCommand = _command;
                _adapter.Fill(datos);
                _connection.Close();   
                _command.Dispose();
                _adapter.Dispose();


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public DataSet BuscarUsuarios(string name)
        {
            try
            {
                DataSet data1 = new DataSet();

                _connection = new SqlConnection(StringDeConexion);

                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Sp_Cns_Usuarios]";


                _command.Parameters.AddWithValue("@Nombre", name);
                _adapter = new SqlDataAdapter();
                _adapter.SelectCommand = _command;
                _adapter.Fill(data1);
                _connection.Close();
                _command.Dispose();
                _adapter.Dispose();


                return data1;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        //nota, el dataset solo es utilizado para traer la informacion de la base de datos y la monta en el programa para mostrarla
        public void GuardarProducto(Producto pProd)
        {
            try
            {
                //se instancia la conexion donde se envian los parametros de información al servidor de db por medio 
                // del string de conexion
                _connection = new SqlConnection(this.StringDeConexion);
                _connection.Open();
                //se instancia el comando 
                _command = new SqlCommand();
                //se asigna la conexion
                _command.Connection = _connection;
                //se indica el tipo de comando
                _command.CommandType = CommandType.StoredProcedure;
                //se indica el proceso de la base de datos a utilizar
                _command.CommandText = "[Sp_Ins_Productos]";
                //se asignan los valores a cada parametro requerido al procedimiento almacenado
                _command.Parameters.AddWithValue("@CodBarra", pProd.CodigoBarra);
                _command.Parameters.AddWithValue("@Descrip", pProd.Descripcion);
                _command.Parameters.AddWithValue("@PrecComp", pProd.PrecioCompra);
                _command.Parameters.AddWithValue("@Imp", pProd.Impuesto);
                //se ejecuta la transaccion por medio del comando
                _command.ExecuteNonQuery();
                //una vez finalizado la transaccion se liberan los recursos y se cierra la conexion
                _connection.Close();  
                _connection.Dispose();
                _command.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarUsuario(Usuario uUser)
        {
            try
            {
                _connection = new SqlConnection(this.StringDeConexion);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Sp_Ins_Usuarios]";
                _command.Parameters.AddWithValue("@Email", uUser.Email);
                _command.Parameters.AddWithValue("@FullName", uUser.NombreCompleto);
                _command.Parameters.AddWithValue("@PassW", uUser.password);
                _command.ExecuteNonQuery();
                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }//ClaseCerrada
}//Cierre del namespace
