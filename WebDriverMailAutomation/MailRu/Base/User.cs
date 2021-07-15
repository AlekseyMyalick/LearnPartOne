namespace MailRu.Base
{
    /// <summary>
    /// Represents a class whose fields describe the user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Get or Set email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Get or Set email.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <param name="password">User password.</param>
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
