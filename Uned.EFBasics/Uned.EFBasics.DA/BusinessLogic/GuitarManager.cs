using System;
using System.Collections.Generic;
using Uned.EFBasics.DataAccess;
using Uned.EFBasics.Model;

namespace Uned.EFBasics.BusinessLogic
{
    public class GuitarManager
    {
        private GuitarRepository DataAccess { get; set; }

        public void AddGuitar(Guitar guitar)
        {
            var currentDate = DateTime.Now;
            guitar.AddHistory(new GuitarHistory() { Description = "The guitar was created", Date = currentDate });
            DataAccess.AddGuitar(guitar);
        }

        public void UpdateGuitarNameAndHistory(long id, Guitar guitar)
        {
            var currentDate = DateTime.Now;
            guitar.AddHistory(new GuitarHistory() { Description = "The guitar was updated", Date = currentDate });
            DataAccess.UpdateGuitarNameAndHistory(id, guitar);
        }

        public Guitar GetById(long id)
        {
            return DataAccess.GetGuitar(id);
        }

        public Guitar GetByIdIncludingLog(long id)
        {
            return DataAccess.GetGuitarIncludingLog(id);
        }

        public List<Guitar> GetGuitarByCreatedBefore(DateTime date)
            => DataAccess.GetGuitarByCreatedBefore(date);

        public GuitarManager()
        {
            DataAccess = new GuitarRepository();
        }
    }
}
