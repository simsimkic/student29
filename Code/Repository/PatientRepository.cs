using health_clinicClassDiagram.Repository.Csv.Converter;
using health_clinicClassDiagram.Repository.Sequencer;
using Model.SystemUsers;
using Repository;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private static PatientRepository instance = null;
        private readonly ICSVStream<Patient> _stream = new CSVStream<Patient>("../../Resources/Data/patients.csv", new PatientCSVConverter(","));
        private readonly iSequencer<long> _sequencer = new LongSequencer();

        public static PatientRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PatientRepository();
                }
                return instance;
            }
        }

        private PatientRepository()
        {
            InitializeId();
        }

        private long GetMaxId(List<Patient> patients)
        {
            return patients.Count() == 0 ? 0 : patients.Max(apt => apt.Id);
        }

        public Patient Save(Patient obj)
        {
            obj.Id = (_sequencer.GenerateId()) + 1;
            _stream.AppendToFile(obj);
            return obj;
        }

        public Patient Edit(Patient obj)
        {
            List<Patient> patients = _stream.ReadAll().ToList();
            patients[patients.FindIndex(apt => apt.Id == obj.Id)] = obj;
            _stream.SaveAll(patients);
            return obj;
        }

        public bool Delete(Patient obj)
        {
            List<Patient> patients = _stream.ReadAll().ToList();
            Patient patientToRemove = patients.SingleOrDefault(acc => acc.Id == obj.Id);
            if (patientToRemove != null)
            {
                patients.Remove(patientToRemove);
                _stream.SaveAll(patients);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Patient> GetAll()
        {
            List<Patient> patients = (List<Patient>)_stream.ReadAll();
            return patients;
        }

        public Patient GetPatientById(long id)
        {
            var patients = _stream.ReadAll().ToList();
            return patients[patients.FindIndex(apt => apt.Id == id)];

        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));
    }
}
