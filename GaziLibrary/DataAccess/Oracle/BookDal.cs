using GaziLibrary.Entities.Concrete;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Oracle
{
    public class BookDal
    {
        OracleRepository _repository;
        OracleConnection _connection;
        OracleCommand _command;

        public BookDal()
        {
            _command = new OracleCommand();
            _connection = Context.Connection();
            _repository = new OracleRepository();
        }

        public void Add(Book book)
        {
            _repository.Add($"INSERT INTO Books(Name, NumberOfPage, Image, Status, AuthorId, TypeId) " +
                            $"VALUES('{book.Name}', '{book.NumberOfPage}', '{book.Image}', '{book.Status}')," +
                            $" '{book.AuthorId}', '{book.TypeId}'");
        }
        public void Delete(int id)
        {
            _repository.Add($"DELETE FROM Books WHERE Id == {id}");
        }
        public void Update(Book book)
        {
            _repository.Add($"UPDATE Books SET Name = {book.Name}, NumberOfPage = {book.NumberOfPage}, Status = {book.Status}" +
                            $", Image = {book.Image}, AuthorId = {book.AuthorId}, TypeId = {book.TypeId} Where Id = {book.Id}");
        }
        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT * FROM Books";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                Book book = new Book
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    Name = rdr["FirstName"].ToString(),
                    Image = rdr["LastName"].ToString(),
                    NumberOfPage = Convert.ToInt32(rdr["NumberOfPage"]),
                    Status = Convert.ToBoolean(rdr["LastName"]),
                    AuthorId = Convert.ToInt32(rdr["AuthorId"]),
                    TypeId = Convert.ToInt32(rdr["TypeId"])
                };
                books.Add(book);
            }
            return books;
        }
        public Book GetById(int id)
        {
            Book book = new Book();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT * FROM Books WHERE Id = {id}";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                Book bk = new Book
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    Name = rdr["FirstName"].ToString(),
                    Image = rdr["LastName"].ToString(),
                    NumberOfPage = Convert.ToInt32(rdr["NumberOfPage"]),
                    Status = Convert.ToBoolean(rdr["LastName"]),
                    AuthorId = Convert.ToInt32(rdr["AuthorId"]),
                    TypeId = Convert.ToInt32(rdr["TypeId"])
                };
                book = bk;
            }
            return book;
        }
    }
}
