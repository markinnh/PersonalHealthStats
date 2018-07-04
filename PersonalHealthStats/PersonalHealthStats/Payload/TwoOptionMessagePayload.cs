using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthStats.Payload
{
    class TwoOptionMessagePayload:BaseMessagePayload
    {
        public string OkText { get; set; }
        public string CancelText { get; set; }
    }
}
