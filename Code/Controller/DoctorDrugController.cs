/***********************************************************************
 * Module:  DoctorDrugController.cs
 * Purpose: Definition of the Class Controller.DoctorDrugController
 ***********************************************************************/

using Model.Rooms;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class DoctorDrugController : DecoratedDrugController
   {
        DoctorDrugService drugService = new DoctorDrugService(new DrugService());
        public DoctorDrugController(IDrugController decoratedDrug) : base(decoratedDrug)
        {
        }

        public Drug ValidateDrug(Drug drug)
        {
            return drugService.ValidateDrug(drug);
        }

        public Drug LowerQuantity(Drug drug)
        {
            return drugService.LowerQuantity(drug);
        }

        public Drug IncreaseQuantity(Drug drug)
        {
            return drugService.IncreaseQuantity(drug);
        }

        public List<Drug> GetUnvalidatedDrugs()
        {
            return drugService.GetUnvalidatedDrugs();
        }

        public List<Drug> GetValidatedDrugs()
        {
            return drugService.GetValidatedDrugs();
        }
    }
}