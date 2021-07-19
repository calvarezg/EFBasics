using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Uned.EFBasics.Model
{
    public class Guitar
    {
        [Key]
        public long GuitarId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public List<GuitarHistory> History { get; set; }

        public Guitar()
        {
            History = new List<GuitarHistory>();
        }

        public void AddHistory(GuitarHistory history)
        {
            History.Add(history);
        }
    }
}
