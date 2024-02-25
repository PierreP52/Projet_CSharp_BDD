using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projet02P2_Pierre_Pourre
{
    class DOAwocloo
    {
        public static MySqlConnection conn;
        public static MySqlCommand cmd = new MySqlCommand();
        public static void connect()
        {
            //paramètres de connexion
            string server = "localhost";
            string database = "Wooclo";
            string user = "root";
            string password = "AECgodin.21012023";
            string port = "3306";
            string sslM = "none";
            //server= ;port= ;user id= ;password= ;database= ;SslMode= 
            string connString = String.Format("server={0};port={1};user id={2};password={3};database={4};SslMode={5}", server, port, user, password, database, sslM);

            conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                Console.WriteLine("Connection Successful ");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message + connString);
            }


        }
        //fonction d'interrogation des données SELECT
        public static DbDataReader QuerySELECT(string query)
        {
            
            //j'établie la connexion ainsi que la commande
            cmd.Connection = conn;
            cmd.CommandText = query;
            //j'éxecute la commande
            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }


        public static void QueryDML_DDL(string query)
        {
            
                //j'établis la connexion et la commande
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                //execution de la mise à jour des données (insert, update, delete) ou mise à jour de la BD (create table, alter table)
                int count = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + count);
           
        }
    }
}
