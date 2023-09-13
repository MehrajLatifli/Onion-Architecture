namespace Application.ViewModels.Products
{
    public class VM_Create_Order
    {
        public string Description { get; set; }

        public string Address { get; set; }


        public Guid CustomeridFororder { get; set; }

        public Guid ProductidFororder { get; set; }


    }
}
