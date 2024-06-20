using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebApi.EfCore
{
    //lets add the table decorator to specify the table that will be created in the database

    [Table("product")]
    public class Product
    {
        //properties are fields/columns in the table

        [Key,Required]
        public int id { get; set; }

        public string name { get; set; } = string.Empty;

        public string brand { get; set; } = string.Empty;
        public int size { get; set; }

        public decimal price { get; set; }
    }
}
