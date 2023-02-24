/***********************************************************************
 * Module:  IRoomController.cs
 * Purpose: Definition of the Interface Controller.IRoomController
 ***********************************************************************/

using Model.Rooms;
using Model.SystemUsers;
using System;
using System.Collections.Generic;

namespace Controller
{
   public interface IRoomController : IController<Room>
   {
        Room IncreaseQuantity(Room r, Equipment eq);
        Room DecreaseQuantity(Room r, Equipment eq);
   }
}