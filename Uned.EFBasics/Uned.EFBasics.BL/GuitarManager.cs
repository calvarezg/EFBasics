using System;
using Uned.EFBasics.DA;

namespace Uned.EFBasics.BL
{
    public class GuitarManager
    {
        private GuitarDataAccess DataAccess { get; set; }

        public void AddGuitar(Guitar guitar)
        {
            var currentDate = DateTime.Now;
            guitar.AddHistory("The guitar was created", currentDate);
            DataAccess.AddGuitar(guitar);
        }

        public void UpdateGuitar(long id, Guitar guitar)
        {
            var currentDate = DateTime.Now;
            guitar.AddHistory("The guitar was updated", currentDate);
            DataAccess.UpdateGuitar(id, guitar);
        }

        public GuitarManager()
        {
            DataAccess = new GuitarDataAccess();
        }
    }
}
