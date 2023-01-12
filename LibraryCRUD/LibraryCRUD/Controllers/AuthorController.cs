using LibraryCRUD.Models;
using LibraryCRUD.ViewModels;
using Microsoft.AspNetCore.Hosting;
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
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IToastNotification _toastNotification;
        private readonly IHostingEnvironment _env;


        private List<string> _allowedExtentions = new List<string> { ".png", ".jpeg", ".jpg" };
        private int _maxCoverSize = 1048576;
        public AuthorController(AppDbContext context, IToastNotification toastNotification, IHostingEnvironment env)
        {
            _context = context;
            _toastNotification = toastNotification;
            _env = env;
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
        public static byte[] imageConversion(string imageName)
        {


            //Initialize a file stream to read the image file
            FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);

            //Initialize a byte array with size of stream
            byte[] imgByteArr = new byte[fs.Length];

            //Read data from the file stream and put into the byte array
            fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));

            //Close a file stream
            fs.Close();

            return imgByteArr;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _context.Authors.OrderBy(o => o.Name).ToListAsync();
            ViewBag.image = imageConversion("wwwroot/Images/ApsImage.png");
            return View(authors);
        }
        public async Task<IActionResult> Create()
        {
            var model = new AuthorFormViewModel();
            return View("AuthorForm",model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("AuthorForm", model);
            }
            var files = Request.Form.Files;
            if (!files.Any())
            {
                ModelState.AddModelError("Image", "Please add Image");
                return View("AuthorForm", model);
            }
            var image = files.FirstOrDefault();

            if (ForamtValidation(image))
                return View("AuthorForm", model);


            if (SizeValidation(image))
                return View("AuthorForm", model);

            using var dataStream = new MemoryStream();
            await image.CopyToAsync(dataStream);
            var author = new Author()
            {
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                Description = model.Description,
                Image = dataStream.ToArray(),
            };
            _context.Authors.Add(author);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("Author added seccessfully");

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound();
            var model = new AuthorFormViewModel()
            {
                Id = author.Id,
                Name = author.Name,
                DateOfBirth = author.DateOfBirth,
                Description = author.Description,
                Image = (author.Image == null ? imageConversion("wwwroot/Images/ApsImage.png") : author.Image),
            };
            return View("AuthorForm", model);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(AuthorFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("AuthorForm", model);

            var author = await _context.Authors.FindAsync(model.Id);
            if (author == null)
                return NotFound();
            var files = Request.Form.Files;
            if(files.Any())
            {
                var image = files.FirstOrDefault();
                using var dataStream = new MemoryStream();
                await image.CopyToAsync(dataStream);
                //if validation was faill retutn old image with model -->
                model.Image = author.Image;

                if (ForamtValidation(image))
                    return View("AuthorForm", model);
                if (SizeValidation(image))
                    return View("AuthorForm", model);
                author.Image = dataStream.ToArray();
            }
            author.Name = model.Name;
            author.DateOfBirth = model.DateOfBirth;
            author.Description = model.Description;
            _context.SaveChanges();
            _toastNotification.AddSuccessToastMessage("Author updated seccessfully");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>Details(int id)
        {
            if (id == null)
                return BadRequest();
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound();
            var model = new AuthorFormViewModel()
            {
                Id = author.Id,
                Name = author.Name,
                DateOfBirth = author.DateOfBirth,
                Description = author.Description,
                Image = (author.Image == null ? imageConversion("wwwroot/Images/ApsImage.png") : author.Image),
                Books = await _context.books.Where(b => b.AuthorId == author.Id).ToListAsync()
            };
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound();
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return Ok();
        }
    }
}
