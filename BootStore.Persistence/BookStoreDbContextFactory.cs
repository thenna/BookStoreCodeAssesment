using System;
using System.Collections.Generic;
using System.Text;
using BootStore.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BootStore.Persistence
{
    public class BookStoreDbContextFactory : DesignTimeDbContextFactoryBase<BookStoreContext>
    {
        protected override BookStoreContext CreateNewInstance(DbContextOptions<BookStoreContext> options)
        {
            return new BookStoreContext(options);
        }
    }
}