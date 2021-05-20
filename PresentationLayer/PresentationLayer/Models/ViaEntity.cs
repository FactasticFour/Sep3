namespace PresentationLayer.Models
{
    public class ViaEntity
    {
        public int viaId { get; set; }
        public string password { get; set; }

        public ViaEntity(int viaId, string password)
        {
            this.viaId = viaId;
            this.password = password;
        }
    }
}