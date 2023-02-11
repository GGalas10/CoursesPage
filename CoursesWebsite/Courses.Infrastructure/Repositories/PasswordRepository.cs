﻿using Courses.Core.Models;
using Courses.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Infrastructure.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly CoursesDbContext _context;
        public PasswordRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task<Password> GetByIdAsync(Guid id)
            =>await Task.FromResult(_context.Password.FirstOrDefault(p=>p.Id == id));
        public async Task CreateAsync(Password password)
        {
            await Task.FromResult(_context.Password.Add(password));
            if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database cannot save date");
        }
        public async Task UpdateAsync(Password password)
        {
            var pass = await Task.FromResult(_context.Password.FirstOrDefault(p=>p.Id == password.Id));
            pass.SetPassword(password.NormalizedPassword);
            _context.Update(pass);
            if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database cannot save date");
        }
    }
}