using LegoPartTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Services
{
    public interface ISetInfoRepository
    {
        bool SetExists(string setNumber);

        IQueryable<Set> GetSets();
        IQueryable<SetDetail> GetSetDetails();

        Set GetSet(string setNumber);
        SetDetail GetSetDetail(string setNumber);

        IQueryable<SetPart> GetSetParts(string setNumber);
        IQueryable<SetPartDetail> GetSetPartDetails(string setNumber);

        SetPart GetSetPart(string setNumber, int partId);
        SetPartDetail GetSetPartDetail(string setNumber, int partId);

        IQueryable<Category> GetCategories();

        Category GetCategory(int id);

        IQueryable<Group> GetGroups();

        void AddCategory(Category category);
        void RemoveCategory(Category category);

        void AddSet(Set set);
        void RemoveSet(string setNumber);

        void ClearFoundPartsFromSet(string setNumber);

        bool Save();
    }
}
