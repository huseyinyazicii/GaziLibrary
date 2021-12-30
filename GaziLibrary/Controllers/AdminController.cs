using AspNetCoreHero.ToastNotification.Abstractions;
using GaziLibrary.Business.Abstract;
using GaziLibrary.Entities.Concrete;
using GaziLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        INotyfService _notyf;
        IBookService _bookService;
        IBorrowedBookService _borrowedBookService;
        IUserService _userService;
        IMessageService _messageService;
        IAuthorService _authorService;
        ITypeService _typeService;
        IPositionService _positionService;
        public AdminController(INotyfService notyf, IBookService bookService, IBorrowedBookService borrowedBookService, IUserService userService, IMessageService messageService, IAuthorService authorService, ITypeService typeService, IPositionService positionService)
        {
            _notyf = notyf;
            _bookService = bookService;
            _borrowedBookService = borrowedBookService;
            _userService = userService;
            _messageService = messageService;
            _authorService = authorService;
            _typeService = typeService;
            _positionService = positionService;
        }

        // BOOKS
        public IActionResult Books()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new BookModel
            {
                Books = _bookService.GetAllByStatusWithFK().Data
            };
            return View(model);
        }
        public IActionResult AddBook()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            List<AuthorWithFullName> authorWithFullName = new List<AuthorWithFullName>();
            
            foreach (var author in _authorService.GetAllByStatus().Data)
            {
                AuthorWithFullName authorName = new AuthorWithFullName { Id = author.Id, FullName = author.FirstName + " " + author.LastName };
                authorWithFullName.Add(authorName);
            }
            var model = new BookModel
            {
                ImageBook = new ImageBook(),
                Authors = authorWithFullName,
                Types = _typeService.GetAllByStatus().Data
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddBook(ImageBook imageBook)
        {
            if (!ModelState.IsValid)
            {
                List<AuthorWithFullName> authorWithFullName = new List<AuthorWithFullName>();

                foreach (var author in _authorService.GetAllByStatus().Data)
                {
                    AuthorWithFullName authorName = new AuthorWithFullName { Id = author.Id, FullName = author.FirstName + " " + author.LastName };
                    authorWithFullName.Add(authorName);
                }
                var model = new BookModel
                {
                    ImageBook = imageBook,
                    Authors = authorWithFullName,
                    Types = _typeService.GetAllByStatus().Data
                };
                return View(model);
            }
            Book book = new Book();
            if(imageBook.Image != null)
            {
                var extension = Path.GetExtension(imageBook.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                imageBook.Image.CopyTo(stream);
                book.Image = newImageName;
            }
            else
            {
                book.Image = "DefaultBook.jpg";
            }
            book.Name = imageBook.Name;
            book.NumberOfPage = imageBook.NumberOfPage;
            book.AuthorId = imageBook.AuthorId;
            book.TypeId = imageBook.TypeId;
            book.Status = true;
            _bookService.Add(book);
            _notyf.Success("Kitap başarıyla eklendi", 3);
            return RedirectToAction("Books","Admin");
        }
        public IActionResult UpdateBook(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            List<AuthorWithFullName> authorWithFullName = new List<AuthorWithFullName>();

            foreach (var author in _authorService.GetAllByStatus().Data)
            {
                AuthorWithFullName authorName = new AuthorWithFullName { Id = author.Id, FullName = author.FirstName + " " + author.LastName };
                authorWithFullName.Add(authorName);
            }
            var book = _bookService.GetById(id).Data;
            var imageBook = new ImageBook {Id = book.Id, AuthorId = book.AuthorId, Name = book.Name, NumberOfPage = book.NumberOfPage, TypeId = book.TypeId };
            var model = new BookModel
            {
                ImageBook = imageBook,
                Authors = authorWithFullName,
                Types = _typeService.GetAllByStatus().Data
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateBook(ImageBook imageBook)
        {
            if (!ModelState.IsValid)
            {
                List<AuthorWithFullName> authorWithFullName = new List<AuthorWithFullName>();

                foreach (var author in _authorService.GetAllByStatus().Data)
                {
                    AuthorWithFullName authorName = new AuthorWithFullName { Id = author.Id, FullName = author.FirstName + " " + author.LastName };
                    authorWithFullName.Add(authorName);
                }
                var model = new BookModel
                {
                    ImageBook = imageBook,
                    Authors = authorWithFullName,
                    Types = _typeService.GetAllByStatus().Data
                };
                return View(model);
            }
            Book book = new Book();
            if (imageBook.Image != null)
            {
                var extension = Path.GetExtension(imageBook.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                imageBook.Image.CopyTo(stream);
                book.Image = newImageName;
            }
            else
            {
                book.Image = "DefaultBook.jpg";
            }
            book.Id = imageBook.Id;
            book.Name = imageBook.Name;
            book.NumberOfPage = imageBook.NumberOfPage;
            book.AuthorId = imageBook.AuthorId;
            book.TypeId = imageBook.TypeId;
            book.Status = true;
            _bookService.Update(book);
            _notyf.Warning("Kitap başarıyla güncellendi", 3);
            return RedirectToAction("Books", "Admin");
        }

        // BORROWEDBOOKS
        public IActionResult BorrowedBooks()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new BorrowedBookModel
            {
                BorrowedBooks = _borrowedBookService.GetAllByStatusWithFK().Data
            };
            return View(model);
        }
        public IActionResult OldBorrowedBooks()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new BorrowedBookModel
            {
                BorrowedBooks = _borrowedBookService.GetAllByStatus2WithFK().Data
            };
            return View(model);
        }
        public IActionResult RevokeBorrowedBook(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var borrowBook = _borrowedBookService.GetById(id).Data;
            borrowBook.Status = false;
            borrowBook.ReturnDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var book = _bookService.GetById(borrowBook.BookId).Data;
            book.Status = true;
            _bookService.Update(book);
            _borrowedBookService.Update(borrowBook);
            _notyf.Success("Kitap geri alındı.", 3);
            return RedirectToAction("BorrowedBooks", "Admin");
        }
        public IActionResult DeleteBorrowedBook(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var borrowBook = _borrowedBookService.GetById(id).Data;
            _borrowedBookService.Delete(borrowBook);
            _notyf.Error("Kayıt silindi.", 3);
            return RedirectToAction("OldBorrowedBooks", "Admin");
        }

        // Messages
        public IActionResult Messages()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new MessageModel
            {
                Messages = _messageService.GetAllByStatusWithFK().Data
            };
            return View(model);
        }
        public IActionResult AllMessages()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new MessageModel
            {
                Messages = _messageService.GetAllByStatus2WithFK().Data
            };
            return View(model);
        }
        public IActionResult DeleteMessage(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var message = _messageService.GetById(id).Data;
            message.Status = false;
            _messageService.Update(message);
            _notyf.Success("Mesaj okundu olarak işaretlendi.", 3);
            return RedirectToAction("Messages", "Admin");
        }
        public IActionResult DeletedMessage(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var message = _messageService.GetById(id).Data;
            _messageService.Delete(message);
            _notyf.Error("Mesaj silindi.", 3);
            return RedirectToAction("AllMessages", "Admin");
        }

        // Authors
        public IActionResult Authors()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var authors = _authorService.GetAllByStatus().Data;
            var authorsWithBooks = new List<AuthorWithBook>();
            foreach (var author in authors)
            {
                authorsWithBooks.Add(new AuthorWithBook
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    NumberOfBook = _bookService.NumberOfBooksByAuthor(author.Id).Data
                });
            }
            var model = new AuthorModel
            {
                AuthorWithBooks = authorsWithBooks
            };
            return View(model);
        }
        public IActionResult AddAuthor()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new AuthorModel
            {
                Author = new Author()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                var model = new AuthorModel
                {
                    Author = author
                };
                return View(model);
            }
            author.Status = true;
            _authorService.Add(author);
            _notyf.Success("Yeni yazar başarıyla eklendi.", 3);
            return RedirectToAction("Authors", "Admin");
        }
        public IActionResult UpdateAuthor(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new AuthorModel
            {
                Author = _authorService.GetById(id).Data
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                var model = new AuthorModel
                {
                    Author = author
                };
                return View(model);
            }
            author.Status = true;
            _authorService.Update(author);
            _notyf.Warning("Yazar başarıyla güncellendi.", 3);
            return RedirectToAction("Authors", "Admin");
        }
        public IActionResult DeleteAuthor(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var author = _authorService.GetById(id).Data;
            author.Status = false;
            _authorService.Update(author);
            _notyf.Error("Yazar başarıyla silindi.", 3);
            return RedirectToAction("Authors", "Admin");
        }

        // Types
        public IActionResult Types()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var types = _typeService.GetAllByStatus().Data;
            var typeWithBooks = new List<TypeWithBook>();
            foreach (var type in types)
            {
                typeWithBooks.Add(new TypeWithBook
                {
                    Id = type.Id,
                    Name = type.Name,
                    NumberOfBook = _bookService.NumberOfBooksByType(type.Id).Data
                });
            }
            var model = new TypeModel
            {
                TypeWithBooks = typeWithBooks
            };
            return View(model);
        }
        public IActionResult AddType()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new TypeModel
            {
                Type = new Entities.Concrete.Type()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddType(Entities.Concrete.Type type)
        {
            if (!ModelState.IsValid)
            {
                var model = new TypeModel
                {
                    Type = type
                };
                return View(model);
            }
            type.Status = true;
            _typeService.Add(type);
            _notyf.Success("Yeni tür başarıyla eklendi.", 3);
            return RedirectToAction("Types", "Admin");
        }
        public IActionResult UpdateType(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new TypeModel
            {
                Type = _typeService.GetById(id).Data
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateType(Entities.Concrete.Type type)
        {
            if (!ModelState.IsValid)
            {
                var model = new TypeModel
                {
                    Type = type
                };
                return View(model);
            }
            type.Status = true;
            _typeService.Update(type);
            _notyf.Success("Tür başarıyla güncellendi.", 3);
            return RedirectToAction("Types", "Admin");
        }
        public IActionResult DeleteType(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var type = _typeService.GetById(id).Data;
            type.Status = false;
            _typeService.Update(type);
            _notyf.Error("Tür başarıyla silindi.", 3);
            return RedirectToAction("Types", "Admin");
        }

        // Positions
        public IActionResult Positions()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            if (!CheckStaff())
            {
                return RedirectToAction("Books", "Admin");
            }
            var positions = _positionService.GetAllByStatus().Data;
            var positionWithUsers = new List<PositionWithUser>();
            foreach (var position in positions)
            {
                positionWithUsers.Add(new PositionWithUser
                {
                    Id = position.Id,
                    Name = position.Name,
                    NumberOfUsers = _userService.NumberOfUsersByPosition(position.Id).Data
                });
            }
            var model = new PositionModel
            {
                PositionWithUsers = positionWithUsers
            };
            return View(model);
        }
        public IActionResult AddPosition()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new PositionModel
            {
                Position = new Position()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddPosition(Position position)
        {
            if (!ModelState.IsValid)
            {
                var model = new PositionModel
                {
                    Position = position
                };
                return View(model);
            }
            position.Status = true;
            _positionService.Add(position);
            _notyf.Success("Yeni pozisyon başarıyla eklendi.", 3);
            return RedirectToAction("Positions", "Admin");
        }
        public IActionResult UpdatePosition(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new PositionModel
            {
                Position = _positionService.GetById(id).Data
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdatePosition(Position position)
        {
            if (!ModelState.IsValid)
            {
                var model = new PositionModel
                {
                    Position = position
                };
                return View(model);
            }
            position.Status = true;
            _positionService.Update(position);
            _notyf.Warning("Pozisyon başarıyla güncellendi.", 3);
            return RedirectToAction("Positions", "Admin");
        }
        public IActionResult DeletePosition(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var position = _positionService.GetById(id).Data;
            position.Status = false;
            _positionService.Update(position);
            _notyf.Error("Pozisyon başarıyla silindi.", 3);
            return RedirectToAction("Positions", "Admin");
        }

        // Statistic
        public IActionResult Statistic()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            if (!CheckStaff())
            {
                return RedirectToAction("Books", "Admin");
            }
            var model = new StatisticModel
            {
                NumberOfAuthors = _authorService.GetAllByStatus().Data.Count,
                NumberOfBooks = _bookService.GetAllByStatus().Data.Count,
                NumberOfBorrowedBooks = _borrowedBookService.GetAllByStatus().Data.Count,
                NumberOfMessages = _messageService.GetAll().Data.Count,
                NumberOfPositions = _positionService.GetAllByStatus().Data.Count,
                NumberOfTypes = _typeService.GetAllByStatus().Data.Count,
                NumberOfUsers = _userService.GetAllByStatus().Data.Count
            };
            return View(model);
        }

        // Users
        public IActionResult Users()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            if (!CheckStaff())
            {
                return RedirectToAction("Books", "Admin");
            }
            var model = new UserModel
            {
                Users = _userService.GetAllByStatusWithFK().Data
            };
            return View(model);
        }
        public IActionResult AddUser()
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new UserModel
            {
                User = new User(),
                Positions = _positionService.GetAllByStatus().Data
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                var model = new UserModel
                {
                    User = user,
                    Positions = _positionService.GetAllByStatus().Data
                };
                return View(model);
            }
            user.Status = true;
            _userService.Add(user);
            _notyf.Success("Yeni kullanıcı başarıyla eklendi.", 3);
            return RedirectToAction("Users", "Admin");
        }
        public IActionResult UpdateUser(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var model = new UserModel
            {
                User = _userService.GetById(id).Data,
                Positions = _positionService.GetAllByStatus().Data
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            user.Status = true;
            _userService.Update(user);
            _notyf.Warning("Kullanıcı güncellendi.", 3);
            return RedirectToAction("Users", "Admin");
        }
        public IActionResult DeleteUser(int id)
        {
            if (!CheckUser())
            {
                return RedirectToAction("Books", "User");
            }
            var user = _userService.GetById(id).Data;
            user.Status = false;
            _userService.Update(user);
            _notyf.Error("Kullanıcı başarıyla silindi.", 3);
            return RedirectToAction("Users", "Admin");
        }

        // Check User
        private bool CheckUser()
        {
            if(HttpContext.Session.GetString("position") == "KULLANICI")
            {
                return false;
            }
            return true;
        }
        // Check Staff
        private bool CheckStaff()
        {
            if (HttpContext.Session.GetString("position") == "PERSONEL")
            {
                return false;
            }
            return true;
        }
    }
}