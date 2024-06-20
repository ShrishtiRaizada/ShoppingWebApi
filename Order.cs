using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebApi.EfCore
{
    [Table("order")]
    public class Order
    {
        //this decorator is to specify that id is primary key

        [Key,Required]
        public int id { get; set; }

        //foreign key of order table that refers to the primary key of product table

        public virtual Product Product { get; set; }

        public string name { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
    }
}
