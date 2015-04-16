using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orwell_S_E_FruityMart
{
    [Serializable]
    class Customer
    {
        public int CustID { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string CustPhone { get; set; }
        public string CustEmail { get; set; }
        public List<int> CustOrderHistory { get; set; }
        public decimal CustTotalSpending { get; set; }

        public Customer(int PassedCustID)
        {
            CustID = PassedCustID;
        }
    }
    
}
