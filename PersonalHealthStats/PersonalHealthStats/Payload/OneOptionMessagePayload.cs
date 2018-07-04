using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthStats.Payload
{
    class OneOptionMessagePayload:BaseMessagePayload
    {
        public string CancelText { get; set; }
    }
}
