/***********************************************************************
 * Module:  RoomService.cs
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using Model.Rooms;
using Model.SystemUsers;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class RoomService : IRoomService
   {
        private readonly IRoomRepository _roomRepository = RoomRepository.Instance;


        private static RoomService instance = null;

        public static RoomService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomService();
                }
                return instance;
            }
        }

        private RoomService()
        {
        }
        public bool IsRoomFree(DateTime from, DateTime to, Room room)
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetAllPatientsByRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public bool AddPatient(Patient patient, Room room)
        {
            throw new NotImplementedException();
        }

        public Room Create(Room obj)
        {
            var newRoom = _roomRepository.Save(obj);

            return newRoom;
        }

        public Room Edit(Room obj)
        {
            var newRoom = _roomRepository.Edit(obj);

            return newRoom;
        }

        public bool Delete(Room obj)
        {
            var newRoom = _roomRepository.Delete(obj);

            return true;
        }

        public List<Room> GetAll()
        {
            var rooms = _roomRepository.GetAll();
            return rooms;
        }

        public Room IncreaseQuantity(Room room, Equipment equipment)
        {
            foreach (Equipment equipmentInRoom in room.Equipments)
            {
                if (equipmentInRoom.Id == equipment.Id)
                {
                    equipmentInRoom.Quantity += equipment.Quantity;
                    return room;
                }
            }
            room.Equipments.Add(equipment);
            return room;
        }

        public Room DecreaseQuantity(Room room, Equipment equipment)
        {
            foreach (Equipment equipmentInRoom in room.Equipments)
            {
                if (equipmentInRoom.Id == equipment.Id)
                {
                    if ((equipmentInRoom.Quantity - equipment.Quantity) < 0)
                    {
                        return room;
                    }
                    equipmentInRoom.Quantity -= equipment.Quantity;
                    if (equipmentInRoom.Quantity == 0)
                    {
                        room.Equipments.Remove(equipment);
                    }
                    return room;
                }
            }
            return room;
        }

    }
}