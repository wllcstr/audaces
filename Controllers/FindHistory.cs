using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Audaces.Helpers;
using Audaces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Audaces.Controllers
{
    [Route("api/history/{startDate}/{finalDate}")]
    [ApiController]
    public class FindHistory : ControllerBase
    {
        [HttpGet]
        public async Task<Consulta[]> GetHistory(string startDate, string finalDate)
        {
            DateTime start_date = DateTime.Parse(startDate);
            DateTime final_date = DateTime.Parse(finalDate);

            using (SqlConnection oConn = new SqlConnection(ConnectionString.getConnectionString()))
            {
                SqlCommand oSqlComm = new SqlCommand();
                oSqlComm.Connection = oConn;
                oSqlComm.CommandType = CommandType.Text;

                List<Consulta> consultas = new List<Consulta>();

                try
                {
                    oConn.Open();
                    oSqlComm.Parameters.AddWithValue("@start_date", start_date);
                    oSqlComm.Parameters.AddWithValue("@final_date", final_date);
                    oSqlComm.CommandText = @"SELECT * FROM consultas WHERE data_hora BETWEEN @start_date AND @final_date";

                    SqlDataReader oSDR = oSqlComm.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(oSDR);
                    oSDR.Close();

                    foreach(DataRow dr in dt.Rows)
                    {
                        Consulta c = new Consulta();
                        c.sequencia = dr["sequencia"].ToString();
                        c.alvo = (int)dr["alvo"];
                        c.data_hora = string.Format("{0:dd/MM/yyyy}", dr["data_hora"]);
                        c.retorno = dr["retorno"].ToString();

                        consultas.Add(c);
                    }
                    return consultas.ToArray();
                } catch(Exception ex)
                {
                    throw ex;
                } finally
                {
                    oConn.Close();
                }
            }

        }
    }
}
