using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public  class conexion
    {
        private string Base;
        private string user;
        private string server;
        private string clave;
        private static conexion Con = null;
        private conexion()
        {
            this.Base = "mydata";
            this.user = "sa";
            this.server = "MJDEVELOP\\SQLEXPRESS";
            this.clave = "datasql";

           

        }
        public SqlConnection creaconexion()
        {
            SqlConnection cadena = new SqlConnection();
           
            try
            {
              //  cadena.Open();
                cadena.ConnectionString = "Server=" + this.server + "; Database=" + this.Base + ";User Id=" + this.user +";Password="+this.clave;


            }
            catch (Exception ex)
            {
                cadena = null;

                throw ex;
            } return cadena;

        }
       public static conexion GetInstancia ()
        {
            if(Con == null)
            {
                Con = new conexion();

            }
            return Con;

        }

    }
   
}
