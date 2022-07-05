using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        private double _length;
        private double _width;
        private double _height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this._length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }
                this._length = value;
            }
        }
        public double Width
        {
            get
            {
                return this._width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }
                this._width = value;
            }
        }

        public double Height
        {
            get
            {
                return this._height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }
                this._height = value;
            }
        }

        public double SurfaceArea()
        {
            double surfaceArea = 2 * (this.Length * this.Width + this.Length * this.Height + this.Height * this.Width);
            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            return 2 * (this.Length*this.Height + this.Width*this.Height);
        }

        public double Volume()
        {
            return this.Length * this.Height * this.Width;
        }
    }
}
