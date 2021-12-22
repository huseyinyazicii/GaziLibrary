using GaziLibrary.Entities.Concrete;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Oracle
{
    public class PositionDal
    {
        OracleRepository _repository;
        OracleConnection _connection;
        OracleCommand _command;

        public PositionDal()
        {
            _command = new OracleCommand();
            _connection = Context.Connection();
            _repository = new OracleRepository();
        }

        public void Add(Position position)
        {
            _repository.Add($"INSERT INTO Positions(Name, Status) " +
                            $"VALUES('{position.Name}', '{position.Status}')");
        }
        public void Delete(int id)
        {
            _repository.Add($"DELETE FROM Positions WHERE Id == {id}");
        }
        public void Update(Position position)
        {
            _repository.Add($"UPDATE Positions SET Name = {position.Name}, Status = {position.Status}, Where Id = {position.Id}");
        }
        public List<Position> GetAll()
        {
            List<Position> positions = new List<Position>();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT * FROM Positions";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                Position position = new Position
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    Name = rdr["Name"].ToString(),
                    Status = Convert.ToBoolean(rdr["LastName"])
                };
                positions.Add(position);
            }
            return positions;
        }
        public Position GetById(int id)
        {
            Position position = new Position();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT * FROM Positions WHERE Id = {id}";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                Position pst = new Position
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    Name = rdr["Name"].ToString(),
                    Status = Convert.ToBoolean(rdr["LastName"])
                };
                position = pst;
            }
            return position;
        }
    }
}
