﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Contracts
{
    public interface IDataRepositoryFactory
    {
        T GetDataRepository<T>() where T : IDataRepository;
    }
}
