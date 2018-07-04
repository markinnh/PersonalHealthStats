using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
//using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
[assembly: Xamarin.Forms.Dependency(typeof(PersonalHealthStats.Droid.FileHelper))]
namespace PersonalHealthStats.Droid
{
    public class FileHelper : Interfaces.IFileHelper
    {
        public string GetLocalFileLocation(string Filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, Filename);
        }
    }
}