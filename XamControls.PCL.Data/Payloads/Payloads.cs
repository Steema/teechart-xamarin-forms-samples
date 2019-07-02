using System;
using System.Collections.Generic;
using System.Text;

namespace XamControls.Data.Payloads
{
    public class Payload
    {
        public DateTime DateTime { get; set; }
        public int Value { get; set; }
    }

    public class ListPayload<TValueX, TValueY>
    {
        public List<TValueX> DateTimes { get; set; } = new List<TValueX>();
        public List<TValueY> Values { get; set; } = new List<TValueY>();
    }

}
