using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using XamEFCore.DataContext;
using XamEFCore.Models;

namespace XamEFCore.Services
{
    public class serviceAlbum
    {
        private readonly AppDbContext _context;

        public serviceAlbum() => _context = App.GetContext();

        public bool Create(Album entity)
        {
            bool created;

            try
            {
                _context.Albumes.Add(entity);                
                _context.SaveChanges();

                created = true;
            }
            catch (Exception)
            {
                throw;
            }

            return created;
        }

    }
}