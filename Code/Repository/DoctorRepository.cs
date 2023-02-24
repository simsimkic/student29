using health_clinicClassDiagram.Repository.Csv.Converter;
using health_clinicClassDiagram.Repository.Sequencer;
using Model.SystemUsers;
using Repository;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace health_clinicClassDiagram.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private static DoctorRepository instance = null;

        private readonly ICSVStream<Doctor> _stream = new CSVStream<Doctor>("../../Resources/Data/doctors.csv", new DoctorCSVConverter(","));
        private readonly iSequencer<long> _sequencer = new LongSequencer();

        public static DoctorRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DoctorRepository();
                }
                return instance;
            }
        }

        private DoctorRepository()
        {
        }

        private long GetMaxId(List<Doctor> doctors)
        {
            return doctors.Count() == 0 ? 0 : doctors.Max(apt => apt.Id);
        }

        public bool Delete(Doctor obj)
        {
            List<Doctor> doctors = _stream.ReadAll().ToList();
            Doctor doctorToRemove = doctors.SingleOrDefault(acc => acc.Id == obj.Id);
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

        public Doctor Edit(Doctor obj)
        {
            List<Doctor> doctors = _stream.ReadAll().ToList();
            doctors[doctors.FindIndex(apt => apt.Id == obj.Id)] = obj;
            _stream.SaveAll(doctors);
            return obj;
        }

        public List<Doctor> GetAll()
        {
            List<Doctor> doctors = (List<Doctor>)_stream.ReadAll();
            return doctors;
        }

        public Doctor Save(Doctor obj)
        {
            _stream.AppendToFile(obj);
            return obj;
        }

        public Doctor GetDoctorById(long id)
        {
            List<Doctor> doctors = GetAll();
            return doctors[doctors.FindIndex(apt => apt.Id == id)];

        }
    }
}
