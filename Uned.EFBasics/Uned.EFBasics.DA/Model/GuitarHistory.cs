using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uned.EFBasics.Model
{
    [Table("GuitarLog")]
    public class GuitarHistory
    {       
        [Key]
        [Column("GuitarLogId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public long GuitarId { get; set; }

    }
}
