/***********************************************************************
 * Module:  ManagerDrugService.cs
 * Purpose: Definition of the Class Service.ManagerDrugService
 ***********************************************************************/

using Model.Rooms;
using Repository;
using System;

namespace Service
{
   public class ManagerDrugService : DecoratedDrugService
   {
        private DrugRepository _drugRepository = DrugRepository.Instance;
        public ManagerDrugService(IDrugService decoratedDrug) : base(decoratedDrug)
        {
        }
       
        public void AddDrug(String name, int quantity)
        {
            bool exists = _drugRepository.DrugExists(name);
            if (exists)
            {
                var Foundequip = _drugRepository.GetDrug(name);
                Foundequip.Quantity += quantity;
                _drugRepository.Edit(Foundequip);
            }
            else
            {
                Drug drug = new Drug(LongRandom(0, 100000, new Random()), name, quantity);
                var newDrug = _drugRepository.Save(drug);
            }
        }
        private long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }


    }
}