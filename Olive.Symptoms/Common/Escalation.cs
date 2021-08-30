using System;
using System.Collections.Generic;
using System.Text;

namespace Olive.Symptoms
{
    public class Escalation
    {
        public TimeSpan When { get; set; }

        public Responsible Responsible { get; set; }

        public void Validate()
        {
            if (Responsible == null)
                throw new Exception("Responsible is mandatory");

            Responsible.Validate();
        }
    }
}
