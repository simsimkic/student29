/***********************************************************************
 * Module:  IEquipmentService.cs
 * Purpose: Definition of the Interface Service.IEquipmentService
 ***********************************************************************/

using Model.Rooms;
using System;

namespace Service
{
   public interface IEquipmentService : IService<Equipment>
   {
        void AddEquipment(string name, int quant);
        void DeleteEquipment(long Id, int quant);

        String GetNazivOpreme(long Id);

        long GetIdOpreme(string name);
    }
}