namespace Challenge.Models
{
    public class Item
    {
        //public string Id { get; set; }
        //public string Text { get; set; }
        //public string Description { get; set; }

        public string GuidId { get; set; }
        public double Distance { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public Coords Coords { get; set; }
    }
}