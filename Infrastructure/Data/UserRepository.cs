﻿using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        static int LastIdAssigned = 0;
        static List<User> users = [];
        public User Add(User user)
        {
            user.Id = ++LastIdAssigned;
            users.Add(user);
            return user;
        }

        public void Delete(User user)
        {
            users.Remove(user);
        }

        public List<User> GetAll()
        {
            return users.ToList();
        }

        public User? GetById(int Id)
        {
            return users.FirstOrDefault(x => x.Id == Id);
        }

        public User? GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            var obj = users.FirstOrDefault(x => x.Id == user.Id)
                ?? throw new NotFoundException(nameof(User), user.Id);

            obj.Name = user.Name;
        }
    }
}
