namespace Olive.Symptoms
{
    /// <summary>
    /// Represents a single warning that is displayed to the user.
    /// </summary>
    public class Symptom
    {
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
        /// The ID or Email address of the user responsible for fixing this warning.
        /// </summary>
        public string Receipient { get; set; }
    }
}
