using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class HospitalDatabase
    {
        public List<Doctor> Doctors { get; set; } = new();
        public List<HospitalPatient> Patients { get; set; } = new();

        public Doctor this[int index]
        {
            get
            {
                if (index >= 0 && index < Doctors.Count)
                    return Doctors[index];

                throw new IndexOutOfRangeException("Doctor index is out of range.");
            }
            set
            {
                if (index >= 0 && index < Doctors.Count)
                    Doctors[index] = value;
                else
                    throw new IndexOutOfRangeException("Doctor index is out of range.");
            }
        }

        public void AddLink(Doctor doctor, HospitalPatient patient)
        {
            if (doctor == null || patient == null) return;

            if (!doctor.HasPatient(patient.Id))
            {
                doctor.Patients.Add(patient);
            }

            if (!patient.Doctors.Any(d => d.Id == doctor.Id))
            {
                patient.Doctors.Add(doctor);
            }
        }

        public void RemoveLink(Doctor doctor, HospitalPatient patient)
        {
            if (doctor == null || patient == null) return;

            doctor.Patients.RemoveAll(p => p.Id == patient.Id);
            patient.Doctors.RemoveAll(d => d.Id == doctor.Id);
        }

        public Doctor? FindDoctorByName(string name)
        {
            return Doctors.FirstOrDefault(d => d.FullName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public HospitalPatient? FindPatientByName(string name)
        {
            return Patients.FirstOrDefault(p => p.FullName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}