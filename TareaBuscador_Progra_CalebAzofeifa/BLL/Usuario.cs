using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Usuario
    {
        public string Email { get; set; }

        public string NombreCompleto { get; set; }

        public string password { get; set; }

        public DateTime FechaRegistro { get; set; }

        public char Estado { get; set; }

        public bool ConfirmarPassword(string pw)
        {
            bool valido = false;
            if (password.Equals(pw))
            {
                valido = true;
            }
            return valido;
        }

       

    }//cierre clase



}//cierre namespace
