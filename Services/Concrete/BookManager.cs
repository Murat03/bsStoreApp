﻿using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;

        public BookManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Book CreateOneBook(Book book)
        {
            if(book is null)
                throw new ArgumentNullException(nameof(book));

            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);

            if (entity is null)
                throw new Exception($"Book with id:{id} could not found.");

            _manager.Book.DeleteOneBook(entity);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            var books = _manager.Book.GetAllBooks(trackChanges);

            return books;
        }

        public Book GetOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);

            if (entity is null)
                throw new Exception($"Book with id:{id} could not found.");

            return entity;
        }

        public void UpdateOneBook(int id, Book book, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);

            if (entity is null)
                throw new Exception($"Book with id:{id} could not found.");

            if (book is null)
                throw new ArgumentNullException(nameof(book));
            
            entity.Title = book.Title;
            entity.Price = book.Price;

            _manager.Book.UpdateOneBook(entity);
            _manager.Save(); 
        }
    }
}