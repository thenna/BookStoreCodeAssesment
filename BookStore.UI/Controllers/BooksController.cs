using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Domain.Entities;
using BootStore.Persistence;
using Microsoft.AspNetCore.Authorization;
using BookStore.Application.Interfaces;
using BookStore.UI.Models;

namespace BookStore.UI.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.BookRepository.GetAll().ToListAsync()); ;
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _unitOfWork.BookRepository.Get(id);
            var author = _unitOfWork.BookAuthorRepository.GetBookAuthor(id);
            var category = _unitOfWork.BookCategoryRepository.GetBookCategory(id);
            BooksViewModel model = new BooksViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                Edition = book.Edition,
                Author = author.Author.AuthorName,
                Category = category.Category.CategoryName

            };

            return View(model);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BooksPostViewModel book)
        {
            if (ModelState.IsValid)
            {
                var bookPayloadEntity = new Book { Title = book.Title, Edition = book.Edition, Price = book.Price };
                var bookEntity = _unitOfWork.BookRepository.Add(bookPayloadEntity);
                
                var authorPayloadEntity = new Author { AuthorName = book.Author };
                var authorEntity = _unitOfWork.AuthorRepository.Add(authorPayloadEntity);

                var categoryPayloadEntity = new Category { CategoryName = book.Category };
                var categoryEntity = _unitOfWork.CategoryRepository.Add(categoryPayloadEntity);

                var categoryBookPayload = new BookCategory { BookId = bookEntity.Id, CategoryId = categoryEntity.Id };
                _unitOfWork.BookCategoryRepository.Add(categoryBookPayload);

                var AuthorBookPayload = new BookAuthor { BookId = bookEntity.Id, AuthorId = authorEntity.Id };
                _unitOfWork.BookAuthorRepository.Add(AuthorBookPayload);

                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _unitOfWork.BookRepository.Get(id);
            var author = _unitOfWork.BookAuthorRepository.GetBookAuthor(id);
            var category = _unitOfWork.BookCategoryRepository.GetBookCategory(id);
            BookEditViewModel bookEditViewModel = new BookEditViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                Edition = book.Edition,
                Author = author.Author.AuthorName,
                Category = category.Category.CategoryName,
                AuthorId = author.AuthorId,
                CategoryId = category.CategoryId

            };
            return View(bookEditViewModel);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,BookEditViewModel book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var bookPayloadEntity = new Book {Id = book.Id, Title = book.Title, Edition = book.Edition, Price = book.Price };
                    _unitOfWork.BookRepository.Update(bookPayloadEntity);

                    var authorPayloadEntity = new Author {Id = book.AuthorId, AuthorName = book.Author };
                    _unitOfWork.AuthorRepository.Update(authorPayloadEntity);

                    var categoryPayloadEntity = new Category {Id  = book.CategoryId, CategoryName = book.Category };
                    _unitOfWork.CategoryRepository.Update(categoryPayloadEntity);

                    _unitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _unitOfWork.BookRepository.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var book = _unitOfWork.BookRepository.Get(id);
            var bookauthor = _unitOfWork.BookAuthorRepository.GetBookAuthor(id);
            var bookcategory = _unitOfWork.BookCategoryRepository.GetBookCategory(id);
            _unitOfWork.BookRepository.Remove(book);
            _unitOfWork.BookAuthorRepository.Remove(bookauthor);
            _unitOfWork.BookCategoryRepository.Remove(bookcategory);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //private bool BookExists(string id)
        //{
        //    return _context.Books.Any(e => e.Id == id);
        //}
    }
}
