using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalc1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Constants
        const double MINWIDTH = 0.5;
        const double MAXWIDTH = 5.0;
        const double MINHEIGHT = 0.75;
        const double MAXHEIGHT = 3.0;
        const int MINQUANTITY = 1;
        const int MAXQUANTITY = 3;
        #endregion

        #region Declarations
        double windowWidth = 0.0;
        double windowHeight = 0.0;
        String windowTintColor = "";
        int windowQuantity = 0;
        double woodLength = 0;
        double glassArea = 0;
        #endregion

        public MainPage()
        {
            this.InitializeComponent();
            widthError.Text = "";
            heightError.Text = "";
            tintError.Text = "";
            quantityError.Text = "";
        }


        private bool ValidateWindowWidth(double windowWidth)
        {
            if (windowWidth >= MINWIDTH && windowWidth <= MAXWIDTH)
            {
                widthError.Text = "";
                return true;
            }
            else
            {
                widthError.Text = "Width must be between " + MINWIDTH + " and " + MAXWIDTH + ".";
                return false;
            }
        }
        private bool ValidateWindowHeight(double windowHeight)
        {
            if (windowHeight >= MINHEIGHT && windowHeight <= MAXHEIGHT)
            {
                heightError.Text = "";
                return true;
            }
            else
            {
                heightError.Text = "Height must be between " + MINHEIGHT + " and " + MAXHEIGHT + ". <\n>";
                return false;
            }
        }

        public IPropertySet Values { get; }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            double windowWidth;
            double windowHeight;

            if (Double.TryParse(inputWidth.Text, out windowWidth))
            {
                bool isValid = ValidateWindowWidth(windowWidth);
                if (!isValid)
                {
                    windowWidth = 0;
                    inputWidth.Text = "";
                    widthError.Text = "Width must be between " + MINWIDTH + " and " + MAXWIDTH + ".";
                } else
                {
                    widthError.Text = ".";
                }
            }
            else
            {
                windowWidth = 0;
                inputWidth.Text = "";
                widthError.Text = "Width must be a number.";
            }

            if (Double.TryParse(inputHeight.Text, out windowHeight))
            {
                bool isValid = ValidateWindowHeight(windowHeight);
                if (!isValid)
                {
                    windowHeight = 0;
                    inputHeight.Text = "";
                    heightError.Text = "Height must be between " + MINHEIGHT + " and " + MAXHEIGHT + ".";
                } else
                {
                    heightError.Text = "";
                }
            }
            else
            {
                windowHeight = 0;
                inputHeight.Text = "";
                heightError.Text = "Height must be a number.";
            }

            if (windowQuantity == 0)
            {
                quantityError.Text = "Quantity must be between 1 and 3";
                windowQuantity = 0;
            } else
            {
                quantityError.Text = "";
            }

            if (windowTintColor == "" || windowTintColor == null)
            {
                tintError.Text = "Pick a tint.";
                windowTintColor = "";
            }
            else
            {
                tintError.Text = "";
            }

            if (windowWidth != 0 && windowHeight != 0 && windowQuantity != 0 && windowTintColor != "")
            {

                double glassArea = CalcGlassArea(windowWidth, windowHeight, windowQuantity);
                double woodLength = CalcWoodLength(windowWidth, windowHeight, windowQuantity);

                WindowBuild windowBuild = new WindowBuild(windowWidth, windowHeight, windowTintColor, windowQuantity);

                Windows.Storage.ApplicationDataContainer localSettings =
                    Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                    Windows.Storage.ApplicationData.Current.LocalFolder;

                localSettings.Values["windowWidth"] = windowWidth;
                localSettings.Values["windowHeight"] = windowHeight;
                localSettings.Values["windowTintColor"] = windowTintColor;
                localSettings.Values["windowQuantity"] = windowQuantity;
                localSettings.Values["woodLength"] = woodLength;
                localSettings.Values["glassArea"] = glassArea;

                Frame.Navigate(typeof(Results));
            }
            else
            {

            }

        }

        public double CalcWoodLength(double windowWidth, double windowHeight, int windowQuantity)
        {
            if (windowWidth >= MINWIDTH && windowWidth <= MAXWIDTH
                && windowHeight >= MINHEIGHT && windowHeight <= MAXHEIGHT
                && windowQuantity >= MINQUANTITY && windowQuantity <= MAXQUANTITY)
            {
                woodLength = (2 * (windowWidth + windowHeight) * 3.25) * windowQuantity;
            }
            else
            {
                woodLength = 0.0;
            }
            return woodLength;
        }

        public double CalcGlassArea(double windowWidth, double windowHeight, int windowQuantity)
        {
            if (windowWidth >= MINWIDTH && windowWidth <= MAXWIDTH
                && windowHeight >= MINHEIGHT && windowHeight <= MAXHEIGHT
                && windowQuantity >= MINQUANTITY && windowQuantity <= MAXQUANTITY)
            {
                glassArea = (2 * (windowWidth + windowHeight)) * windowQuantity;
            }
            else
            {
                glassArea = 0.0;
            }
            return windowHeight;
        }

        private void inputQuantity_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            if (slider != null)
            {
                windowQuantity = Convert.ToInt32(slider.Value);
            } 
        }

        private void tintColor_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null)
            {
                windowTintColor = rb.Tag.ToString();
            }
            else
            {
                tintError.Text = "Pick a tint.";
                windowTintColor = "";
            }
        }
    }
}
