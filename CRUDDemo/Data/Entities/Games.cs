using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUDDemo.Data.Entities
{
    public class Games
    {
        [Key]
        public string GameName { get; set; }
        public string Platform { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }
        public float Price { get; set; }
        public string Picture { get; set; }
    }
}