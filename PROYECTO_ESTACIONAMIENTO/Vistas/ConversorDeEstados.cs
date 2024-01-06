using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Vistas
{
    public class ConversorDeEstados:IValueConverter
    {
        
        public ConversorDeEstados()
        {
          
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           int tiempo;

            // Verifique que el objeto "value" no sea nulo antes de llamar a Int32.TryParse().
           if (value == null)
            {
              // El objeto "value" es nulo.
                    return Brushes.Transparent;
            }else
           {
               Int32.TryParse(value.ToString(),out tiempo);
            }
            
            if (tiempo == 0)
            {
                return Brushes.Green;
            }
            else if (tiempo > 0 && tiempo <= 30)
            {
                return new SolidColorBrush(Color.FromRgb(240, 100, 100));
            }
            else if (tiempo > 30 && tiempo <= 60)
            {
                return new SolidColorBrush(Color.FromRgb(241, 53, 53));
            }
            else
            {
                return Brushes.Red;
            } 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
