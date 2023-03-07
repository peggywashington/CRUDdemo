using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUDDemo.Data.Entities
{
    public class Movies
    {
        [Key]
        public string MovieName { get; set; }
        [Range(0, 5)]
        public int Rate { get; set; }
        public string Comment { get; set; }
        public string Picture { get; set; }
    }
}