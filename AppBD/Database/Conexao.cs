using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBD.Database
{
    public class Conexao
    {
        readonly MySqlConnection con = new MySqlConnection("Server=localhost;Database=appdb;port=3306;user=ioshi;pwd=123");
        public static string message;

        public MySqlConnection ConnectionDB()
        {
            try
            {
                con.Open();
            }
            catch (Exception error)
            {
                message = "Something when error!" + error.Message;
            }
            return con;
        }

        public MySqlConnection DisconnectDB()
        {
            try
            {
                con.Close();
            }
            catch (Exception error)
            {
                message = "Something when error!" + error.Message;
            }
            return con;
        }
    }
}