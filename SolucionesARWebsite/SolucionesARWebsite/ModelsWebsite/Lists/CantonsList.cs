﻿using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ModelsWebsite.Lists
{
    #region enums

    public enum DistrictListSortField
    {
        [Value("id")]
        Id,
        [Value("name")]
        Name,
        [Value("cantonId")]
        CantonId,
    }

    public enum DistrictListFilter
    {
        [Value("districtId")]
        Id,
        [Value("name")]
        Name,
        [Value("cantonId")]
        CantonId,
    }
    #endregion
    public class DistrictsList : ListWrapper
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>The counts.</value>
        public new List<District> Items
        {
            get
            {
                return (List<District>)base.Items;
            }
            set
            {
                base.Items = value;
            }
        }

        /// <summary>
        /// Gets or sets the current sorting field.
        /// </summary>
        /// <value></value>
        public new DistrictListSortField SortField
        {
            get
            {
                return (DistrictListSortField)base.SortField;
            }
            set
            {
                base.SortField = value;
            }
        }

        /// <summary>
        /// Gets or sets the filters.
        /// </summary>
        /// <value>The filters.</value>
        public new Dictionary<DistrictListFilter, string> Filters
        {
            get
            {
                return (Dictionary<DistrictListFilter, string>)base.Filters;
            }
            set
            {
                base.Filters = value;
            }
        }

        #endregion

        #region Constructors

        public DistrictsList()
        {
        }

        public DistrictsList(DistrictListSortField sort, SortDirectionType dir, Dictionary<DistrictListFilter, string> filters)
            : base(sort, dir, filters)
        {
        }

        #endregion
    }
}