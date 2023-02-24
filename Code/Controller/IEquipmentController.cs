/***********************************************************************
 * Module:  IEquipmentController.cs
 * Purpose: Definition of the Interface Controller.IEquipmentController
 ***********************************************************************/

using Model.Rooms;
using System;

namespace Controller
{
   public interface IEquipmentController : IController<Equipment>
   {
        void AddEquipment(string name, int quant);
        void DeleteEquipment(long Id, int quant);

        String GetNazivOpreme(long Id);

        long GetIdOpreme(string name);
    }
}