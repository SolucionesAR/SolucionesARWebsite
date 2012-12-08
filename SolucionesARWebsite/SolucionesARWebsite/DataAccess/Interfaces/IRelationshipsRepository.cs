using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Interfaces
{
    public interface IRelationshipsRepository
    {
        User GetRelatedUser(User customer, RelationshipType relationshipType);

        Relationship GetRelationshipByUsers(int userId, int parentUserId);
    }
}
