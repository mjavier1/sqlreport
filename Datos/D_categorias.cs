
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class D_categorias

    {
        public DataTable Listar_ca(String @cTexto)
        {
            SqlDataReader rdr;
            DataTable mydata = new DataTable();
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon = conexion.GetInstancia().creaconexion();
                SqlCommand cmd = new SqlCommand("Usp_Listado_ca", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                sqlcon.Open();
                rdr = cmd.ExecuteReader();
                mydata.Load(rdr);
                return mydata;


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }


        }
        public string Guardar_ca(int Opcion, E_categorias oca)
        {
            String Rpta;
            SqlConnection Sqlcon = new SqlConnection();

            try
            {
                Sqlcon = conexion.GetInstancia().creaconexion();
                SqlCommand commandd = new SqlCommand("USP_Guardar_ca", Sqlcon);
                commandd.CommandType = CommandType.StoredProcedure;
                commandd.Parameters.Add("@Opcion", SqlDbType.Int).Value = Opcion;
                commandd.Parameters.Add("@Codigo_ca", SqlDbType.Int).Value = oca.codigo_ca;
                commandd.Parameters.Add("@Desc_ca", SqlDbType.VarChar).Value = oca.desc_ca;
                Sqlcon.Open();
                Rpta = commandd.ExecuteNonQuery() == 1 ? "ok" : "no se pudo registrar el proceso";




            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
                throw;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open) Sqlcon.Close();

            }
            return Rpta;

        }
        public string drop_ca(int Codigo)
        {
            String Rpta;
            SqlConnection Sqlcon = new SqlConnection();

            try
            {
                Sqlcon = conexion.GetInstancia().creaconexion();
                SqlCommand commandd = new SqlCommand("Usp_Eliminar_ca", Sqlcon);
                commandd.CommandType = CommandType.StoredProcedure;
                commandd.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;

                Sqlcon.Open();
                Rpta = commandd.ExecuteNonQuery() == 1 ? "ok" : "no se pudo Elimar el Registro";




            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
                throw;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open) Sqlcon.Close();

            }
            return Rpta;











            // return Lista_ca()
        }
    }
}
