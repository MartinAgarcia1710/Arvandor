using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Arvandor
{
    internal class GameSaveLoad
    {
        
        private string connectionString;
        public SpiritTypes playerSaved { get; set; }

        public GameSaveLoad()
        {
         
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
                using(SqlConnection connect = new SqlConnection(connectionString))
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
        public SpiritTypes loadGame() 
        {
            int c = 0;
            int op = 0;
            SpiritTypes pl = new SpiritTypes();
            List<SpiritTypes> lis = new List<SpiritTypes>();
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string query = "SELECT ID, Name, level, SpiritClass, KillCounter, BossCounter FROM Players";
                    SqlCommand command = new SqlCommand(query, connect);
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        if (reader.HasRows)
                        {
                            Console.WriteLine("Continue game");
                            while (reader.Read())
                            {
                                pl.ID = Convert.ToInt32(reader["ID"]);
                                pl.Name = Convert.ToString(reader["Name"]);
                                pl.Level = Convert.ToInt32(reader["level"]);
                                pl.SpiritClass = Convert.ToString(reader["SpiritClass"]);
                                pl.KillCount = Convert.ToInt32(reader["KillCounter"]);
                                pl.bossCounter = Convert.ToInt32(reader["BossCounter"]);
                                lis.Add(pl); 
                            }
                            foreach(SpiritTypes t in lis)
                            {
                                Console.WriteLine(c + "." + t.Name + "|Lvl " + t.Level + "|Spirit Class: " + t.SpiritClass);
                                Console.WriteLine("----------------------------------------------------------------------------------------");
                                c++;
                            }
                            Console.WriteLine("Select");
                            op = int.Parse(Console.ReadLine());
                            return lis[op - 1];
                        }
                        else
                        {
                            Console.WriteLine("No games...");
                            return null;
                        }
                    }
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Ups..." + ex.Message);
            }
            return null;
        }
        public void saveGame(SpiritTypes player) 
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String query = "INSERT INTO Players(ID, Name, Level, SpiritClass, KillCounter, BossCounter) VALUES (@Player.ID, @player.Name, @player.Level, @player.SpiritClass, @player.KillCount, @player.bossCounter); SELECT SCOPE_IDENTITY();";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", player.Name);
                    command.Parameters.AddWithValue("@level", player.Level);
                    command.Parameters.AddWithValue("@SpiritClass", player.SpiritClass);
                    command.Parameters.AddWithValue("@KillCounter", player.KillCount);
                    command.Parameters.AddWithValue("@BossCounter", player.bossCounter);
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ups..." + ex.Message);
                
            }
        }
        public void checkExistDataBase(SpiritTypes player)  
        {
            bool dbCreated = Convert.ToBoolean(ConfigurationManager.AppSettings["DatabaseCreated"]);
            if(!dbCreated)
            {
                createDataBase();
                Console.WriteLine("Primera partida guardada");
            }
            
                saveGame(player);
                Console.Clear();
                Console.WriteLine("Saving...");
                Thread.Sleep(3000);
                Console.WriteLine("Succesful!");
            
            
        }
    }
}
