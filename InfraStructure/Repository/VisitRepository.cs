using CsvHelper;
using InfraStructure.Context;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<Visit> Save(Visit newVisit, string csvDbPath)
        {
            await this._context.AddAsync(newVisit);
            await this._context.SaveChangesAsync();
            using (var writer = File.AppendText(csvDbPath))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecord(newVisit);
                csv.NextRecord();
            }
            return newVisit;
        }

        private StreamWriter GetStreamWriter(string path)
        {
            return File.Exists(path) ? new StreamWriter(path)
                : File.CreateText(path);
        }
    }
}
