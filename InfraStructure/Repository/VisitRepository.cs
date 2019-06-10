using InfraStructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajaNet.Domain.Models;

namespace InfraStructure.Repository
{
    public class VisitRepository : IVisitRepository
    {
        public readonly DataContext _context;
        public VisitRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Visit> Save(Visit newVisit)
        {
            await this._context.AddAsync(newVisit);
            await this._context.SaveChangesAsync();



            return newVisit;
        }
    }
}
