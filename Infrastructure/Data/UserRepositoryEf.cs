using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepositoryEf : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepositoryEf(ApplicationContext context)
        {
            _context = context;
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User user)
        {
            _context.SaveChanges();
        }

        public User? GetUserByUserName(string userName)
        {
            return _context.Users.SingleOrDefault(p => p.Name == userName);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
