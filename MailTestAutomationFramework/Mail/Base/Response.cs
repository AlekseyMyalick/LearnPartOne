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
        public Alias AliasName { get; set; }

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        public Response(string text, Alias aliasName)
        {
            Text = text;
            AliasName = aliasName;
        }
    }
}