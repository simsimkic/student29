/***********************************************************************
 * Module:  EquipmentService.cs
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using Model.Rooms;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class EquipmentController : IEquipmentController
   {

        private static EquipmentController instance = null;
        private readonly IEquipmentService _service = EquipmentService.Instance;

        public static EquipmentController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EquipmentController();
                }
                return instance;
            }
        }

        private EquipmentController()
        {

        }
        public List<Equipment> GetAll()
        {

            List<Equipment> equipments = (List<Equipment>)_service.GetAll();
            return equipments;

        }

        public bool Delete(Equipment obj)
        {
            return _service.Delete(obj);
        }

        public Equipment Create(Equipment obj)
        {
            return EquipmentService.Instance.Create(obj);
        }

        public Equipment Edit(Equipment obj)
        {
            return EquipmentService.Instance.Edit(obj);
        }

        public void AddEquipment(string name, int quant)
        {
            _service.AddEquipment(name, quant); 
        }

        public void DeleteEquipment(long Id, int quant)
        {
            _service.DeleteEquipment(Id, quant);
        }

        public string GetNazivOpreme(long Id)
        {
            return _service.GetNazivOpreme(Id);
        }

        public long GetIdOpreme(string name)
        {
            return _service.GetIdOpreme(name);
        }
    }
}