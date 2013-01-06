using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.Utils;

namespace SolucionesARWebsite2.ViewModels.Lists
{
       #region enums

    public enum RelationshipTypeListSortField
    {
        [Value("relationShipTypeId")]
        Id,
        [Value("description")]
        Description,
    }

    public enum RelationshipTypeListFilter
    {
        [Value("relationShipTypeId")]
        Id,
        [Value("description")]
        Description,
    }
    #endregion

    public class RelationshipTypeList : BaseListModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>The counts.</value>
        public new List<RelationshipType> Items
        {
            get
            {
                return (List<RelationshipType>)base.Items;
            }
            set
            {
                base.Items = value;
            }
        }
        
        #endregion

        #region Constructors

        public RelationshipTypeList()
        {
        }

        public RelationshipTypeList(RelationshipTypeListSortField sort, SortDirectionType dir, Dictionary<ProvinceListFilter, string> filters)
        {
        }

        #endregion
    }
}

