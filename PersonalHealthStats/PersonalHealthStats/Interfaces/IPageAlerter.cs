using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthStats.Interfaces
{
    public interface IPageAlerter
    {
        System.Threading.Tasks.Task DoDisplayAlert(string AlertTitle, string AlertMessage, string Cancel);
        System.Threading.Tasks.Task DoDisplayAlert(string AlertTitle, string AlertMessage, string Accept, string Cancel);
    }
}
