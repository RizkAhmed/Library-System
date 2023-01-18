using LibraryCRUD.Models;
using LibraryCRUD.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCRUD.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IToastNotification _toastNotification;
        private List<string> _allowedExtentions = new List<string> { ".png", ".jpeg", ".jpg" };
        private int _maxCoverSize = 1048576;
        //private static IEnumerable<Author> Authors = _context.Authors.OrderBy(o => o.Name).ToListAsync();
        //private static IEnumerable<Category> Categories =  _context.categories.OrderBy(o => o.Name).ToListAsync();
        public BookController(AppDbContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        private bool ForamtValidation(IFormFile cover)
        {
            if (!_allowedExtentions.Contains(Path.GetExtension(cover.FileName).ToLower()))
            {
                ModelState.AddModelError("Cover", "Invalid image format only ( JPG, JPEG, PNG )");
                return true;
            }
            return false;
        }
        private bool SizeValidation(IFormFile cover)
        {
            if (cover.Length > _maxCoverSize)
            {
                ModelState.AddModelError("Cover", "Cover can't be more than 1 Mb");
                return true;
            }
            return false;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var books = await _context.books.Include(b => b.Author).Include(b => b.Category).OrderByDescending(o=>o.Rate).ToListAsync();

            return View(books);
        }
        public async Task<IActionResult> Create()
        {
            var ViewModel = new BookFormViewModel()
            {
                Authors = await _context.Authors.OrderBy(o => o.Name).ToListAsync(),
                Categories = await _context.categories.OrderBy(o => o.Name).ToListAsync()
            };
            return View("BookForm", ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookFormViewModel model)
        {
            model.Authors = await _context.Authors.OrderBy(o => o.Name).ToListAsync();
            model.Categories = await _context.categories.OrderBy(o => o.Name).ToListAsync();
            if (!ModelState.IsValid)
            {
                return View("BookForm", model);
            }
            var files = Request.Form.Files;
            if (!files.Any())
            {
                ModelState.AddModelError("Cover", "Please add cover");
                return View("BookForm", model);
            }
            var cover = files.FirstOrDefault();

            if (ForamtValidation(cover))
                return View("BookForm", model);


            if (SizeValidation(cover))
                return View("BookForm", model);

            using var dataStream = new MemoryStream();
            await cover.CopyToAsync(dataStream);
            var book = new Book()
            {
                Title = model.Title,
                Year = model.Year,
                Rate = model.Rate,
                Description = model.Description,
                Cover = dataStream.ToArray(),
                AuthorId = model.AuthorId,
                CategoryId = model.CategoryId
            };
            _context.books.Add(book);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("Book added seccessfully");

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var book = await _context.books.FindAsync(id);
            if (book == null)
                return NotFound();
            var model = new BookFormViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Year = book.Year,
                Rate = book.Rate,
                Description = book.Description,
                Cover = book.Cover,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                Authors = await _context.Authors.OrderBy(o => o.Name).ToListAsync(),
                Categories = await _context.categories.OrderBy(o => o.Name).ToListAsync()
            };
            return View("BookForm", model);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(BookFormViewModel model)
        {
            model.Authors = await _context.Authors.OrderBy(o => o.Name).ToListAsync();
            model.Categories = await _context.categories.OrderBy(o => o.Name).ToListAsync();
            if (!ModelState.IsValid)
                return View("BookForm", model);
            var book = _context.books.Find(model.Id);
            
            if (book == null)
                return NotFound();
            var files = Request.Form.Files;
            if (files.Any())
            {
                var cover = files.FirstOrDefault();

                using var dataStream = new MemoryStream();
                await cover.CopyToAsync(dataStream);
                //if validation faill that return the old image -->
                model.Cover = book.Cover;

                if (ForamtValidation(cover))
                    return View("BookForm", model);


                if (SizeValidation(cover))
                    return View("BookForm", model);
                book.Cover = dataStream.ToArray();
            }
            book.Title = model.Title;
            book.Year = model.Year;
            book.Rate = model.Rate;
            book.Description = model.Description;
            book.AuthorId = model.AuthorId;
            book.CategoryId = model.CategoryId;

            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("Book updated seccessfully");

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var book = await _context.books.Include(b
                => b.Author).Include(b => b.Category).SingleOrDefaultAsync(b => b.Id == id);
            if (book == null)
                return NotFound();
            return View(book);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var book = await _context.books.FindAsync(id);
            if (book == null)
                return NotFound();
            _context.books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }


    }
}
