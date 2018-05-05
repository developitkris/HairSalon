using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalonApp;

namespace HairSalonApp.Models
{
    public class Stylist
    {
        private int _id;
        private string _name;
        private string _specialty;
        private List<Client> _clients = new List<Client>();

        public Stylist(string name, string specialty, List clients, int id=0)
        {
          _name= name;
          _specialty= specialty;
          _clients= clients;
          _stylistId=stylistId;
        }

        public int GetId()
        {
          return _id;
        }

        public string GetStylistName()
        {
          return _name;
        }

        public string GetStylistSpecialty()
        {
          return _specialty;
        }

        public List GetClientList()
        {
          return _clients;
        }

        public void Save()
        {
           MySqlConnection conn = DB.Connection();
           conn.Open();
           MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"INSERT INTO stylists (name, specialty) VALUES (@name, @specialty);";

           MySqlParameter name = new MySqlParameter();
           name.ParameterName = "@name";
           name.Value = _name;
           cmd.Parameters.Add(name);

           MySqlParameter specialty = new MySqlParameter();
           specialty.ParameterName = "@specialty";
           specialty.Value = _specialty;
           cmd.Parameters.Add(specialty);

           cmd.ExecuteNonQuery();
           _id = (int) cmd.LastInsertedId;

           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
        }

        public static List<Stylist> GetAllStylists()
        {
           List<Stylist> stylists = new List<Stylist>();

           MySqlConnection conn = DB.Connection();
           conn.Open();
           MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"SELECT * FROM stylists;";

           MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

           while (rdr.Read())
           {
               int id = (int) rdr.GetInt32(0);
               string name = rdr.GetString(1);
               Stylist inputStylist = new Stylist(name);
               inputStylist.GetId();
               stylists.Add(inputStylist);
           }

           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }

           return stylists;
       }

        public List<Client> GetClientList()
        {
            List<Client> Clients = new List<Client>();

            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"Select * FROM clients WHERE stylist_id=@id;";

            MySqlParameter id = new MySqlParameter("@id", _id);
            cmd.Parameters.Add(id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while (rdr.Read())
            {
                Client inputClient = new Client(rdr.GetString(1), _id);
                inputClient(rdr.GetInt32(0));
                Clients.Add(inputClient);
            }

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return inputClients;
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients WHERE stylist_id = @id;
            DELETE FROM stylists WHERE id = @id;";

            MySqlParameter id = new MySqlParameter();
            id.ParameterName = "@id";
            id.Value = _id;
            cmd.Parameters.Add(id);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;
            DELETE FROM stylists;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

    }
}
