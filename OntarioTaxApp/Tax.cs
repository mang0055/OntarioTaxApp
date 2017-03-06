using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntarioTaxApp
{
    class Tax
    {
        public string purchasePrice;
        public string totalTax;
        public string totalPrice;

        public Tax()
        {
            purchasePrice = string.Empty;
            totalTax = string.Empty;
            totalPrice = string.Empty;
        }
        public void Calculate(string purchasePrice, string taxPrice) {
            double pPrice = 0.0;
            double tPrice = 0.0;
            double.TryParse(purchasePrice.Replace('$',' '), out pPrice);
            double.TryParse(taxPrice, out tPrice);

            double totalTax1 = pPrice * (tPrice / 100);
            double priceWithTotalTax = pPrice + totalTax1;

           
            //this.purchasePrice = purchasePrice;
            this.purchasePrice = string.Format("{0:C}", pPrice);
            Debug.WriteLine(this.purchasePrice);
            this.totalTax = string.Format("{0:C}", totalTax1);
            this.totalPrice = string.Format("{0:C}",priceWithTotalTax);
        }
    }
}
