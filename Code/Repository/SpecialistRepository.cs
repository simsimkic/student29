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
    public class SpecialistRepository : ISpecialistRepository
    {
        private static SpecialistRepository instance = null;
        private readonly CSVStream<Specialist> _stream = new CSVStream<Specialist>("../../Resources/Data/Specialists.csv", new SpecialistCSVConverter(","));
        private readonly LongSequencer _sequencer = new LongSequencer();
        public static SpecialistRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SpecialistRepository();
                }
                return instance;
            }
        }

        private SpecialistRepository()
        {
        }

        private long GetMaxId(List<Specialist> specialists)
        {
            return specialists.Count() == 0 ? 0 : specialists.Max(apt => apt.Id);
        }

        public bool Delete(Specialist obj)
        {
            List<Specialist> doctors = _stream.ReadAll().ToList();
            Specialist doctorToRemove = doctors.SingleOrDefault(acc => acc.Id == obj.Id);
            if (doctorToRemove != null)
            {
                doctors.Remove(doctorToRemove);
                _stream.SaveAll(doctors);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Specialist Edit(Specialist obj)
        {
            List<Specialist> doctors = _stream.ReadAll().ToList();
            doctors[doctors.FindIndex(apt => apt.Id == obj.Id)] = obj;
            _stream.SaveAll(doctors);
            return obj;
        }

        public List<Specialist> GetAll()
        {
            List<Specialist> doctors = (List<Specialist>)_stream.ReadAll();
            return doctors;
        }

        public Specialist Save(Specialist obj)
        {
            _stream.AppendToFile(obj);
            return obj;
        }

        public Specialist GetSpecialistById(long id)
        {
            return GetAll().Find(specialist => specialist.Id == id);
        }
    }
}
