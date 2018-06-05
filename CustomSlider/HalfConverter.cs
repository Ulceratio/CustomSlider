using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CustomSlider
{
    public class HalfConverter : IValueConverter
    {
        #region Fields
        private double _Multiplier { get; set; }
        public double Multiplier
        {
            get
            {
                return _Multiplier;
            }
            set
            {
                _Multiplier = value;
            }
        }
        #endregion

        #region Constructors
        public HalfConverter()
        {
            Multiplier = 100;
        }

        public HalfConverter(double Multiplier)
        {
            this.Multiplier = Multiplier;
        }
        #endregion

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            GridLength HeightOfMainPartOfSlider = (GridLength)value;
            return HeightOfMainPartOfSlider.Value * Multiplier;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
