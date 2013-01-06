using System.Collections.Generic;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
{
    public interface IRelationshipTypesRepository
    {
        void AddRelationshipType(RelationshipType relationshipType);

        void EditRelationshipType(RelationshipType relationshipType);

        List<RelationshipType> GetRelationshipTypesList();

        RelationshipType GetRelationShipType(int id);

        RelationshipType GetRelationShipType(string relationDescription);
    }
}
