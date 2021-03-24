
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MP_EF_HeberAndrade.AssetsModel
{
    class AssetsDataCatalog
    {

        public string Brand { get; set; }
        public string ModelName { get; set; }
        public int PurchaseDate { get; set; }
        public int InicialCost { get; set; }
        public int ExpiredDate { get; set; }
        public int ExpiredCost { get; set; }

    }

}