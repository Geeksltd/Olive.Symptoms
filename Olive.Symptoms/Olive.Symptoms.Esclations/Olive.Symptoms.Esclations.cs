using System;

namespace Olive.Symptoms.Esclations
{
    public static class Extensions
    {
        public static Symptom EsclateToCTO(this Symptom @this, TimeSpan when) => @this.EscalateTo(People.CTO, when);
    }
}
