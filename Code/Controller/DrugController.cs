/***********************************************************************
 * Module:  EquipmentService.cs
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using Model.Rooms;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class DrugController : IDrugController
   {
        DrugService drugService = new DrugService();
        public DrugController()
        {
        }

        public List<Drug> GetAllDrugs()
        {
            return drugService.GetAllDrugs();
        }

    }
}