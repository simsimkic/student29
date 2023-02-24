/***********************************************************************
 * Module:  UserRepository.cs
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using health_clinicClassDiagram.Repository.Sequencer;
using Model.Rooms;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class RenovationRepository : IRepository<Renovation>
    {
        private readonly ICSVStream<Renovation> _stream = new CSVStream<Renovation>("../../Resources/Data/renovations.csv", new RenovationCSVConverter(","));
        private readonly iSequencer<long> _sequencer = new LongSequencer();

        private static RenovationRepository instance;

        public static RenovationRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RenovationRepository();
                }
                return instance;
            }
        }


        private RenovationRepository()
        {
            // InitializeId();
        }

        private long GetMaxId(List<Renovation> renos)
        {
            return renos.Count() == 0 ? 0 : renos.Max(apt => apt.Id);
        }
        public Renovation GetRenovation(Renovation renovation)
        {
            throw new NotImplementedException();
        }

        public Renovation Save(Renovation obj)
        {
            //obj.Id = _sequencer.GenerateId();
            _stream.AppendToFile(obj);
            return obj;
        }

        public Renovation Edit(Renovation obj)
        {
            List<Renovation> renovations = _stream.ReadAll().ToList();
            renovations[renovations.FindIndex(apt => apt.Id == obj.Id)] = obj;
            _stream.SaveAll(renovations);
            return obj;
        }

        public bool Delete(Renovation obj)
        {
            List<Renovation> renovations = _stream.ReadAll().ToList();
            Renovation renovationToRemove = renovations.SingleOrDefault(reno => reno.Id == obj.Id);
            if (renovationToRemove != null)
            {
                renovations.Remove(renovationToRemove);
                _stream.SaveAll(renovations);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Renovation> GetAll()
        {
            List<Renovation> renovations = _stream.ReadAll();

            return renovations;
        }
        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

    }
}