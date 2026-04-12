using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class HospitalDatabase
    {
        public List<Doctor> Doctors { get; set; } = new();
        public List<HospitalPatient> Patients { get; set; } = new();
    }
}
