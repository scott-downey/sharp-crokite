﻿using Microsoft.EntityFrameworkCore;
using SharpCrokite.DataAccess.DatabaseContexts;
using SharpCrokite.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SharpCrokite.Infrastructure.Repositories
{
    public class HarvestableRepository : GenericRepository<Harvestable>
    {
        public HarvestableRepository(SharpCrokiteDbContext dbContext) : base(dbContext)
        {
        }

        public override Harvestable Update(Harvestable entity)
        {
            var harvestable = dbContext.Harvestables
                .Include(h => h.Prices)
                .Include(h => h.MaterialContents)
                .Single(h => h.HarvestableId == entity.HarvestableId);

            harvestable.Name = entity.Name;
            harvestable.Description = entity.Description;
            harvestable.Type = entity.Type;
            harvestable.Icon = entity.Icon;
            harvestable.IsCompressedVariantOfType = entity.IsCompressedVariantOfType;
            harvestable.MaterialContents = entity.MaterialContents;
            harvestable.Prices = entity.Prices;

            return base.Update(harvestable);
        }

        public override IEnumerable<Harvestable> Find(Expression<Func<Harvestable, bool>> predicate)
        {
            return dbContext.Harvestables
                .Include(h => h.Prices)
                .Include(h => h.MaterialContents)
                .Where(predicate)
                .ToList();
        }

        public override IEnumerable<Harvestable> All()
        {
            return dbContext.Harvestables
                .Include(h => h.Prices)
                .Include(h => h.MaterialContents)
                .ThenInclude(mc => mc.Material)
                .ToList();
        }
    }
}
