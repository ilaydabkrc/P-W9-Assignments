using KutuphaneProjesi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Week9.Models;
using Week9.ViewModels;

namespace Week9.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private static List<Book> books = new List<Book>
        {

           new Book { Id = 1, Title = "1984", AuthorId = 1, Genre = "Distopya", PublishDate = new DateTime(1949, 6, 8), ISBN = "978-0-452-28423-4", CopiesAvailable = 5 },
           new Book { Id = 2, Title = "Suç ve Ceza", AuthorId = 2, Genre = "Roman", PublishDate = new DateTime(1866, 1, 1), ISBN = "978-0-486-45444-7", CopiesAvailable = 3 }


        };

        // AuthorController'daki static listeyi referans alıyoruz
        private List<Author> GetAuthors()
        {
            return AuthorController.GetAuthors();
        }

        public IActionResult List()
        {
            var authors = GetAuthors();
            var bookViewModels = books.Select(book => new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                AuthorName = authors.FirstOrDefault(a => a.Id == book.AuthorId)?.FirstName + " " + authors.FirstOrDefault(a => a.Id == book.AuthorId)?.LastName,
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable,




            }).ToList();
            return View(bookViewModels);


        }
        public IActionResult Details(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);   
            if (book == null)return NotFound();
            var authors = GetAuthors();
            var bookViewModel = new BookViewModel
            {
                Id = book.Id,
                Title= book.Title,
                AuthorId= book.AuthorId,
                AuthorName = authors.FirstOrDefault(a => a.Id == book.AuthorId)?.FirstName + " " + authors.FirstOrDefault(a => a.Id == book.AuthorId)?.LastName,
                Genre= book.Genre,
                PublishDate= book.PublishDate,
                ISBN = book.ISBN,
                CopiesAvailable= book.CopiesAvailable,



            };
            return View(bookViewModel);


        }
        public IActionResult Create()
        {
            ViewBag.Authors = GetAuthors(); ;
            return View();


        }
        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Id = books.Max(b => b.Id) + 1,
                    Title = model.Title,
                    AuthorId = model.AuthorId,
                    Genre = model.Genre,
                    PublishDate = model.PublishDate,
                    ISBN = model.ISBN,
                    CopiesAvailable = model.CopiesAvailable

                };

                books.Add(book);
                return RedirectToAction("List");

            }
            ViewBag.Authors =  GetAuthors(); ;
            return View(model);


        }

        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();

            var bookViewModel = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable
            };

            ViewBag.Authors =  GetAuthors(); ;
            return View(bookViewModel);
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = books.FirstOrDefault(b => b.Id == model.Id);
                if (book != null)
                {
                    book.Title = model.Title;
                    book.AuthorId = model.AuthorId;
                    book.Genre = model.Genre;
                    book.PublishDate = model.PublishDate;
                    book.ISBN = model.ISBN;
                    book.CopiesAvailable = model.CopiesAvailable;
                }

                return RedirectToAction("List");
            }

            ViewBag.Authors = GetAuthors(); ;
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }

            return RedirectToAction("List");
        }





    }
}
