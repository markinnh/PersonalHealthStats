using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(PersonalHealthStats.iOS.FileHelper))]
namespace PersonalHealthStats.iOS
{
    public class FileHelper : Interfaces.IFileHelper
    {
        public string GetLocalFileLocation(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");

            if (!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);
            }

            return System.IO.Path.Combine(libFolder, filename);
        }
    }
}