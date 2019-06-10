using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajaNet.Domain.Models;

namespace InfraStructure.Repository
{
    public interface IVisitRepository
    {
        Task<Visit> Save(Visit newVisit);
    }
}
