/***********************************************************************
 * Module:  UserRepository.cs
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using health_clinicClassDiagram.Repository.Sequencer;
using Model.Surveys;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class BlogRepository : IBlogRepository
   {
        private readonly CSVStream<Blog> _stream = new CSVStream<Blog>("../../Resources/Data/BlogRepo.csv", new BlogCSVConverter(","));//TODO: Namesti stream kao Stefan
        private readonly LongSequencer _sequencer = new LongSequencer();
        private static BlogRepository instance = null;

        private BlogRepository()
        {
        }

        public static BlogRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BlogRepository();
                }
                return instance;
            }
        }

        public Blog GetBlog(string title)
        {
            return GetAll().Find(blog => blog.Title.Equals(title));
        }

        public Blog Save(Blog obj)
        {
//            obj.SetId(_sequencer.GenerateId());
            _stream.AppendToFile(obj);
            return obj;
        }

        public Blog Edit(Blog obj)
        {
            List<Blog> blogs = _stream.ReadAll().ToList();
            blogs[blogs.FindIndex(blog => blog.Title == obj.Title)] = obj;
            _stream.SaveAll(blogs);
            return obj;
        }

        public bool Delete(Blog obj)
        {
            List<Blog> blogs = _stream.ReadAll().ToList();
            Blog blogToRemove = blogs.SingleOrDefault(ent => ent.Title.CompareTo(obj.Title) == 0);
            if (blogToRemove != null)
            {
                blogs.Remove(blogToRemove);
                _stream.SaveAll(blogs);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Blog> GetAll()
        {
            return _stream.ReadAll();
        }

    }
}