﻿using CleanArchitectureProject1.Application.Common.Interfaces;

namespace CleanArchitectureProject1.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
