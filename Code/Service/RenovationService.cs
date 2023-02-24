/***********************************************************************
 * Module:  RenovationService.cs
 * Purpose: Definition of the Class Service.RenovationService
 ***********************************************************************/

using Model.Rooms;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class RenovationService : IService<Renovation>
    {
        private readonly IRepository<Renovation> _renovationRepository = RenovationRepository.Instance;


        private static RenovationService instance = null;

        public static RenovationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RenovationService();
                }
                return instance;
            }
        }

        private RenovationService()
        {
        }

       
        public Renovation Create(Renovation obj)
        {
            Renovation renovation = _renovationRepository.Save(obj);

            return renovation;
        }

        public Renovation Edit(Renovation obj)
        {
            Renovation renovation = _renovationRepository.Edit(obj);
            return renovation;
        }

        public bool Delete(Renovation obj)
        {
            bool Correct = _renovationRepository.Delete(obj);
            return Correct;
        }

        public List<Renovation> GetAll()
        {
            return _renovationRepository.GetAll();
        }

        
   }
}