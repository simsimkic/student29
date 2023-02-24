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
   public class EquipmentService : IEquipmentService
   {
        private static EquipmentService instance = null;
        public IEquipRepository _equipmentRepository = EquipRepository.Instance;
        public static EquipmentService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EquipmentService();
                }
                return instance;
            }
        }

        private EquipmentService()
        {

        }

        public Equipment Create(Equipment obj)
        {
            var newEquip = _equipmentRepository.Save(obj);


            return newEquip;
        }

        public Equipment Edit(Equipment obj)
        {
            _equipmentRepository.Edit(obj);
            return obj;
        }

        public bool Delete(Equipment obj)
        {
            _equipmentRepository.Delete(obj);
            return true;
        }

        public List<Equipment> GetAll()
        {
            var rooms = _equipmentRepository.GetAll();
            return rooms;
        }

        public void AddEquipment(string name, int quant)
        {
            bool postoji = _equipmentRepository.EquipExists(name);
            if (postoji)
            {
                var Foundequip = _equipmentRepository.GetEquip(name);
                Foundequip.Quantity += quant;
                _equipmentRepository.Edit(Foundequip);
            }
            else
            {
                Equipment equipment = new Equipment(LongRandom(0, 100000, new Random()), name, quant);
                var newEquipment = _equipmentRepository.Save(equipment);
            }

        }

        public void DeleteEquipment(long Id, int quant)
        {
            bool postoji = _equipmentRepository.EquipExists(Id);
            if (postoji)
            {
                var Foundequip = _equipmentRepository.GetEquip(Id);
                Foundequip.Quantity -= quant;
                _equipmentRepository.Edit(Foundequip);
            }
        }

        public string GetNazivOpreme(long Id)
        {
            var eqs = _equipmentRepository.GetAll();
            foreach (Equipment e in eqs)
            {
                if (e.Id == Id)
                {
                    return e.Name;
                   
                }
            }
            return "ne postoji";
        }

        public long GetIdOpreme(string name)
        {
            var eqs = _equipmentRepository.GetAll();
            foreach (Equipment e in eqs)
            {
                if (e.Name.Equals(name))
                {
                    return e.Id;
                    
                }
            }
            return -1;
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