namespace SolucionesARWebsite.Security
{
    /// <summary>
    /// Represents an action allowed for a security role. Contains the name of the action allowed and the controller
    /// to whom the action belongs.
    /// </summary>
    public class AllowedAction
    {
        /// <summary>
        /// The controller of the action
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// The action
        /// </summary>
        public string Action { get; set; }
    }
}