using Controller;
using health_clinicClassDiagram.Service;
using Model.SystemUsers;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Controller
{
    public class PatientController : IController<Patient>
    {
        private readonly IService<Patient> _service = PatientService.Instance;

        private static PatientController instance;
        public static PatientController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PatientController();
                }
                return instance;
            }
        }

        private PatientController() { }

        public Patient Create(Patient obj)
        {
            return _service.Create(obj);
        }

        public bool Delete(Patient obj)
        {
            return _service.Delete(obj);
        }

        public Patient Edit(Patient obj)
        {
            return _service.Edit(obj);
        }

        public List<Patient> GetAll()
        {
            List<Patient> patients = (List<Patient>)_service.GetAll();
            return patients;
        }

    }
}
