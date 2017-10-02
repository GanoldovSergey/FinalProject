using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public User GetById(int id)
        {
            return context.Set<User>().FirstOrDefault(x => x.Id == id);
        }

        public User GetByEmail(string email)
        {
            return context.Set<User>().FirstOrDefault(x => x.Email == email);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Set<User>();
        }

        public bool IsUserExists(string email)
        {
            User user = context.Set<User>().FirstOrDefault(x => x.Email == email);
            return (user != null);
        }

        public void Create(User entity)
        {
            context.Set<User>().Add(entity);
            context.SaveChanges();
        }

        public void Update(User entity)
        {
            User userToUpdate = context.Set<User>().FirstOrDefault(x => x.Id == entity.Id);
            context.Entry(userToUpdate).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            User user = context.Set<User>().FirstOrDefault(x => x.Id == entity.Id);
            context.Set<User>().Remove(user);
            context.SaveChanges();
        }
    }
}
