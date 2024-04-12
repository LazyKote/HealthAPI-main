namespace HealthAPI.Models
{
    public class EFProduct:EFBaseModel
    {
/*
        public EFPatient() { }*/
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }

        public List<EFStorage> Storages { get; set; } = new List<EFStorage>();

    }
}
