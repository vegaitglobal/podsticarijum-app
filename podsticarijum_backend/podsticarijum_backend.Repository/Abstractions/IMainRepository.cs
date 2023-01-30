﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository.Abstractions;

public interface IMainRepository
{

    ValueTask<MainScreen> Get(long Id);

    Task Update(MainScreen mainScreen);

    Task<long> Insert(MainScreen mainScreen);
}
