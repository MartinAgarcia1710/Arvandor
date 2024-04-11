using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class GameSaveLoad
    {
        private string connection;

        public GameSaveLoad(string con)
        {
            this.connection = con;
        }

        public void createDataBase()
        {
            string createScipt = @"
                CREATE DATABASE GameArvandor;
                Use GameArvandor
                CREATE TABLE Players(
                ID int PRIMARY KEY,
                Name varchar(100),
                Level int,
                SpiritClass varchar(100),
                KillCounter int,
                BossCounter int
                )
                ";
            try
            {
                using(SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand(createScipt, connect);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("DataBase created ");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("DataBase error" +  ex.Message);
            }
           
        }

    }
}
