using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;

namespace Simbirsoft_Practice
{
    class dbworker
    {
        MySqlConnection Connection;
        MySqlConnectionStringBuilder Connect = new MySqlConnectionStringBuilder();

        public dbworker(string server, string user, string pass, string database)
        {
            Connect.Server = server;
            Connect.UserID = user;
            Connect.Password = pass;
            Connect.Port = 3306;
            Connect.Database = database;
            Connect.CharacterSet = "utf8";
            Connection = new MySqlConnection(Connect.ConnectionString);
        }


        public long download_site(string site)
        {

            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO site_stats(site_name) VALUES(?site)";
            command.Parameters.Add("?site", MySqlDbType.VarChar).Value = site;
            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
                return command.LastInsertedId;
            }
            catch (Exception e)
            {
                Console.WriteLine("---->Предупреждение: данный сайт присутствует в статистике БД. Повторная запись существующего сайта невозможна.");
            }
            finally
            {
                Connection.Close();
            }
            return -1;
        }

        public long download_words(string words, string value)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO words_stats(word_name, value) VALUES(?word, ?value)";
            command.Parameters.Add("?word", MySqlDbType.VarChar).Value = words;
            command.Parameters.Add("?value", MySqlDbType.Int32).Value = value;
            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
                return command.LastInsertedId;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка : " + e.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return -1;
        }

        public long download_sites_and_words(string site, string word, int value)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO total_stats(site, word, value) VALUES(?site, ?word, ?value)";
            command.Parameters.Add("?site", MySqlDbType.VarChar).Value = site;
            command.Parameters.Add("?word", MySqlDbType.VarChar).Value = word;
            command.Parameters.Add("?value", MySqlDbType.Int32).Value = value;
            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
                return command.LastInsertedId;
            }
            catch (Exception e)
            {
                Console.WriteLine("---->Ошибка : " + e.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return -1;
        }



    }
}
