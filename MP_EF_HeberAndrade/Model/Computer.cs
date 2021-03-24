namespace MP_EF_HeberAndrade

{
    public class Computer : Asset
    {
        public Computer(string v1, string v2, int v3, int v4)
        {
        }

        public Computer(string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)
        {
            Brand = brand;
            ModelName = modelName;
            PurchaseDate = purchaseDate;
            InicialCost = inicialCost;
            ExpiredDate = expiredDate;
            ExpiredCost = expiredCost;
        }
        public int Id { get; set; }
    }
}
