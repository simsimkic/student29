/***********************************************************************
 * Module:  IBlogController.cs
 * Purpose: Definition of the Interface Controller.IBlogController
 ***********************************************************************/

using Model.Surveys;
using System;

namespace Controller
{
   public interface IBlogController : IController<Blog>
   {
      Model.Surveys.Blog GetBlogByTitle(String title);
   }
}