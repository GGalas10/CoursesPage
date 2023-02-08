﻿using APICore.Object_Value;
using Courses.Core.Models;
using Courses.Core.Repositories;
using Courses.Core.Value_Object;
using Courses.Infrastructure.Extensions;

namespace Courses.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly CoursesDbContext _context;
        public UserRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetByIdAsync(Guid id)
        => await Task.FromResult(_context.Users.FirstOrDefault(u=>u.Id==id));
        
        public async Task<User> GetByLoginAsync(Name login)
        {
            var user = await Task.FromResult(_context.Users.FirstOrDefault(u=>u.Login == login));
            if (user == null)
                throw new Exception("Incorrect login credentials");
            return user;
        }
        public async Task<User> GetByEmailAsync(Email email)
        {
            var user = await Task.FromResult(_context.Users.FirstOrDefault(u => u.Email == email));
            if (user == null)
                throw new Exception("Incorrect login credentials");
            return user;
        }
        public async Task RegisterAsync(User user)
        {
            await Task.FromResult(_context.Users.Add(user));
            if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception($"Register can't be done.\nDatabase do not save value");
        }
        public async Task DeleteAsync(Guid id)
        {
            var user = await this.GetOrFailByIdAsync(id);
            user.SetState(State.Deleted);
            if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database do not save value");
        } 
        public async Task UpdateAsync(User user)
        {
            var changeduser = await this.GetOrFailByIdAsync(user.Id);
            changeduser.SetState(user.State);
            changeduser.SetEmail(user.Email);
            changeduser.SetLogin(user.Login);
            changeduser.SetUserName(user.UserName);
            changeduser.SetPassword(user.Password);
            foreach(var course in user.PurchasedCourses)
            {
                changeduser.CoursesBuy(course);
            }
            _context.Update(changeduser);
            if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database do not save value");
        }

    }
}