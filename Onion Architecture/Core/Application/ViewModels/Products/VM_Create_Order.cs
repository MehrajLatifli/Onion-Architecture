namespace Application.ViewModels.Products
{
    public class VM_Create_Order
    {
        public string description { get; set; }

        public string address { get; set; }


        public Guid customerid_fororder { get; set; }

        public Guid productid_fororder { get; set; }


    }
}
