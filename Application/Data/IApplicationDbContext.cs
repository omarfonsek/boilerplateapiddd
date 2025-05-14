﻿using Domain.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
