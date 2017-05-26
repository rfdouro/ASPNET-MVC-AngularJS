using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApp01.Models
{
    [Table("Filhos")]
    public class Filho
    {
        [Key]
        public long id { get; set; }
        public string nome { get; set; }

        public virtual Pessoa pai { get; set; }
    }
}