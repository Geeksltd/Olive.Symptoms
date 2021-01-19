namespace Olive.Symptoms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Olive;

    /// <summary>
    /// The base class for a custom application-specific source provider.
    /// </summary>
    public abstract partial class Source
    {
        internal List<Symptom> Results = new List<Symptom>();

        /// <summary>
        /// Adds an item to the results.
        /// </summary>
        protected void Add(Symptom result)
        {
            if (result == null) return;

            if (result.UniqueId.IsEmpty())
                throw new ArgumentException("UniqueID cannot be empty in a symptom.");

            if (result.Warning.IsEmpty())
                throw new ArgumentException("Warning cannot be empty in a symptom.");

            if (result.Receipient.IsEmpty())
                throw new ArgumentException("Receipient cannot be empty in a symptom.");


            result.FixUrl = FullUrl(result.FixUrl);
            Results.Add(result);
        }

        static string FullUrl(string url)
        {
            if (url.OrEmpty().StartsWith("~/")) return MakeAbsolute(url.TrimStart('~'));
            else return url;
        }

        /// <summary>
        /// Adds an item to the results.
        /// <paramref name="url">For relative Url to the current site use ~/my-url syntax.</paramref>
        /// </summary>
        protected void Add(string uniqueId, string warning, string receipient)
        {
            Add(new Symptom { UniqueId = uniqueId, Warning = warning });
        }
    }
}