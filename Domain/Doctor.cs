using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Doctor : Person
    {
        public string Specialty { get; set; }
        public List<HospitalPatient> Patients { get; set; } = new();

        public Doctor() : base()
        {
            Specialty = "General Practice";
        }

        public Doctor(string fullName, string specialty) : base(fullName)
        {
            Specialty = specialty;
        }

        public override string GetRoleInfo() => $"Doctor ({Specialty})";

        public override string GetShortSummary()
        {
            return base.GetShortSummary() + $" - Spec: {Specialty}";
        }

        public override bool IsValid()
        {
            return base.IsValid() && !string.IsNullOrWhiteSpace(Specialty);
        }

        public bool HasPatient(Guid patientId)
        {
            return Patients.Any(p => p.Id == patientId);
        }

        public void UpdateSpecialty(string newSpecialty)
        {
            if (!string.IsNullOrWhiteSpace(newSpecialty))
            {
                Specialty = newSpecialty;
            }
        }

        public int GetPatientCount()
        {
            return Patients.Count;
        }
    }
}