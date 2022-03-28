using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        const double DELIVERYCHARGE = 25;
        const double WARPING = 5;
        const double GST = 1.1;

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            int totalCharge = 0;
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);
                totalCharge = int.Parse(totalPaymentTextBlock.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }

            double deliveryCharge = 0;
            double warpingCharge = 0;
            double gstCharge = 0;
            deliveryCharge = totalCharge + DELIVERYCHARGE;
            totalChargeTextBox.Text = deliveryCharge.ToString("C");
            warpingCharge = totalCharge + DELIVERYCHARGE + WARPING;
            wrapingTextBox_Copy.Text = warpingCharge.ToString("C");
            gstCharge = (totalCharge + DELIVERYCHARGE + WARPING) * GST;
            gstTestBox.Text= gstCharge.ToString("C");

        }


        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
