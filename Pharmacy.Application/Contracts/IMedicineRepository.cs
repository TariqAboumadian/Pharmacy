﻿using Pharmacy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Contracts
{
    public interface IMedicineRepository:IRepository<Medicine,int>
    {
    }
}
