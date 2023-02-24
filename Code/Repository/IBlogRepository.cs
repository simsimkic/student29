/***********************************************************************
 * Module:  IBlogRepository.cs
 * Purpose: Definition of the Interface Repository.IBlogRepository
 ***********************************************************************/

using Model.Surveys;
using System;

namespace Repository
{
   public interface IBlogRepository : IRepository<Blog>
   {
      Model.Surveys.Blog GetBlog(String title);
   }
}