using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace APi_Web_1.Datos
{
    public class DBDatos
    {
        public static string defaultConn = ConfigurationManager.ConnectionStrings["localhost"]
                                                            .ConnectionString;
        public static Response Ejecutar(string nombreProcedimiento, 
                                            List<Parametro> parametros, 
                                            string stringConn = "")
        {
            Response response = new Response();
            response.Message = "";
            using (SqlConnection conn = new SqlConnection(string.IsNullOrEmpty(stringConn) ? defaultConn : stringConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(nombreProcedimiento, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        if (parametros != null)
                        {
                            foreach (var parametro in parametros)
                            {
                                if (!parametro.Salida)
                                {
                                    cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                                }
                                else
                                {
                                    cmd.Parameters.Add(parametro.Nombre, System.Data.SqlDbType.NVarChar, 100)
                                        .Direction = System.Data.ParameterDirection.Output;
                                }
                            }
                        }

                        // e retorna 0 ó -1
                        int e = cmd.ExecuteNonQuery();

                        for (int i = 0; i < parametros.Count; i++)
                        {
                            if (cmd.Parameters[i].Direction == System.Data.ParameterDirection.Output)
                            {
                                string mensaje = cmd.Parameters[i].Value.ToString();

                                if (!string.IsNullOrEmpty(mensaje))
                                {
                                    response.Message = mensaje;
                                }
                            }
                        }

                        response.Exito = e > 0 ? true : false;
                        response.Message = e > 0 ? "Found Data" : "No se encontro data1";
                    }
                }
                catch (Exception ex)
                {
                    response.Exito = false;
                    response.Message = ex.Message;
                }

                return response;
            }
        }

        public static Response ListarPersona(string storeProcedureName, List<Parametro> parametros, string newConn = "")
        {
            Response response = new Response();

            using (SqlConnection conn = new SqlConnection(string.IsNullOrEmpty(newConn) ? defaultConn : newConn))
            {
                using (SqlCommand cmd = new SqlCommand(storeProcedureName, conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        if (parametros != null)
                        {
                            foreach (var parametro in parametros)
                            {
                                cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                            }
                        }

                        DataTable dt = new DataTable();

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                        {
                            sqlDataAdapter.Fill(dt);
                            response.Exito = true;
                            response.Message = dt.Rows.Count > 0 ? "Data Found" : "Not Data";
                            response.Result = dt;
                            return response;
                        }

                    } catch (Exception ex)
                    {
                        response.Exito = false;
                        response.Message = ex.Message;
                        return response;
                    }
                }
            }

            
        }


    }
}
