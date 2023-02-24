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
    public class SurgeonService : IService<Surgeon>
    {

        private static SurgeonService instance;

        public static SurgeonService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SurgeonService();
                }
                return instance;
            }
        }

        private SurgeonService()
        {
        }

        public Surgeon Create(Surgeon obj)
        {
            return SurgeonRepository.Instance.Save(obj);
        }

        public bool Delete(Surgeon obj)
        {
            return SurgeonRepository.Instance.Delete(obj);
        }

        public Surgeon Edit(Surgeon obj)
        {
            return SurgeonRepository.Instance.Edit(obj);
        }

        public List<Surgeon> GetAll()
        {
            return SurgeonRepository.Instance.GetAll();
        }
    }
}
