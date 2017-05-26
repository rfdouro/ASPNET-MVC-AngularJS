using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApp01.Models
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("name=DBMVC01")
        {
            //Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBMVC01"].ConnectionString;
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet <Filho> Filhos
        {  
            get;  
            set;  
        }  
    }
}