﻿using Application.Repositories;
using Domain.Entities.Common;
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {

        private readonly OnionArchitecture_DbContext _context;

        public ReadRepository(OnionArchitecture_DbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking=true)
        {
            var query = Table.AsQueryable();

            if(!tracking)
            {
                query = Table.AsNoTracking();
            }

           return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {

            //return await Table.FindAsync(Guid.Parse(id));

                var query=   Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(data => data.Id == Convert.ToInt32(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
             var query=   Table.AsQueryable();

            if (!tracking)
            {
                query = Table.AsNoTracking();
            }


            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {

            var query= Table.Where(method);

            if (!tracking)
            {
                query = Table.AsNoTracking();
            }

            return query;
        }
    }
}
