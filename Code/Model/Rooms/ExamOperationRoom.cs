/***********************************************************************
 * Module:  Exam/operationRoom.cs
 * Purpose: Definition of the Class Rooms.Exam/operationRoom
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model.Rooms
{
   public class ExamOperationRoom : Room
   {  

        public long _id;
       
        public ExamOperationRoom() : base()
        {
            
        }
        public ExamOperationRoom(long id, TypeOfRoom type) : base(id, type)
        {
            this.Id = id;
            type = TypeOfRoom.EXAMOPERATION;
        }

        public ExamOperationRoom(long id, List<Equipment> equipments) : base(id)
        {
            this.Id = id;
            TypeOfRoom = TypeOfRoom.EXAMOPERATION;
            Equipments = equipments;
        }
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
   

}
