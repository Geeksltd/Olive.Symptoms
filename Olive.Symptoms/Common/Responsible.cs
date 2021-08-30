using System;
using System.Collections.Generic;
using System.Text;

namespace Olive.Symptoms
{
    public class Responsible
    {
        /// <summary>
        /// The ID or Email address of the user responsible for.
        /// </summary>
        public string Person { get; set; }

        /// <summary>
        /// The role responsible for fixing this warning.
        /// </summary>
        public string Role { get; set; }

        public void Validate()
        {
            if (Person.HasValue() == Role.HasValue())
                throw new Exception("Either person or role should be specified");
        }

    }
}
