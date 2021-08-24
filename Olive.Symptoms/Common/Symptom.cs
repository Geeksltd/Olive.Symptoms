using Olive.Entities;
using System;
using System.Collections.Generic;

namespace Olive.Symptoms
{
    /// <summary>
    /// Represents a single warning that is displayed to the user.
    /// </summary>
    public class Symptom
    {
        internal List<Escalation> Escalations { get; private set; } = new List<Escalation>();
        internal List<Responsible> Responsibles { get; private set; } = new List<Responsible>();

        public IEntity Info { get; private set; }
        public string WarningKey { get; private set; }

        Symptom()
        {

        }

        public Symptom(IEntity info, string warningKey)
        {
            Info = info;
            WarningKey = warningKey;
        }

        /// <summary>
        /// A url to help the user to fix this warning.
        /// For relative Url to the current site use ~/my-url syntax.
        /// </summary>
        public string FixUrl { get; set; }

        /// <summary>
        /// UniqueID of the symptom (mandatory). This should be the same every time for the same logical warning.
        /// Use a combination of the object Id(s) that own this warning, and a brief unique text or code for the type of the warning. 
        /// </summary>
        public string UniqueId { get; set; }

        /// <summary>
        /// The warning text to show to the user. This is mandatory.
        /// </summary>
        public string Warning { get; set; }

        /// <summary>
        /// (optional) is the ID of the project to which the warning relates.
        /// </summary>
        public string Workspace { get; private set; }


        /// <summary>
        /// Adds a new responsible item to this symptom. Either person or role should be specified.
        /// </summary>
        /// <param name="person">The ID or Email address of the user responsible for</param>
        /// <param name="role">The role responsible for fixing this warning.</param>
        public Symptom Responsible(string person = null, string role = null)
        {
            Responsibles.Add(new Responsible(person: person, role: role));
            return this;
        }

        /// <summary>
        /// Adds a new esclation item to this symptom. Either person or role should be specified.
        /// </summary>
        /// <param name="when">When this symptom should be escalated.</param>
        /// <param name="person">The ID or Email address of the user responsible for</param>
        /// <param name="role">The role responsible for fixing this warning.</param>
        public Symptom EscalateTo(TimeSpan when, string person = null, string role = null)
        {
            Escalations.Add(new Escalation
            {
                When = when,
                Responsible = new Responsible(person: person, role: role)
            });

            return this;
        }

        /// (optional) is the ID of the project to which the warning relates.
        public Symptom For(string workspace)
        {
            Workspace = workspace;

            return this;
        }
    }
}
