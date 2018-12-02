using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegoPartTracker.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LegoPartTracker.API.Services
{
    public class SetInfoRepository : ISetInfoRepository
    {
        private SetInfoContext _context;

        public SetInfoRepository(SetInfoContext context)
        {
            _context = context;
        }

        public bool SetExists(string setNumber)
        {
            return _context.Sets.Any(s => s.SetNumber == setNumber);
        }

        public Set GetSet(string setNumber)
        {
            return _context.Sets.Where(s => s.SetNumber == setNumber).FirstOrDefault();
        }

        public SetDetail GetSetDetail(string setNumber)
        {
            return _context.SetDetails.Where(s => s.SetNumber == setNumber).FirstOrDefault();
        }

        public SetPart GetSetPart(string setNumber, int partId)
        {
            return _context.Parts.Where(p => p.SetNumber == setNumber && p.Id == partId).FirstOrDefault();
        }

        public IQueryable<SetPart> GetSetParts(string setNumber)
        {
            return _context.Parts.Where(p => p.SetNumber == setNumber).OrderByDescending(p => p.QuantityFoundDateChanged).ThenBy(p => p.Name);
        }

        public IQueryable<Set> GetSets()
        {
            return _context.Sets.OrderBy(s => s.SetNumber);
        }

        public IQueryable<SetDetail> GetSetDetails()
        {
            return _context.SetDetails.OrderBy(s => s.SetNumber);
        }

        public void AddSet(Set set)
        {
            _context.Sets.Add(set);
        }

        public void RemoveSet(string setNumber)
        {
            _context.Database.ExecuteSqlCommand($"delete Parts where SetNumber = { setNumber }");
            _context.Database.ExecuteSqlCommand($"delete Sets where SetNumber = { setNumber }");
        }

        public void ClearFoundPartsFromSet(string setNumber)
        {
            _context.Database.ExecuteSqlCommand($"update Parts set QuantityFound = 0, QuantityFoundDateChanged = null where SetNumber = { setNumber }");
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
