/***********************************************************************
 * Module:  IBlogService.cs
 * Purpose: Definition of the Interface Service.IBlogService
 ***********************************************************************/

using Model.Surveys;
using System;

namespace Service
{
   public interface IBlogService : IService<Blog>
   {
      Model.Surveys.Blog GetBlogByTitle(String title);
   }
}