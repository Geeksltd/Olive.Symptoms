using System;
using System.Collections.Generic;
using System.Text;

namespace Olive.Symptoms
{
    class Escalation
    {
        public TimeSpan When { get; set; }

        public Responsible Responsible { get; set; }
    }
}
