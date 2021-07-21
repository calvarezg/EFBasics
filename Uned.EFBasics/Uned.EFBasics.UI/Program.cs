using System;
using Uned.EFBasics.BusinessLogic;
using Uned.EFBasics.Model;

namespace Uned.EFBasics.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var guitar = new Guitar()
            {
                Name = "Stratocaster",
                Description = "Test description",
                Year = 2015,
                ImagePath = "/img/img-4.jpg",
                Price = 2000
            };

            GuitarManager manager = new GuitarManager();
            manager.AddGuitar(guitar);
            manager.UpdateGuitarNameAndHistory(guitar.GuitarId, guitar);           
            var list = manager.GetGuitarsCreatedBefore(new DateTime(2021, 7, 18, 23, 10, 53));
            Console.WriteLine(list.Count);
        }
    }
}
