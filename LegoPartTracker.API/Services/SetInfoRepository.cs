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

        public void AddPartGroup(PartGroup partGroup)
        {
            _context.Add(partGroup);
        }

        public void AddSet(Set set)
        {
            _context.Sets.Add(set);
        }

        public void RemoveSet(string setNumber)
        {
            _context.Database.ExecuteSqlCommand($"delete Part where SetNumber = { setNumber }");
            _context.Database.ExecuteSqlCommand($"delete Set where SetNumber = { setNumber }");
        }

        public void ClearFoundPartsFromSet(string setNumber)
        {
            _context.Database.ExecuteSqlCommand($"update Part set QuantityFound = 0, QuantityFoundDateChanged = null where SetNumber = { setNumber }");
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IQueryable<SetPartDetail> GetSetPartDetails(string setNumber)
        {
            return _context.PartDetails.Where(p => p.SetNumber == setNumber).OrderByDescending(p => p.GroupName).ThenBy(p => p.Name);
        }

        public SetPartDetail GetSetPartDetail(string setNumber, int partId)
        {
            return _context.PartDetails.Where(p => p.SetNumber == setNumber && p.Id == partId).FirstOrDefault();
        }

        public IQueryable<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Name);
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<Group> GetGroups()
        {
            return _context.Groups.OrderBy(c => c.Name);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void RemoveCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PartGroupDetail> GetPartGroupDetailsWithoutGroup()
        {
            return _context.PartGroupDetails.Where(c => !c.GroupId.HasValue);
        }

        public IQueryable<PartGroupDetail> GetPartGroupDetailsWithoutGroup(int categoryId)
        {
            return _context.PartGroupDetails.Where(g => !g.GroupId.HasValue && g.CategoryId == categoryId);
        }
    }
}
