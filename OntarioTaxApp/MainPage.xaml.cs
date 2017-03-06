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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Tax tax;
        string taxAmountInputValue = string.Empty;
        string taxInputValue = string.Empty;
        public MainPage()
        {
            this.InitializeComponent();
            tax = new Tax();
        }

        private void purchaseAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            doTaxCalculation(purchaseAmount.Text);
        }

        private void purchaseAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            purchaseAmount.Text = string.Empty;
            taxAmount.Text ="$0.00";
            totalAmount.Text = "$0.00";
        }

        private void purchaseAmount_LostFocus(object sender, RoutedEventArgs e)
        {
           
            doTaxCalculation(purchaseAmount.Text);
            purchaseAmount.Text = tax.purchasePrice;

        }
        private void GSTRadioButton_Click(object sender, RoutedEventArgs e)
        {
            doTaxCalculation(purchaseAmount.Text);
            purchaseAmount.Text = tax.purchasePrice;
        }

        private void doTaxCalculation(string inputvalue)
        {
            foreach (RadioButton tb in FindVisualChildren<RadioButton>(mainStackPanel))
            {
                if (tb.IsChecked == true)
                {
                    tax.Calculate(inputvalue, tb.Tag.ToString());
                    if(tax.totalTax!=string.Empty)
                    taxAmount.Text = tax.totalTax;
                    if(tax.totalPrice!=string.Empty)
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
