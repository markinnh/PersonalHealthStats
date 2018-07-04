using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(PersonalHealthStats.UWP.FileHelper))]
namespace PersonalHealthStats.UWP
{
    class FileHelper : Interfaces.IFileHelper
    {
        public string GetLocalFileLocation(string Filename)
        {
            return System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, Filename);
        }
    }
}
