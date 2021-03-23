using CoreAracKiralama.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoreAracKiralama.Repositories
{//CRUD METHODLARI
    public class IRepository<T> where T : class, new()
    {
        readonly Context _context = new Context();
        /// <summary>
        /// Belirttiğiniz modelden List<T> döner.
        /// </summary>
        /// <returns>List<T></returns>
        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }
        /// <summary>
        /// Include işlemi yapar
        /// </summary>
        /// <param name="p">Birleştirmek istediğin tablonun adı</param>
        /// <returns>List<T></returns>
        public List<T> List(string p)
        {
            return _context.Set<T>().Include(p).ToList();
        }
        public List<T> List(string p1, string p2)
        {
            return _context.Set<T>().Include(p1).Include(p2).ToList();
        }

        /// <summary>
        /// Gönderdiğiniz nesneyi belirttiğiniz tabloya ekler.
        /// </summary>
        /// <param name="p">Gönderilen nesne</param>
        public void Create(T p)
        {
            _context.Set<T>().Add(p);
            _context.SaveChanges();
        }
        /// <summary>
        /// Gönderdiğiniz nesneyi belirttiğiniz tablodan siler.
        /// </summary>
        /// <param name="p">Gönderilen nesne</param>
        public void Delete(T p)
        {
            _context.Set<T>().Remove(p);
            _context.SaveChanges();
        }
        /// <summary>
        /// Gönderdiğiniz nesneyi belirttiğiniz tabloda günceller.
        /// </summary>
        /// <param name="p">Gönderilen nesne</param>
        public void Update(T p)
        {
            _context.Set<T>().Update(p);
            _context.SaveChanges();
        }
        /// <summary>
        /// Belirttiğiniz tabloda gönderdiğiniz parametre ile eşleşen nesneyi döner.
        /// </summary>
        /// <param name="p">Gönderilen Id</param>
        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

    }
}
