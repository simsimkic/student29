using health_clinicClassDiagram.Repository;
using Model.SystemUsers;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Service
{
    public class SpecialistService : IService<Specialist>
    {

        private static SpecialistService instance;

        public static SpecialistService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SpecialistService();
                }
                return instance;
            }
        }

        private SpecialistService()
        {
        }

        public Specialist Create(Specialist obj)
        {
            return SpecialistRepository.Instance.Save(obj);
        }

        public bool Delete(Specialist obj)
        {
            return SpecialistRepository.Instance.Delete(obj);
        }

        public Specialist Edit(Specialist obj)
        {
            return SpecialistRepository.Instance.Edit(obj);
        }

        public List<Specialist> GetAll()
        {
            return SpecialistRepository.Instance.GetAll();
        }
    }
}
