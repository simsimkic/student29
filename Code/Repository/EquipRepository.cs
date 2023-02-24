/***********************************************************************
 * Module:  UserRepository.cs
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using health_clinicClassDiagram.Repository.Sequencer;
using Model.Rooms;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class EquipRepository : IEquipRepository
   {
        private static EquipRepository instance = null;
        private readonly CSVStream<Equipment> _stream = new CSVStream<Equipment>("../../Resources/Data/Equipments.csv", new EquipmentCSVConverter(","));
        private readonly LongSequencer _sequencer = new LongSequencer();

        public EquipRepository GetInstance() { return null; }

        private EquipRepository()
        {
            //InitializeId();
        }

        public static EquipRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EquipRepository();
                }
                return instance;
            }
        }


        private long GetMaxId(List<Equipment> equipments)
        {
            return equipments.Count() == 0 ? 0 : equipments.Max(eq => eq.Id);
        }


        public Equipment GetEquip(Equipment equipment)
        {
            List<Equipment> equipments = _stream.ReadAll().ToList();
            return equipments[equipments.FindIndex(apt => apt.Name.Equals(equipment.Name))];
        }

        public Equipment Save(Equipment obj)
        {
            // obj.Id = _sequencer.GenerateId();
            _stream.AppendToFile(obj);
            return obj;
        }

        public Equipment Edit(Equipment obj)
        {
            List<Equipment> equipments = _stream.ReadAll().ToList();
            equipments[equipments.FindIndex(eq => eq.Id == obj.Id)] = obj;
            _stream.SaveAll(equipments);
            return obj;
        }

        public bool Delete(Equipment obj)
        {
            List<Equipment> equipments = _stream.ReadAll().ToList();
            Equipment equipmentToRemove = equipments.SingleOrDefault(eq => eq.Id == obj.Id);
            if (equipmentToRemove != null)
            {
                equipments.Remove(equipmentToRemove);
                _stream.SaveAll(equipments);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Equipment> GetAll()
        {
            List<Equipment> equipments = _stream.ReadAll();
            return equipments;
        }

        public bool EquipExists(string name)
        {
            List<Equipment> equipments = _stream.ReadAll().ToList();
            foreach (Equipment equipment in equipments)
            {
                if (equipment.Name.Equals(name))
                {
                    return true;
                    
                }
            }
            return false;
        }

        public Equipment GetEquip(long id)
        {
            List<Equipment> equipments = _stream.ReadAll().ToList();
            return equipments[equipments.FindIndex(apt => apt.Id == id)];
        }

        public bool EquipExists(long id)
        {
            List<Equipment> equipments = _stream.ReadAll().ToList();
            foreach (Equipment equipment in equipments)
            {
                if (equipment.Id == id)
                {
                    return true;
                   
                }
            }
            return false;
        }

        public Equipment GetEquip(string name)
        {
            List<Equipment> equipments = _stream.ReadAll().ToList();
            return equipments[equipments.FindIndex(apt => apt.Name.Equals(name))];
        }
        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));
    }
}