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
    public class SurgeonController : IController<Surgeon>
    {
        private static SurgeonController instance = null;
        public IService<Surgeon> _service = SurgeonService.Instance;
        public static SurgeonController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SurgeonController();
                }
                return instance;
            }
        }

        private SurgeonController()
        {
        }

        public Surgeon Create(Surgeon obj)
        {
            return _service.Create(obj);
        }

        public bool Delete(Surgeon obj)
        {
            return _service.Delete(obj);

        }

        public Surgeon Edit(Surgeon obj)
        {
            return _service.Edit(obj);

        }

        public List<Surgeon> GetAll()
        {
            return _service.GetAll();
        }
    }
}
