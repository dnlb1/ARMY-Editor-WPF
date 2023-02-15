using ARMY_Editor.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ARMY_Editor.ServiceHelper
{
    class BackgroundStackPanel : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Side s = (Side)Enum.Parse(typeof(Side), value.ToString());
            switch (s)
            {
                case Side.Good:
                    return Brushes.LightGreen;
                case Side.Evil:
                    return Brushes.LightCoral;
                case Side.Neutral:
                    return Brushes.Wheat;
                default:
                    return Brushes.Wheat;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
