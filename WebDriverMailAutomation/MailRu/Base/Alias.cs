namespace Mail.Base
{
    /// <summary>
    /// Represents a class describing an alias.
    /// </summary>
    public class Alias
    {
        /// <summary>
        /// Get or Set the name of the alias.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="name">Name of the alias</param>
        public Alias(string name)
        {
            Name = name;
        }
    }
}
