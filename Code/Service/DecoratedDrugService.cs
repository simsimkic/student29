/***********************************************************************
 * Module:  DecoratedDrugService.cs
 * Purpose: Definition of the Class Service.DecoratedDrugService
 ***********************************************************************/

using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Service
{
   public abstract class DecoratedDrugService : IDrugService
   {
      protected IDrugService drugServiceReference;

        public DecoratedDrugService(IDrugService iDrugService)
        {
            this.drugServiceReference = iDrugService;
        }

        public List<Drug> GetAllDrugs()
        {
            return drugServiceReference.GetAllDrugs();
        }
    }
}