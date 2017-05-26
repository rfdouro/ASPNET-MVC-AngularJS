using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApp01.Models
{
    public class Pessoa
    {
        [Key]
        public long id { get; set; }
        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        public virtual ICollection<Filho> filhos { get; set; }
    }
}