using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegoPartTracker.API.Entities;

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

        public SetPart GetSetPart(string setNumber, int partId)
        {
            return _context.Parts.Where(p => p.SetNumber == setNumber && p.Id == partId).FirstOrDefault();
        }

        public IQueryable<SetPart> GetSetParts(string setNumber)
        {
            return _context.Parts.Where(p => p.SetNumber == setNumber).OrderBy(p => p.PartNumber);
        }

        public IQueryable<Set> GetSets()
        {
            return _context.Sets.OrderBy(s => s.SetNumber);
        }

        public void AddSet(Set set)
        {
            _context.Sets.Add(set);
        }

        public void RemoveSet(string setNumber)
        {
            //TODO: this is not performant, tweak at some point
            var s = GetSet(setNumber);
            _context.Sets.Remove(s);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
