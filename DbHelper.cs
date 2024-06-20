using ShoppingWebApi.EfCore;

namespace ShoppingWebApi.Model
{
    public class DbHelper
    {
        //private field _context is created that is an instance of EF_DataContext class
        private EF_DataContext _context;

        //now this DbHelper constructor accepts an EF_DataContext
        //parameter and assigns it to the private _context field
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        //lets write code for retriving data [Get data]

        public List<ProductModel> GetProducts()
        {
            List<ProductModel> response = new List<ProductModel>();

            //to retrieve datalist from db

            var datalist = _context.Products.ToList();

            datalist.ForEach(row => response.Add(new ProductModel()
            {
                brand = row.brand,
                id = row.id,
                name = row.name,
                price = row.price,
                size = row.size,
            }));

            return response;
        }

        //function that serves the purpose of POST/PUT/PATCH

        public void SaveOrder(OrderModel orderModel)
        {
            Order dbTable = new Order();

            if(orderModel.id > 0)
            {
                //PUT since some id is present and that record is being updated

                dbTable = _context.Orders.Where(d => d.id.Equals(orderModel.id)).FirstOrDefault();

                if(dbTable != null)
                {
                    dbTable.phone = orderModel.phone;
                    dbTable.address = orderModel.address;
                }
                else
                {
                    //since we created a new object by default it is null only
                    //so if there is no update we will just update the new object values with existing object values

                    dbTable.name = orderModel.name;
                    dbTable.phone = orderModel.phone;
                    dbTable.address = orderModel.address;

                    //lastly product will be passed for which we have to refer to the Products table

                    dbTable.Product = _context.Products.Where(f => f.id.Equals(orderModel.product_id))
                        .FirstOrDefault();

                    //now just add the entire record in the Orders table 

                    _context.Orders.Add(dbTable);
                }

                _context.SaveChanges();
            }
        }

        //function to delete

        //just pass the order id of the order that needs to be deleted
        public void DeleteOrder(int id)
        {
            //lets fetch the order first

            var order = _context.Orders.Where(x => x.id.Equals(id)).FirstOrDefault();

            if(order != null)
            {
                _context.Orders.Remove(order);
            }

            _context.SaveChanges();
        }
    }
}
