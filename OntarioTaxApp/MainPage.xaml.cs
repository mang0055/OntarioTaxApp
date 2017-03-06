using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OntarioTaxApp
{
    /// <summary>
    /// An page is Main Page of application. Which have all controls to calculate and display Tax.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Tax tax;

        string taxAmountInputValue = string.Empty;
        string taxInputValue = string.Empty;

        /// <summary>
        /// MainPage initialization
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            tax = new Tax();
        }

        /// <summary>
        /// WHile user write text inside purchase amount input field this method will call. where we are calculating tax based on input so user can see calculated tax realtime.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void purchaseAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            doTaxCalculation(purchaseAmount.Text);
        }

        /// <summary>
        /// Purchase amount input Got Focus. So while user opens app its tab index 0. means active. Ready for accept inputs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void purchaseAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            purchaseAmount.Text = string.Empty;
            taxAmount.Text ="$0.00";
            totalAmount.Text = "$0.00";
        }

        /// <summary>
        /// Purchase Amount input Lost Focus event. So while user enter text and click outside or click on other element of screen. it will execute this method where we are calculating tax and setting purchase formated price.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void purchaseAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            doTaxCalculation(purchaseAmount.Text);
            purchaseAmount.Text = tax.purchasePrice;
        }

        /// <summary>
        /// All RadioButton clicks call back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GSTRadioButton_Click(object sender, RoutedEventArgs e)
        {
            doTaxCalculation(purchaseAmount.Text);
            purchaseAmount.Text = tax.purchasePrice;
        }

        /// <summary>
        /// Method: doTaxCalculations will accept input value from user and find Appropriate selected Tax.
        /// </summary>
        /// <param name="inputvalue"></param>
        private void doTaxCalculation(string inputvalue)
        {
            //This method working as below steps
            //1. This forEach loop though all main stack panel Radio button and find checked one. It will extract string of Tag from Radiobutton which is actual Tax value.
            foreach (RadioButton tb in FindVisualChildren<RadioButton>(mainStackPanel))
            {
                if (tb.IsChecked == true)
                {
                    //2. Tax value and Purchase value are passing to Tax class reference in Calculate method.
                    tax.Calculate(inputvalue, tb.Tag.ToString());

                    //3. Setting calculated Total Tax value from tax class's method into appropriate Label if its not Empty
                    if (tax.totalTax!=string.Empty)
                    taxAmount.Text = tax.totalTax;
                    //4. Setting calculated Total Price value from tax class's method into appropriate Label if its not Empty
                    if (tax.totalPrice!=string.Empty)
                    totalAmount.Text = tax.totalPrice;
                }
            }
           
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }

   
}
