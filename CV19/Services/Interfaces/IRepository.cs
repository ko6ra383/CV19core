using CV19.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CV19.Services.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T Get(int id) => GetAll().FirstOrDefault(item => item.Id == id);
        void Update(int id, T item);
        bool Remove(T item);
    }
}
