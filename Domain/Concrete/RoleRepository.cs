using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }

        public Role GetById(int? id)
        {
            return context.Set<Role>().FirstOrDefault(x => x.Id == id);
        }

        public Role GetByName(string name)
        {
            return context.Set<Role>().FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<Role> GetAll()
        {
            return context.Set<Role>();
        }

        public void Create(Role entity)
        {
            context.Set<Role>().Add(entity);
            context.SaveChanges();
        }

        public void Update(Role entity)
        {
            if (entity == null) return;

            Role roleToUpdate = context.Set<Role>().FirstOrDefault(x => x.Id == entity.Id);
            context.Entry(roleToUpdate).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        public void Delete(Role entity)
        {
            Role role = context.Set<Role>().FirstOrDefault(x => x.Id == entity.Id);
            context.Set<Role>().Remove(role);
            context.SaveChanges();
        }
    }
}
