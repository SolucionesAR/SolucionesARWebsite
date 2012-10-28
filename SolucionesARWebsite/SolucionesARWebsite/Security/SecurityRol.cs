using System.Collections.Generic;
using System.Xml;

namespace SolucionesARWebsite.Security
{
    /// <summary>
    /// Parses an xml with the roles and their permissions to a list of filtered actions and menu items
    /// </summary>
    public class SecurityRol
    {
        private readonly List<AllowedAction> _actions = new List<AllowedAction>();

        /// <summary>
        /// Role name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Allowed actions for the role
        /// </summary>
        public List<AllowedAction> Actions
        {
            get
            {
                return _actions;
            }
        }
        
        /// <summary>
        /// Determines if an action on a controller is allowed for this role
        /// </summary>
        /// <param name="action">the action to test</param>
        /// <param name="controller">the controller</param>
        /// <returns>true if the action is allowed, false if not</returns>
        public bool AllowAction(string action, string controller)
        {
            foreach (AllowedAction filterAction in Actions)
            {
                if (filterAction.Controller.Equals(controller))
                {
                    if (filterAction.Action.Equals("*") || filterAction.Action.Equals(action))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityRol"/> class. 
        /// Parses the mainNode into actions and menu items.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="mainNode">The main node.</param>
        public SecurityRol(string name, XmlNode mainNode)
        {
            Name = name;

            var actionNodes = mainNode.SelectNodes("actions/action[@enabled='true']");
            if (actionNodes != null)
            {
                foreach (XmlNode actionNode in actionNodes)
                {
                    if (actionNode.NodeType != XmlNodeType.Element)
                    {
                        //skip
                        break;
                    }
                    var action = new AllowedAction
                                     {
                                         Controller = actionNode.Attributes["controller"].Value,
                                         Action = actionNode.Attributes["action"].Value,
                                     };
                    _actions.Add(action);
                }
            }
        }
    }
}