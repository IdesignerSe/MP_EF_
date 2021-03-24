
namespace MP_EF_HeberAndrade.AssetsModel
{
    class Computer
    {
        public Computer(string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)
        {
            Brand = brand;
            ModelName = modelName;
            PurchaseDate = purchaseDate;
            InicialCost = inicialCost;
            ExpiredDate = expiredDate;
            ExpiredCost = expiredCost;
        }

        public string Brand { get; set; }
        public string ModelName { get; set; }
        public int PurchaseDate { get; set; }
        public int InicialCost { get; set; }
        public int ExpiredDate { get; set; }
        public int ExpiredCost { get; set; }

    }

}

