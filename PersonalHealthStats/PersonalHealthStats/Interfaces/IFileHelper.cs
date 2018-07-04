using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthStats.Interfaces
{
    interface IFileHelper
    {
        string GetLocalFileLocation(string Filename);
    }
}
