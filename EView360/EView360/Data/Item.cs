namespace EView360.Data
{
    public class Item
    {
        public string? Id { get; set; }
        public string? Text { get; set; }
        public List<Item> Children { get; set; }
    }
}
