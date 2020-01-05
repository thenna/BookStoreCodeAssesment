﻿using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BootStore.Persistence.Extensions
{
    public class GuidValueGenerator : ValueGenerator<string>
    {
        public override string Next(EntityEntry entry)
        {
            return Guid.NewGuid().ToString();
        }

        public override bool GeneratesTemporaryValues => false;
    }
}
