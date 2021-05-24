namespace PresentationLayer.Models
{
    public class Facility : ViaEntity
    {
        public string Name { get; set; }
        public Campus Campus { get; set; }
        public Account Account { get; set; }
    }
}