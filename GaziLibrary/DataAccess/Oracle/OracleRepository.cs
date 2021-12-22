using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Oracle
{
    public class OracleRepository
    {
        OracleConnection _connection;
        OracleCommand _command;
        public OracleRepository()
        {
            _connection = Context.Connection();
            _command = new OracleCommand();
        }

        public void Add(string query)
        {
            _command.Connection = _connection;
            _command.CommandText = query;
            _command.ExecuteNonQuery();
        }
        public void Delete(string query)
        {
            _command.Connection = _connection;
            _command.CommandText = query;
            _command.ExecuteNonQuery();
        }
        public void Update(string query)
        {
            _command.Connection = _connection;
            _command.CommandText = query;
            _command.ExecuteNonQuery();
        }
    }
}
