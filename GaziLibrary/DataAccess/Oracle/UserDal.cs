using GaziLibrary.Entities.Concrete;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Oracle
{
    public class UserDal
    {
        OracleRepository _repository;
        OracleConnection _connection;
        OracleCommand _command;

        public UserDal()
        {
            _command = new OracleCommand();
            _connection = Context.Connection();
            _repository = new OracleRepository();
        }

        public void Add(User user)
        {
            _repository.Add($"INSERT INTO Users(FirstName, LastName, Status, UserName, Password, Email, PositionId) " +
                            $"VALUES('{user.FirstName}', '{user.LastName}', '{user.Status}', '{user.UserName}', " +
                            $"'{user.Password}', '{user.Email}', '{user.PositionId}')");
        }
        public void Delete(int id)
        {
            _repository.Add($"DELETE FROM Users WHERE Id == {id}");
        }
        public void Update(User user)
        {
            _repository.Add($"UPDATE Users SET FirstName = {user.FirstName}, LastName = {user.LastName}, " +
                            $"Status = {user.Status}, UserName = {user.UserName}, Password = {user.Password}, " +
                            $"Email = {user.Email}, PositionId = {user.PositionId} Where Id = {user.Id}");
        }
        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT * FROM Users";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                User user = new User
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    PositionId = Convert.ToInt32(rdr["PositionId"]),
                    FirstName = rdr["FirstName"].ToString(),
                    LastName = rdr["LastName"].ToString(),
                    UserName = rdr["UserName"].ToString(),
                    Password = rdr["Password"].ToString(),
                    Email = rdr["Email"].ToString(),
                    Status = Convert.ToBoolean(rdr["UserName"])
                };
                users.Add(user);
            }
            return users;
        }
        public User GetById(int id)
        {
            User user = new User();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT * FROM Users WHERE Id = {id}";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                User usr = new User
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    PositionId = Convert.ToInt32(rdr["PositionId"]),
                    FirstName = rdr["FirstName"].ToString(),
                    LastName = rdr["LastName"].ToString(),
                    UserName = rdr["UserName"].ToString(),
                    Password = rdr["Password"].ToString(),
                    Email = rdr["Email"].ToString(),
                    Status = Convert.ToBoolean(rdr["UserName"])
                };
                user = usr;
            }
            return user;
        }
    }
}
