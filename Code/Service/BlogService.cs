/***********************************************************************
 * Module:  BlogService.cs
 * Purpose: Definition of the Class Service.BlogService
 ***********************************************************************/

using Model.Surveys;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class BlogService : IBlogService
    {
        private static BlogService instance = null;

        private BlogService()
        {
        }

        public static BlogService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BlogService();
                }
                return instance;
            }
        }

        public Blog GetBlogByTitle(string title)
        {
            return BlogRepository.Instance.GetBlog(title);
        }

        public Blog Create(Blog obj)
        {
            return BlogRepository.Instance.Save(obj);
        }

        public Blog Edit(Blog obj)
        {
            return BlogRepository.Instance.Edit(obj);
        }

        public bool Delete(Blog obj)
        {
            BlogRepository.Instance.Delete(obj);
            return true;
        }

        public List<Blog> GetAll()
        {
            return BlogRepository.Instance.GetAll();
        }

        
   
   }
}