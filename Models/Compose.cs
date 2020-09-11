using Audaces.Helpers;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Audaces.Models
{
    public class Compose
    {
        public int[] sequence { get; set; }
        public int target { get; set; }
        public Compose() { }


        public async Task<string> calculateFactor()
        {
            // instanciamos alguns cursores para facilitar o processo
            int virtual_target = 0;
            List<int> virtual_sequence = new List<int>();
            // ordenamos a sequencia, para começarmos do maior
            List<int> sequence_list = sequence.ToList();
            sequence_list.Sort();
            sequence_list.Reverse();

            while (virtual_target < target)
            {
                foreach(int v in sequence_list)
                {
                    if(sequence_list.IndexOf(v) == (sequence_list.Count - 1))
                    {
                        virtual_sequence.Add(v);
                        virtual_target += v;
                        break;
                    } else
                    {
                        if ((v + sequence_list[sequence_list.IndexOf(v) + 1]) <= (target - virtual_target) || v == (target - virtual_target))
                        {
                            virtual_sequence.Add(v);
                            virtual_target += v;
                            break;
                        } else
                            continue;
                    }
                }
            }
            // instancia o retorno
            string ret = "Não é possível chegar no número desejado com a combinação fornecida.";

            if (virtual_target == target)
                ret = string.Join(", ", virtual_sequence);
            // coloca na ordem crescente
            virtual_sequence.Reverse();
            //grava no banco da dados
            this.generateLog(sequence_list, target, ret);
            // devolve
            return ret;
        }
        public void generateLog(List<int> sequence, int target, string retorno) 
        {
            using(SqlConnection  oConn = new SqlConnection(ConnectionString.getConnectionString()))
            {
                SqlCommand oSqlComm = new SqlCommand();
                oSqlComm.Connection = oConn;
                oSqlComm.CommandType = CommandType.Text;
                try
                {
                    oConn.Open();

                    oSqlComm.Parameters.AddWithValue("@sequencia", string.Join(", ", sequence));
                    oSqlComm.Parameters.AddWithValue("@alvo", target);
                    oSqlComm.Parameters.AddWithValue("@data_hora", DateTime.Now.AddDays(-14));
                    oSqlComm.Parameters.AddWithValue("@retorno", retorno);
                    oSqlComm.CommandText = @"INSERT INTO consultas
                                            (sequencia, alvo, data_hora, retorno)
                                        VALUES
                                            (@sequencia, @alvo, @data_hora, @retorno)";
                    oSqlComm.ExecuteNonQuery();
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
