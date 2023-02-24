using Model.Rooms;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Repository
{
    public interface IRehabilitationRoomRepository : IRepository<RehabilitationRoom>
    {
        RehabilitationRoom GetRoom(RehabilitationRoom room);

        RehabilitationRoom GetRoomById(long id);
    }
}
