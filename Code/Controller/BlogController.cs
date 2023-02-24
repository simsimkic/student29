/***********************************************************************
 * Module:  BlogService.cs
 * Purpose: Definition of the Class Service.BlogService
 ***********************************************************************/

using Model.Surveys;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class BlogController : IBlogController
   {
        private static BlogController instance = null;

        private BlogController()
        {
        }

        public static BlogController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BlogController();
                }
                return instance;
            }
        }
        public Blog GetBlogByTitle(string title)
        {
            return BlogService.Instance.GetBlogByTitle(title);
        }

        public List<Blog> GetAll()
        {
           return BlogService.Instance.GetAll();
        }

        public bool Delete(Blog obj)
        {
            BlogService.Instance.Delete(obj);
            return true;
        }

        public Blog Create(Blog obj)
        {
            return BlogService.Instance.Create(obj);
        }

        public Blog Edit(Blog obj)
        {
            return BlogService.Instance.Edit(obj);
        }
   }
}