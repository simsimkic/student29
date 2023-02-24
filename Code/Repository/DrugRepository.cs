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
   public class DrugRepository : IDrugRepository
   {
        private static DrugRepository instance = null;
        private readonly CSVStream<Drug> _stream = new CSVStream<Drug>("../../Resources/Data/Drugs.csv", new DrugCSVConverter(","));
        private readonly LongSequencer _sequencer = new LongSequencer();

        public DrugRepository GetInstance() { return null; }

        private DrugRepository()
        {
            //InitializeId();
        }

        public static DrugRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DrugRepository();
                }
                return instance;
            }
        }


        private long GetMaxId(List<Drug> equip)
        {
            return equip.Count() == 0 ? 0 : equip.Max(eq => eq.Id);
        }

        public Drug Save(Drug obj)
        {
            // obj.Id = _sequencer.GenerateId();
            _stream.AppendToFile(obj);
            return obj;
        }

        public Drug Edit(Drug obj)
        {
            List<Drug> drugs = _stream.ReadAll().ToList();
            drugs[drugs.FindIndex(dr => dr.Id == obj.Id)] = obj;
            _stream.SaveAll(drugs);
            return obj;
        }

        public bool Delete(Drug obj)
        {
            List<Drug> drugs = _stream.ReadAll().ToList();
            Drug drugsToRemove = drugs.SingleOrDefault(dr => dr.Id == obj.Id);
            if (drugsToRemove != null)
            {
                drugs.Remove(drugsToRemove);
                _stream.SaveAll(drugs);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Drug> GetAll()
        {
            List<Drug> drugs = _stream.ReadAll();
            return drugs;
        }

        public bool DrugExists(string name)
        {
            var drugs = _stream.ReadAll().ToList();
            foreach (Drug drug in drugs)
            {
                if (drug.Name.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        public Drug GetDrug(string name)
        {
            List<Drug> drugs = _stream.ReadAll().ToList();
            return drugs[drugs.FindIndex(apt => apt.Name.Equals(name))];
        }

        public Drug GetDrugById(long id)
        {
            List<Drug> drugs = _stream.ReadAll().ToList();
            return drugs[drugs.FindIndex(ent => ent.Id == id)];
        }
        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));
    }
}