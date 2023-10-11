﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Database
{
    public class DBConnector
    {
        private string _connectionString;

        public DBConnector(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddRecord(EmissionModel emission)
        {
            using (IDbConnection cnn = new SqliteConnection(_connectionString))
            {
                cnn.Open();
                using (IDbCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO EmissionsTbl (Source, Unit, Value, Location) VALUES (@Source, @Unit, @Value, @Location)";
                    cmd.Parameters.Add(new SqliteParameter("@Source", emission.Source));
                    cmd.Parameters.Add(new SqliteParameter("@Unit", emission.Unit));
                    cmd.Parameters.Add(new SqliteParameter("@Value", emission.Value));
                    cmd.Parameters.Add(new SqliteParameter("@Location", emission.Location));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
