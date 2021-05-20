namespace PresentationLayer.Models
{
    public class ViaEntity
    {
        public int ViaId { get; set; }
        public string Password { get; set; }

        public ViaEntity(int viaId, string password)
        {
            ViaId = viaId;
            Password = password;
        }
    }
}