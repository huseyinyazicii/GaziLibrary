using GaziLibrary.Entities.Concrete;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Oracle
{
    public class MessageDal
    {
        OracleRepository _repository;
        OracleConnection _connection;
        OracleCommand _command;

        public MessageDal()
        {
            _command = new OracleCommand();
            _connection = Context.Connection();
            _repository = new OracleRepository();
        }

        public void Add(Message message)
        {
            _repository.Add($"INSERT INTO Messages(Text, Date, UserId, Status) " +
                            $"VALUES('{message.Text}', '{message.Date}', '{message.UserID}', '{message.Status}')");
        }
        public void Delete(int id)
        {
            _repository.Add($"DELETE FROM Messages WHERE Id == {id}");
        }
        public void Update(Message message)
        {
            _repository.Add($"UPDATE Messages SET Status = {message.Status} Where Id = {message.Id}");
        }
        public List<Message> GetAll()
        {
            List<Message> messages = new List<Message>();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT * FROM Messages";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                Message message = new Message
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    UserID = Convert.ToInt32(rdr["UserID"]),
                    Text = rdr["Text"].ToString(),
                    Date = Convert.ToDateTime(rdr["LastName"]),
                    Status = Convert.ToBoolean(rdr["Status"])
                };
                messages.Add(message);
            }
            return messages;
        }
        public Message GetById(int id)
        {
            Message message = new Message();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT * FROM Messages WHERE Id = {id}";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                Message msg = new Message
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    UserID = Convert.ToInt32(rdr["UserID"]),
                    Text = rdr["Text"].ToString(),
                    Date = Convert.ToDateTime(rdr["LastName"]),
                    Status = Convert.ToBoolean(rdr["Status"])
                };
                message = msg;
            }
            return message;
        }
    }
}
