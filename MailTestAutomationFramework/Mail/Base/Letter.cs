namespace Mail.Base
{
    /// <summary>
    /// Represents a class that describes a letter entity.
    /// </summary>
    public class Letter
    {
        /// <summary>
        /// Get or Set receiver.
        /// </summary>
        public string Receiver { get; set; }

        /// <summary>
        /// Get or Set letter text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        public Letter(string receiver, string letterText)
        {
            Receiver = receiver;
            Text = letterText;
        }
    }
}