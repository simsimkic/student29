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
    public class SpecialistController : IController<Specialist>
    {
        private static SpecialistController instance = null;
        public IService<Specialist> _service = SpecialistService.Instance;
        public static SpecialistController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SpecialistController();
                }
                return instance;
            }
        }

        private SpecialistController()
        {
        }

        public Specialist Create(Specialist obj)
        {
            return _service.Create(obj);
        }

        public bool Delete(Specialist obj)
        {
            return _service.Delete(obj);

        }

        public Specialist Edit(Specialist obj)
        {
            return _service.Edit(obj);

        }

        public List<Specialist> GetAll()
        {
            return _service.GetAll();
        }
    }
}
