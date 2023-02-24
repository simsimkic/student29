/***********************************************************************
 * Module:  DecoratedDrugController.cs
 * Purpose: Definition of the Class Controller.DecoratedDrugController
 ***********************************************************************/

using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Controller
{
   public abstract class DecoratedDrugController : IDrugController
   {
      private IDrugController drugControllerReference;

        public DecoratedDrugController(IDrugController iDrugController)
        {
            this.drugControllerReference = iDrugController;
        }

        public List<Drug> GetAllDrugs()
        {
            return drugControllerReference.GetAllDrugs();
        }
    }
}