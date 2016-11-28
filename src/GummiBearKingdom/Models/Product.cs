using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBearKingdom.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductsId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Coo{ get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
