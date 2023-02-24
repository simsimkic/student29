using Controller;
using Model.SystemUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Controller
{
    public interface IDoctorController : IController<Doctor>
    {
        Doctor ValidateLogin(string username, string password);
        List<Doctor> GetAllAvailableDoctors(DateTime _startDate, DateTime _endDate);
        Doctor GetDoctorByUsernameAndPassword(string username, string password);
    }
}
