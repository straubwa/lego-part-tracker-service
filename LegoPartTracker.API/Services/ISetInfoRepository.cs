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

        Set GetSet(string setNumber);

        IQueryable<SetPart> GetSetParts(string setNumber);

        SetPart GetSetPart(string setNumber, int partId);

        void AddSet(Set set);

        void RemoveSet(string setNumber);

        bool Save();
    }
}
