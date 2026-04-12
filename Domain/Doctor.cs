using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Doctor : Person
    {

        public string Specialty { get; set; }

        public List<HospitalPatient> Patients { get; set; } = new();

        public override string GetRoleInfo() => $"Doctor ({Specialty})";
    }
}
