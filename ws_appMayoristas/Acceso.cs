using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ws_appMayoristas
{
    public class Acceso
    {
        public static bool Verificar(string aplicacion, string password)
        {
            int Opcion = 2;
            string sConexion = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringYourEnterprise"].ConnectionString;
            bool Res = false;


            using (SqlConnection oConexion = new SqlConnection(sConexion))
            {
                oConexion.Open();
                SqlCommand cmd = new SqlCommand("swsYourEnterprise.sp_wsYourEnterprise", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                

                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@Opcion", Opcion);
                param[1] = new SqlParameter("@App", aplicacion.Trim());

                cmd.Parameters.AddRange(param);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        if (reader[0].ToString().Trim() == password.Trim())
                            Res = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Res;
        }

    }
}