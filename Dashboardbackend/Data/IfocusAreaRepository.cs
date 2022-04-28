﻿using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Data
{
    public interface IfocusAreaRepository
    {
        IEnumerable<FocusArea> GetAllFocusAreas();
        FocusArea GetFocusAreaById(int id);
    }
}
