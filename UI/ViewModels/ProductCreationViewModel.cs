namespace UI.ViewModels
{
    public class ProductCreationViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreateDateTime = DateTime.Now;
    }
}
