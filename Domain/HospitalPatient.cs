using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class HospitalPatient : Person
    {
        public string Diagnosis { get; set; }

        public List<Doctor> Doctors { get; set; } = new();

        public override string GetRoleInfo() => "Patient";
    }
}
