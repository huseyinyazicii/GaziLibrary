using GaziLibrary.Entities.Concrete;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Oracle
{
    public class TypeDal
    {
        OracleRepository _repository;
        OracleConnection _connection;
        OracleCommand _command;

        public TypeDal()
        {
            _command = new OracleCommand();
            _connection = Context.Connection();
            _repository = new OracleRepository();
        }

        public void Add(Entities.Concrete.Type type)
        {
            _repository.Add($"INSERT INTO Types(Name, Status) " +
                            $"VALUES('{type.Name}', '{type.Status}')");
        }
        public void Delete(int id)
        {
            _repository.Add($"DELETE FROM Types WHERE Id == {id}");
        }
        public void Update(Entities.Concrete.Type type)
        {
            _repository.Add($"UPDATE Types SET Name = {type.Name}, Status = {type.Status} Where Id = {type.Id}");
        }
        public List<Entities.Concrete.Type> GetAll()
        {
            List<Entities.Concrete.Type> types = new List<Entities.Concrete.Type>();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT * FROM Types";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                Entities.Concrete.Type type = new Entities.Concrete.Type
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    Name = rdr["Name"].ToString(),
                    Status = Convert.ToBoolean(rdr["LastName"])
                };
                types.Add(type);
            }
            return types;
        }
        public Entities.Concrete.Type GetById(int id)
        {
            Entities.Concrete.Type type = new Entities.Concrete.Type();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT * FROM Types WHERE Id = {id}";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                Entities.Concrete.Type ty = new Entities.Concrete.Type
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    Name = rdr["Name"].ToString(),
                    Status = Convert.ToBoolean(rdr["LastName"])
                };
                type = ty;
            }
            return type;
        }
    }
}
