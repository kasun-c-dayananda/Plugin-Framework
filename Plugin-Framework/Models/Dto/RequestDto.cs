namespace Plugin_Framework.Models.Dto
{
    public class RequestDto
    {
        public int CustomerID { get; set; }
        public IFormFile File { get; set; }
        public List<int> Effects { get; set; }
        public int Radius { get; set; }
        public double Size { get; set; }
    }
}
