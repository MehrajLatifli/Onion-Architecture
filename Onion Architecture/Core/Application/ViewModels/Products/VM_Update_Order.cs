namespace Application.ViewModels.Products
{
    public class VM_Update_Order
    {
        public int id { get; set; }

        public string description { get; set; }

        public string address { get; set; }


        public int customerid_fororder { get; set; }

        public int productid_fororder { get; set; }

    }
}
