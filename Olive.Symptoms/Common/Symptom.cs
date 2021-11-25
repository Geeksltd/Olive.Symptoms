using System;
using System.Linq;
using System.Collections.Generic;

namespace Olive.Symptoms
{
    /// <summary>
    /// Represents a single warning that is displayed to the user.
    /// </summary>
    public class Symptom
    {
        public List<Escalation> Escalations { get; private set; } = new List<Escalation>();
        public List<Responsible> Responsibles { get; private set; } = new List<Responsible>();

        public string WarningKey { get; set; }

        Symptom()
        {

        }

        public Symptom(string uniqueId, string warningKey, string warning)
        {
            UniqueId = uniqueId;
            WarningKey = warningKey;
            Warning = warning;
        }

        /// <summary>
        /// A url to help the user to fix this warning.
        /// For relative Url to the current site use ~/my-url syntax.
        /// </summary>
        public string FixUrl { get; set; }
        public bool IsFixUrlModal { get; set; }

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
        public string Workspace { get; set; }


        /// <summary>
        /// Adds a new responsible item to this symptom. Either person or role should be specified.
        /// </summary>
        /// <param name="person">The ID or Email address of the user responsible for</param>
        public Symptom Responsible(string person)
        {
            Responsibles.Add(new Responsible { Person = person });
            return this;
        }

        /// <summary>
        /// Adds a new responsible item to this symptom. Either person or role should be specified.
        /// </summary>
        /// <param name="role">The role responsible for fixing this warning.</param>
        public Symptom ResponsibleAll(string role)
        {
            Responsibles.Add(new Responsible { Role = role });
            return this;
        }

        /// <summary>
        /// Adds a new escalation item to this symptom. Either person or role should be specified.
        /// </summary>
        /// <param name="when">When this symptom should be escalated.</param>
        /// <param name="person">The ID or Email address of the user responsible for</param>
        public Symptom EscalateTo(string person, TimeSpan when)
        {
            if (Escalations.Any(e => e.Responsible.Person == person)) return this;

            Escalations.Add(new Escalation
            {
                When = when,
                Responsible = new Responsible { Person = person }
            });

            return this;
        }

        /// <summary>
        /// Adds a new escalation item to this symptom. Either person or role should be specified.
        /// </summary>
        /// <param name="when">When this symptom should be escalated.</param>
        /// <param name="role">The role responsible for fixing this warning.</param>
        public Symptom EscalateToAll(string role, TimeSpan when)
        {
            Escalations.Add(new Escalation
            {
                When = when,
                Responsible = new Responsible { Role = role }
            });

            return this;
        }

        /// (optional) is the ID of the project to which the warning relates.
        public Symptom For(string workspace)
        {
            Workspace = workspace;

            return this;
        }

        /// (optional) is the ID of the project to which the warning relates.
        public Symptom WithFixUrl(string url, bool isModal = false)
        {
            FixUrl = url;
            IsFixUrlModal = isModal;
            return this;
        }
    }
}
