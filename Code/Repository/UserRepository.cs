/***********************************************************************
 * Module:  UserRepository.cs
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using health_clinicClassDiagram.Repository.Sequencer;
using Model.SystemUsers;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class UserRepository : IUserRepository
   {
        private String _path;
        private static UserRepository instance;

        private readonly ICSVStream<RegisteredUser> _stream = new CSVStream<RegisteredUser>("C:\\health-clinic\\health-clinic\\Code\\resources\\data", new UserCSVConverter("|"));
        private readonly iSequencer<long> _sequencer =  new LongSequencer();

        public UserRepository GetInstance() { return null; }

        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserRepository();
                }
                return instance;
            }
        }

        private UserRepository()
        {
//            InitializeId();
        }

        public UserRepository(string path, CSVStream<RegisteredUser> stream, iSequencer<long> sequencer)
        {
            _path = path;
            _stream = stream;
            _sequencer = sequencer;
            _sequencer.Initialize(GetMaxId(_stream.ReadAll()));
        }

        private long GetMaxId(List<RegisteredUser> users)
        {
            return users.Count() == 0 ? 0 : users.Max(apt => apt.Id);
        }

        public RegisteredUser GetRegisteredUser(string username)
        {
            throw new NotImplementedException();
        }

        public RegisteredUser Save(RegisteredUser obj)
        {
            _stream.AppendToFile(obj);
            return obj;
        }

        public RegisteredUser Edit(RegisteredUser obj)
        {
            //var users = _stream.ReadAll().ToList();
            //users[users.FindIndex(apt => apt.Id == obj.Id)] = obj;
            //_stream.SaveAll(users);
            return obj;
        }

        public bool Delete(RegisteredUser obj)
        {
            var users = _stream.ReadAll().ToList();
            var userToRemove = users.SingleOrDefault(acc => acc.Id == obj.Id);
            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                _stream.SaveAll(users);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<RegisteredUser> GetAll()
        {
            var records = (List<RegisteredUser>)_stream.ReadAll();
            return records;
        }

        public bool OpenFile(string path)
        {
            throw new NotImplementedException();
        }

        public bool CloseFile(string path)
        {
            throw new NotImplementedException();
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));
    }
}