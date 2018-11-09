using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PersonalHealthStats
{
    public class EntryTypeConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = null;
            if (value is Models.EntryType entryType)
            {
                switch (entryType)
                {
                    case Models.EntryType.BeforeBreakfast:
                        result = Constants.BeforeBreakfast;
                        break;
                    case Models.EntryType.AfterBreakfast:
                        result = Constants.AfterBreakfast;
                        break;
                    case Models.EntryType.BeforeLunch:
                        result = Constants.BeforeLunch;
                        break;
                    case Models.EntryType.AfterLunch:
                        result = Constants.AfterLunch;
                        break;
                    case Models.EntryType.BeforeDinner:
                        result = Constants.BeforeDinner;
                        break;
                    case Models.EntryType.AfterDinner:
                        result = Constants.AfterDinner;
                        break;
                    case Models.EntryType.BeforeBed:
                        result = Constants.BeforeBed;
                        break;
                    default:
                        break;
                }

            }
            return result;
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Models.EntryType result = Models.EntryType.BeforeBreakfast;

            if (value is string target)
            {
                switch (target)
                {
                    case Constants.BeforeBreakfast:
                        result = Models.EntryType.BeforeBreakfast;
                        break;
                    case Constants.AfterBreakfast:
                        result = Models.EntryType.AfterBreakfast;
                        break;
                    case Constants.BeforeLunch:
                        result = Models.EntryType.BeforeLunch;
                        break;
                    case Constants.AfterLunch:
                        result = Models.EntryType.AfterLunch;
                        break;
                    case Constants.BeforeDinner:
                        result = Models.EntryType.BeforeDinner;
                        break;
                    case Constants.AfterDinner:
                        result = Models.EntryType.AfterDinner;
                        break;
                    case Constants.BeforeBed:
                        result = Models.EntryType.BeforeBed;
                        break;
                    default:
                        break;
                }
            }
            return result;
            //throw new NotImplementedException();
        }
    }
}
