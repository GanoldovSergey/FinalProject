using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IFileRepository: IRepository<File>
    {
        File GetById(int id);
        IEnumerable<File> GetByName(string name);
    }
}
