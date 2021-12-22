using GaziLibrary.Entities.Concrete;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Oracle
{
    public class AuthorDal
    {
        OracleRepository _repository;
        OracleConnection _connection;
        OracleCommand _command;

        public AuthorDal()
        {
            _command = new OracleCommand();
            _connection = Context.Connection();
            _repository = new OracleRepository();
        }

        public void Add(Author author)
        {
            _repository.Add($"INSERT INTO Authors(FirstName, LastName, Status) " +
                            $"VALUES('{author.FirstName}', '{author.LastName}', '{author.Status}')");
        }
        public void Delete(int id)
        {
            _repository.Add($"DELETE FROM Authors WHERE Id == {id}");
        }
        public void Update(Author author)
        {
            _repository.Add($"UPDATE Authors SET FirstName = {author.FirstName}, LastName = {author.LastName}, " +
                            $"Status = {author.Status} Where Id = {author.Id}");
        }
        public List<Author> GetAll()
        {
            List<Author> authors = new List<Author>();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT Id, FirstName, LastName FROM Authors";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                Author author = new Author
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    FirstName = rdr["FirstName"].ToString(),
                    LastName = rdr["LastName"].ToString()
                };
                authors.Add(author);
            }
            return authors;
        }
        public Author GetById(int id)
        {
            Author author = new Author();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT Id, FirstName, LastName FROM Authors WHERE Id = {id}";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                Author athr = new Author
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    FirstName = rdr["FirstName"].ToString(),
                    LastName = rdr["LastName"].ToString()
                };
                author = athr;
            }
            return author;
        }
    }
}
