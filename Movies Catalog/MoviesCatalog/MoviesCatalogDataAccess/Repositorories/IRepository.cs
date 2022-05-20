using MoviesCatalogDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesCatalogDataAccess.Repositorories
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void Update(T entity);
        void Delete (T entity);
    }
}
