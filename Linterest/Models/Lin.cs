namespace Linterest.Models
{
    public class Lin
    {
        public int Id { get; set; }
        public LinterestUser Author { get; set; }
        public  string Text { get; set; }
        public string ImageUrl { get; set; }
        public string PinImageUrl { get; set; }       
    }
}