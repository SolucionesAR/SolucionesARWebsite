using System.Collections.Specialized;

namespace SolucionesARWebsite.DataObjects
{
    /// <summary>
    /// User information that is usually needed and cached
    /// </summary>
    public class UserInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInformation"/> class.
        /// </summary>
        public UserInformation()
        {
            UserData = new NameValueCollection();
        }

        /// <summary>
        /// Id of the user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Role of the user
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Role's id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// True if the user is a super user.
        /// </summary>
        public bool IsSuperUser { get; set; }

        /// <summary>
        /// Id of the user
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Name of the user
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// The salt used to decrypt the user's password
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Password encrypted
        /// </summary>
        public string CryptedPassword { get; set; }

        /// <summary>
        /// Bag for additional data for the user.
        /// </summary>
        public NameValueCollection UserData { get; set; }
    }
}