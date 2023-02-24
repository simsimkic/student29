/***********************************************************************
 * Module:  EquipmentService.cs
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using Model.Rooms;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class DrugService : IDrugService
   {

        
        public DrugService()
        {

        }

        public List<Drug> GetAllDrugs()
        {
            return DrugRepository.Instance.GetAll();
        }
    }
}