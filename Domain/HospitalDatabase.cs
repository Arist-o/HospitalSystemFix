using System;
using System.Collections.Generic;
using System.Text;

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

                throw new IndexOutOfRangeException("Індекс лікаря поза межами діапазону.");
            }
            set
            {
                if (index >= 0 && index < Doctors.Count)
                    Doctors[index] = value;
                else
                    throw new IndexOutOfRangeException("Індекс лікаря поза межами діапазону.");
            }
        }
    }
}