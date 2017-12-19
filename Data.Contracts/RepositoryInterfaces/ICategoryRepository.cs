﻿using Core.Common.Contracts;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contracts
{
    public interface ICategoryRepository : IDataRepository<BudgetCategory>
    { }
}
