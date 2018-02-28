using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlazerCalc1
{
    class WindowBuild
    {
        #region Declarations
        private double width;
        private double height;
        private string tint;
        private int quantity;
        double woodLength;
        double glassArea;
        #endregion

        #region Constants
        const double MINWIDTH = 0.5;
        const double MAXWIDTH = 5.0;
        const double MINHEIGHT = 0.75;
        const double MAXHEIGHT = 3.0;
        const int MINQUANTITY = 1;
        const int MAXQUANTITY = 3;
        #endregion

        public WindowBuild(double width, double height, string tint, int quantity)
        {
            this.width = width;
            this.height = height;
            this.tint = tint;
            this.quantity = quantity;
            woodLength = CalcWoodLength(width, height, quantity);
            glassArea = CalcGlassArea(width, height, quantity);
        }
        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        public string Tint
        {
            get { return tint; }
            set { tint = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public double WoodLength
        {
            get { return woodLength; }
            set { woodLength = value; }
        }
        public double GlassArea
        {
            get { return glassArea; }
            set { glassArea = value; }
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
    }
}
