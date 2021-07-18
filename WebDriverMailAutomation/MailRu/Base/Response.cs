namespace Mail.Base
{
    /// <summary>
    /// Represents a class describing the response.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Get or Set repsponse text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Get or set new alias.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        public Response(string text, string alias)
        {
            Text = text;
            Alias = alias;
        }
    }
}
