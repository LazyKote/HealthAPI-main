namespace HealthAPI.Models
{
    public class EFStorage:EFBaseModel
    {
/*
        public EFDoctor() { }*/

        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Owner { get; set; }
        public List<EFProduct> EFProducts { get; set; } = new List<EFProduct>();
    }
}
