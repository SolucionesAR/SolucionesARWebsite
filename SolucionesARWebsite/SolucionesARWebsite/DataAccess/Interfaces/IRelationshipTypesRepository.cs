using System.Collections.Generic;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Interfaces
{
    public interface IRelationshipTypesRepository
    {
        List<RelationshipType> GetRelationshipTypesList();

        RelationshipType GetRelationShipType(string relationDescription);
    }
}
