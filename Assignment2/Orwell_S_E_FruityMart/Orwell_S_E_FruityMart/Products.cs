using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orwell_S_E_FruityMart
{
    [Serializable]
    class Products
    {
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public decimal ProdPrice { get; set; }
        public int ProdAvailQuantity { get; set; }
    }
}
