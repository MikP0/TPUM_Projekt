﻿using System;
using System.Collections.Generic;
using TPUM.ClientData.Model;

namespace TPUM.ClientData.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        IEnumerable<T> Get();
        T Get(int id);
        IEnumerable<T> Get(Func<T, bool> filter);
        T Add(T entity);
        void Delete(int id);
        T Update(int id, T entity);
    }
}
