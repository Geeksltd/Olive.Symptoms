using System;

namespace Olive.Symptoms.Escalations
{
    public static class Extensions
    {
        public static Symptom EscalateToCTO(this Symptom @this, TimeSpan when) => @this.EscalateTo(People.CTO, when);

        public static Symptom AssignToDevOps(this Symptom @this) => @this.ResponsibleAll("DevOps");
    }
}
