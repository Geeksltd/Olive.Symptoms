using System;
using System.Collections.Generic;
using System.Text;

namespace Olive.Symptoms
{
    class Responsible
    {
        /// <summary>
        /// The ID or Email address of the user responsible for.
        /// </summary>
        public string Person { get; private set; }

        /// <summary>
        /// The role responsible for fixing this warning.
        /// </summary>
        public string Role { get; private set; }

        Responsible()
        {

        }

        public Responsible(string person = null, string role = null)
        {
            if (person.HasValue() == role.HasValue())
                throw new Exception("Either person or role should be specified");
        }
    }
}
