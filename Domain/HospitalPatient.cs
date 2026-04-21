using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class HospitalPatient : Person
    {
        public string Diagnosis { get; set; }
        public List<Doctor> Doctors { get; set; } = new();

        public HospitalPatient() : base()
        {
            Diagnosis = "Undiagnosed";
        }

        public HospitalPatient(string fullName, string diagnosis) : base(fullName)
        {
            Diagnosis = diagnosis;
        }

        public override string GetRoleInfo() => "Patient";

        public override string GetShortSummary()
        {
            return base.GetShortSummary() + $" - Diagnosis: {Diagnosis}";
        }

        public override bool IsValid()
        {
            return base.IsValid() && !string.IsNullOrWhiteSpace(Diagnosis);
        }

        public void UpdateDiagnosis(string newDiagnosis)
        {
            if (!string.IsNullOrWhiteSpace(newDiagnosis))
            {
                Diagnosis = newDiagnosis;
            }
        }

        public void ClearDoctors()
        {
            Doctors.Clear();
        }

        public bool RequiresAttention()
        {
            return Diagnosis.Contains("Critical") || Doctors.Count == 0;
        }
    }
}