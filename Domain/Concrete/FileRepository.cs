using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class FileRepository : IFileRepository
    {
        private readonly DbContext context;

        public FileRepository(DbContext context)
        {
            this.context = context;
        }

        public File GetById(int id)
        {
            return context.Set<File>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<File> GetByName(string name)
        {
            return context.Set<File>().Where(x => x.Name == name);
        }

        public IEnumerable<File> GetAll()
        {
            return context.Set<File>();
        }

        public void Create(File entity)
        {
            context.Set<File>().Add(entity);
            context.SaveChanges();
        }

        public void Update(File entity)
        {
            if (entity == null) return;

            File fileToUpdate = context.Set<File>().FirstOrDefault(x => x.Id == entity.Id);
            context.Entry(fileToUpdate).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        public void Delete(File entity)
        {
            File file = context.Set<File>().FirstOrDefault(x => x.Id == entity.Id);
            context.Set<File>().Remove(file);
            context.SaveChanges();
        }
    }
}
