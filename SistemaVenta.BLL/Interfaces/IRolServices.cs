﻿using SistemaVenta.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.BLL.Interfaces
{
    public interface IRolServices
    {
        Task<List<Rol>> Lista();
    }
}
