﻿using System.Collections.Generic;
using System.Linq;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
{
    public interface ICantonsRepository
    {
        void AddCanton(Canton canton);

        void EditCanton(Canton canton);

        List<Canton> GetAllCantons();

        List<Canton> GetCantons();

        List<Canton> GetCantons(int provinceId);

        Canton GetCanton(int cantonId);
        
        Canton GetCantonByDistrict(int districtId);
    }
}
