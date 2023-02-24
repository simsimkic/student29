using Model.SystemUsers;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Service
{
    public interface IDoctorService : IService<Doctor>
    {
        Doctor ValidateLogin(string username, string password);
        List<Doctor> GetAllAvailableDoctors(DateTime _startDate, DateTime _endDate);
        Doctor GetDoctorByUsernameAndPassword(string username, string password);
    }
}
