/***********************************************************************
 * Module:  TreatmentRepository.cs
 * Purpose: Definition of the Class Repository.TreatmentRepository
 ***********************************************************************/

using health_clinicClassDiagram.Repository.Sequencer;
using Model.Treatment;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using Repository.Csv.Converter;
using System.Linq;

namespace Repository
{
   public class TreatmentRepository : ITreatmentRepository
   {
        private readonly CSVStream<Treatment> _stream = new CSVStream<Treatment>("../../Resources/Data/Treatments.csv", new TreatmentCSVConverter(","));
        private readonly LongSequencer _sequencer = new LongSequencer();
        private TreatmentRepository()
        {
//            InitializeId();
        }
        private static TreatmentRepository instance = null;
        public static TreatmentRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TreatmentRepository();
                }
                return instance;
            }
        }

        private long GetMaxId(List<Treatment> treatments)
        {
            return treatments.Count() == 0 ? default : treatments.Max(trt => trt.Id);
        }

        public bool Delete(Treatment treatment)
        {
            List<Treatment> treatments = _stream.ReadAll().ToList();
            Treatment treatmentToRemove = treatments.SingleOrDefault(trt => trt.Id.CompareTo(treatment.Id) == 0);
            if (treatmentToRemove != null)
            {
                treatments.Remove(treatmentToRemove);
                _stream.SaveAll(treatments);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            List<Treatment> treatments = _stream.ReadAll().ToList();
            Treatment treatmentToRemove = treatments.SingleOrDefault(trt => trt.Id.CompareTo(id) == 0);
            if (treatmentToRemove != null)
            {
                treatments.Remove(treatmentToRemove);
                _stream.SaveAll(treatments);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Treatment Edit(Treatment obj)
        {
            List<Treatment> treatments = _stream.ReadAll().ToList();
            treatments[treatments.FindIndex(trt => trt.Id == obj.Id)] = obj;
            _stream.SaveAll(treatments);
            return obj;
        }

        public List<Treatment> GetAll()
        {
            return _stream.ReadAll();
        }

        public Treatment GetTreatment(long id)
        {
            return GetAll().Find(treat => treat.Id == id);
        }

        public Treatment Save(Treatment obj)
        {
//            obj.SetId(_sequencer.GenerateId());
            _stream.AppendToFile(obj);
            return obj;
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));
    }

}
