/***********************************************************************
 * Module:  DoctorDrugService.cs
 * Purpose: Definition of the Class Service.DoctorDrugService
 ***********************************************************************/

using Model.Rooms;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class DoctorDrugService : DecoratedDrugService
    {
        public DoctorDrugService(IDrugService decoratedDrug) : base(decoratedDrug)
        {   
        }

        public Drug ValidateDrug(Drug drug)
        {
            Drug drugToValidate = DrugRepository.Instance.GetDrugById(drug.Id);
            drugToValidate.Validation = true;
            return DrugRepository.Instance.Edit(drugToValidate);
        }

        public Drug LowerQuantity(Drug drug)
        {
            Drug drugToEdit = DrugRepository.Instance.GetDrugById(drug.Id);
            drugToEdit.Quantity--;
            return DrugRepository.Instance.Edit(drugToEdit);
        }

        public Drug IncreaseQuantity(Drug drug)
        {
            Drug drugToEdit = DrugRepository.Instance.GetDrugById(drug.Id);
            drugToEdit.Quantity++;
            return DrugRepository.Instance.Edit(drugToEdit);
        }

        public List<Drug> GetUnvalidatedDrugs()
        {
            List<Drug> unvalidatedDrugs = new List<Drug>();
            foreach (Drug drug in GetAllDrugs())
            {
                if (drug.Validation == false) unvalidatedDrugs.Add(drug);
            }

            return unvalidatedDrugs;
        }

        public List<Drug> GetValidatedDrugs()
        {
            List<Drug> unvalidatedDrugs = new List<Drug>();
            foreach (Drug drug in GetAllDrugs())
            {
                if (drug.Validation == true) unvalidatedDrugs.Add(drug);
            }

            return unvalidatedDrugs;
        }

    }
}