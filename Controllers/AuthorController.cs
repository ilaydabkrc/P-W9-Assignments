using Microsoft.AspNetCore.Mvc;
using Week9.ViewModels;
using Week9.Models;

namespace KutuphaneProjesi.Controllers
{
    public class AuthorController : Controller
    {
        private static List<Author> authors = new List<Author>
        {
            new Author { Id = 1, FirstName = "George", LastName = "Orwell", DateOfBirth = new DateTime(1903, 6, 25) },
            new Author { Id = 2, FirstName = "Fyodor", LastName = "Dostoyevsky", DateOfBirth = new DateTime(1821, 11, 11) }
        };

        public IActionResult List()
        {
            var authorViewModels = authors.Select(author => new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth
            }).ToList();

            return View(authorViewModels);
        }

        // Static metod ekledik ki BookController erişebilsin
        public static List<Author> GetAuthors()
        {
            return authors;
        }

        public IActionResult Details(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);
            if (author == null) return NotFound();

            var authorViewModel = new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth
            };

            return View(authorViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    Id = authors.Max(a => a.Id) + 1,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth
                };

                authors.Add(author);
                return RedirectToAction("List");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);
            if (author == null) return NotFound();

            var authorViewModel = new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth
            };

            return View(authorViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = authors.FirstOrDefault(a => a.Id == model.Id);
                if (author != null)
                {
                    author.FirstName = model.FirstName;
                    author.LastName = model.LastName;
                    author.DateOfBirth = model.DateOfBirth;
                }

                return RedirectToAction("List");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                authors.Remove(author);
            }

            return RedirectToAction("List");
        }
    }
}
