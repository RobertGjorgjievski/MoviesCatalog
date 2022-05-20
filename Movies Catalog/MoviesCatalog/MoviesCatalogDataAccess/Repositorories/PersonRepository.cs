using MoviesCatalogDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesCatalogDataAccess.Repositorories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly MovieContext _context;
        public PersonRepository(MovieContext contex)
        {
            _context = contex;
        }

        public List<Person> GetAll()
        {
            return _context.People.ToList();
            
        }

        public Person GetById(int id)
        {
           return _context.People.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Person entity)
        {
           _context.People.Add(entity);
           _context.SaveChanges();
           return entity.Id;
        }

        public void Update(Person entity)
        {
           var person = _context.People.FirstOrDefault(x => x.Id == entity.Id);
            if (person != null)
            {
                person.FullName = entity.FullName;
            }
            _context.SaveChanges();
        }
        public void Delete(Person entity)
        {
            var person = _context.People.FirstOrDefault(p => p.Id == entity.Id);
            if (person != null)
            {
                _context.People.Remove(person);
            }
            _context.SaveChanges();
        }
    }
}
