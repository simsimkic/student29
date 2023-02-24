/***********************************************************************
 * Module:  ManagerDrugController.cs
 * Purpose: Definition of the Class Controller.ManagerDrugController
 ***********************************************************************/

using Repository;
using Service;
using System;

namespace Controller
{
   public class ManagerDrugController : DecoratedDrugController
   {
        private ManagerDrugService _drugService = new ManagerDrugService(new DrugService());
        public ManagerDrugController(IDrugController decoratedDrug) : base(decoratedDrug)
        {
        }

        public void AddDrug(String name, int quantity)
        {
            _drugService.AddDrug(name, quantity);
        }

    }
}