﻿using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}
