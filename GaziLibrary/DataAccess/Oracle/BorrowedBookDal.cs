using GaziLibrary.Entities.Concrete;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.DataAccess.Oracle
{
    public class BorrowedBookDal
    {
        OracleRepository _repository;
        OracleConnection _connection;
        OracleCommand _command;

        public BorrowedBookDal()
        {
            _command = new OracleCommand();
            _connection = Context.Connection();
            _repository = new OracleRepository();
        }

        public void Add(BorrowedBook borrowedBook)
        {
            _repository.Add($"INSERT INTO BorrowedBooks(BorrowDate, ReturnDate, UserId, BookId, Status) " +
                            $"VALUES('{borrowedBook.BorrowDate}', '{borrowedBook.ReturnDate}', '{borrowedBook.UserId}'" +
                            $", '{borrowedBook.BookId}', '{borrowedBook.Status}')");
        }
        public void Delete(int id)
        {
            _repository.Add($"DELETE FROM BorrowedBooks WHERE Id == {id}");
        }
        public void Update(BorrowedBook borrowedBook)
        {
            _repository.Add($"UPDATE BorrowedBooks SET Status = {borrowedBook.Status} Where Id = {borrowedBook.Id}");
        }
        public List<BorrowedBook> GetAll()
        {
            List<BorrowedBook> borrowedBooks = new List<BorrowedBook>();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT * FROM BorrowedBooks";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                BorrowedBook borrowedBook = new BorrowedBook
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    BookId = Convert.ToInt32(rdr["BookId"]),
                    UserId = Convert.ToInt32(rdr["UserId"]),
                    Status = Convert.ToBoolean(rdr["Status"]),
                    BorrowDate = Convert.ToDateTime(rdr["BorrowDate"]),
                    ReturnDate = Convert.ToDateTime(rdr["ReturnDate"])
                };
                borrowedBooks.Add(borrowedBook);
            }
            return borrowedBooks;
        }
        public BorrowedBook GetById(int id)
        {
            BorrowedBook borrowedBook = new BorrowedBook();
            _command.Connection = _connection;
            _command.CommandText = $"SELECT * FROM BorrowedBooks WHERE Id = {id}";
            OracleDataReader rdr = _command.ExecuteReader();
            while (rdr.Read())
            {
                BorrowedBook book = new BorrowedBook
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    BookId = Convert.ToInt32(rdr["BookId"]),
                    UserId = Convert.ToInt32(rdr["UserId"]),
                    Status = Convert.ToBoolean(rdr["Status"]),
                    BorrowDate = Convert.ToDateTime(rdr["BorrowDate"]),
                    ReturnDate = Convert.ToDateTime(rdr["ReturnDate"])
                };
                borrowedBook = book;
            }
            return borrowedBook;
        }
    }
}
