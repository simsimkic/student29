/***********************************************************************
 * Module:  IDrugRepository.cs
 * Purpose: Definition of the Interface Repository.IDrugRepository
 ***********************************************************************/

using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IDrugRepository : IRepository<Drug>
   {
        bool DrugExists(string naziv);
        Drug GetDrugById(long id);
        Model.Rooms.Drug GetDrug(String naziv);
    }
}