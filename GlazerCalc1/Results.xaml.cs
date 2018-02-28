using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GlazerCalc1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Results : Page
    {
        #region Declarations
        private double width;
        private double height;
        private string tint;
        private int quantity;
        double wood;
        double glass;
        #endregion

        public double windowWidth
        {
            get { return width; }
            set { width = value; }
        }
        public double windowHeight
        {
            get { return height; }
            set { height = value; }
        }
        public string windowTintColor
        {
            get { return tint; }
            set { tint = value; }
        }
        public int windowQuantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public double woodLength
        {
            get { return wood; }
            set { wood = value; }
        }
        public double glassArea
        {
            get { return glass; }
            set { glass = value; }
        }

        public Results()
        {
            this.InitializeComponent();

            Windows.Storage.ApplicationDataContainer localSettings =
                    Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;

            Object windowWidth = localSettings.Values["windowWidth"];
            Object windowHeight = localSettings.Values["windowHeight"];
            Object windowTintColor = localSettings.Values["windowTintColor"];
            Object windowQuantity = localSettings.Values["windowQuantity"];
            Object woodLength = localSettings.Values["woodLength"];
            Object glassArea = localSettings.Values["glassArea"];

            widthOutput.Text = windowWidth.ToString();
            heightOutput.Text = windowHeight.ToString();
            tintOutput.Text = windowTintColor.ToString();
            quantityOutput.Text = windowQuantity.ToString();
            woodLengthOutput.Text = woodLength.ToString();
            glassAreaOutput.Text = glassArea.ToString();
            dateOutput.Text = DateTime.Now.ToString();
        }

        private void orderAgain_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
