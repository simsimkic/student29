/***********************************************************************
 * Module:  RenovationController.cs
 * Purpose: Definition of the Class Controller.RenovationController
 ***********************************************************************/

using Model.Rooms;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class RenovationController : IController<Renovation>
    {
        private readonly IService<Renovation> _renovationService = RenovationService.Instance;

        private static RenovationController instance;

        public static RenovationController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RenovationController();
                }
                return instance;
            }
        }

        private RenovationController() { }
        public List<Renovation> GetAll()
        {
            return _renovationService.GetAll();
        }

        public bool Delete(Renovation obj)
        {
            return _renovationService.Delete(obj);
        }

        public Renovation Create(Renovation obj)
        {
            return _renovationService.Create(obj);
        }

        public Renovation Edit(Renovation obj)
        {
            return _renovationService.Edit(obj);
        }

      

      
   
   }
}