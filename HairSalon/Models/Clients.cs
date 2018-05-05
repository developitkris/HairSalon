using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalonApp;

namespace HairSalonApp.Models
{
    public class Client
    {
        private string _name;
        private string _phone;
        private int _stylistId;

        public Client(string name, string phone, int stylistId)
        {
            _name = name;
            _phone = phone;
            _stylistId = stylistId;
        }

        // public void SetStylistId(int stylistId)
        // {
        //     _stylistId = stylistId;
        // }
        public string GetCustomerName()
        {
            return _name;
        }

        public string GetPhone()
        {
          return _phone;
        }

        public int GetStylistId()
        {
            return _stylistId;
        }

        public void Save()
        {
           MySqlConnection conn = DB.Connection();
           conn.Open();
           MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"INSERT INTO clients (name, phone, stylist_id) VALUES (@name, @phone, @stylistId);";

           MySqlParameter name = new MySqlParameter("@name", _name);
           MySqlParameter phone = new MySqlParameter("@phone", _phone);
           MySqlParameter stylistId = new MySqlParameter("@stylistId", _stylistId);
           cmd.Parameters.Add(name);
           cmd.Parameters.Add(phone);
           cmd.Parameters.Add(stylistId);

           // cmd.ExecuteNonQuery();
           // _stylistId = (int) cmd.LastInsertedId;

           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
        }

        public List<Client> GetClientInfo()
        {
            List<Client> Clients = new List<Client>();

            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while (rdr.Read())
            {
                string name = rdr.GetString(0);
                string phone = rdr.GetString(1);
                int id = rdr.GetInt32(2);
                Client inputClient = new Client(name, phone, _id);
                inputClient.GetId();
                clients.Add(inputClient);
            }

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return inputClients;
        }
        public static Client Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id=@id;";

            MySqlParameter stylistId = new MySqlParameter("@id", id);
            cmd.Parameters.Add(stylistId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            string unassignedName = "";
            string unassignedPhone = "";
            int unassignedStylistId = 0;

            while (rdr.Read())
            {
                unassignedName = rdr.GetString(1);
                unassignedPhone = rdr.GetString(2);
                unassignedStylistId = (int) rdr.GetInt32(3);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            Client inputClient = new Client(unassignedName, unassignedPhone, unassignedStylistId);
            myClient(id);
            return inputClient;
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients WHERE id=@id;";

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
            cmd.CommandText = @"DELETE FROM clients;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
