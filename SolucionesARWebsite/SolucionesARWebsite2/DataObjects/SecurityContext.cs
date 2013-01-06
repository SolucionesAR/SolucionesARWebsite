namespace SolucionesARWebsite2.DataObjects
{
    /// <summary>
    /// Stores private user information after login
    /// </summary>
    public class SecurityContext
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public UserInformation User { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityContext"/> class.
        /// </summary>
        public SecurityContext()
        {
            User = new UserInformation();
        }
    }
}