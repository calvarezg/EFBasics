using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Uned.EFBasics.Model;

namespace Uned.EFBasics.DataAccess
{
    public class GuitarDataAccess
    {
        public void AddGuitar(Guitar guitar)
        {
            using (var context = new MusicStoreContext())
            {
                context.Guitars.Add(guitar);
                context.SaveChanges();
            }
        }
        public Guitar GetGuitar(long id)
        {
            using(var context = new MusicStoreContext())
            {
                return GetById(id, context);
            }
        }
        public Guitar GetGuitarIncludingLog(long id)
        {
            using (var context = new MusicStoreContext())
            {
                return GetByIdIncludingLog(id, context);
            }
        }
        public List<Guitar> GetGuitarByCreatedBefore(DateTime date)
        {
            using (var context = new MusicStoreContext())
            {
                var query =
                    (from guitar in context.Guitars
                     join log in context.GuitarHistory
                         on guitar.GuitarId equals log.GuitarId
                     where log.Description.Contains("The guitar was created") && log.Date < date
                     select new Guitar()
                     {
                         GuitarId = guitar.GuitarId,
                         Name = guitar.Name
                     });
                return query.ToList();
            }
        }
        public void UpdateGuitarNameAndHistory(long guitarId, Guitar guitar)
        {
            using (var context = new MusicStoreContext())
            {
                var guitarToUpdate = GetById(guitarId, context);
                guitarToUpdate.Name = guitar.Name;
                foreach(var history in guitar.History)
                {
                    if (history.Id <= 0)
                        guitarToUpdate.AddHistory(history);
                }
                context.SaveChanges();
            }
        }
        private Guitar GetById(long id, MusicStoreContext context)
        {
            var query = from guitar in context.Guitars
                        where guitar.GuitarId == id
                        select guitar;
            
            return query.FirstOrDefault();
        }
        private Guitar GetByIdIncludingLog(long id, MusicStoreContext context)
        {
            var query = from guitar in context.Guitars.Include(a => a.History)
                        where guitar.GuitarId == id
                        select guitar;

            return query.FirstOrDefault();
        }
    }
}
