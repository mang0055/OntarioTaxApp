//Raviraj Mangukiya
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
        /// <summary>
        /// Constructor 
        /// </summary>
        public Tax()
        {
            purchasePrice = string.Empty;
            totalTax = string.Empty;
            totalPrice = string.Empty;
        }
        /// <summary>
        /// Method: Calculate will Do calculation based on Input Tax and Choosen Tax. And Set values according to its container.
        /// </summary>
        /// <param name="purchasePrice"></param>
        /// <param name="taxPrice"></param>
        public void Calculate(string purchasePrice, string taxPrice) {
            double pPrice = 0.0;
            double tPrice = 0.0;

            //Converting Strings to Purchased Price into Double.
            bool bPrice =double.TryParse(purchasePrice.Replace('$',' '), out pPrice);
            if (bPrice)
            {
                //Converting Strings to Tax Price into Double.
                bool bTax = double.TryParse(taxPrice, out tPrice);
                if (bTax)
                {
                    double totalTax1 = pPrice * (tPrice / 100);
                    double priceWithTotalTax = pPrice + totalTax1;

                    //Formating Back to Currency formate from Double.
                    this.purchasePrice = string.Format("{0:C}", pPrice);
                    this.totalTax = string.Format("{0:C}", totalTax1);
                    this.totalPrice = string.Format("{0:C}", priceWithTotalTax);
                }
                //Handling Error to print for now
                else {
                    Debug.WriteLine("Error Parsing Tax: " + taxPrice);
                }
            }
            else {
                Debug.WriteLine("Error Parsing Purchase Price: " + purchasePrice);
            }
           
        }
    }
}
