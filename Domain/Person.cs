using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain
{
    [JsonDerivedType(typeof(Doctor), typeDiscriminator: "doctor")]
    [JsonDerivedType(typeof(HospitalPatient), typeDiscriminator: "patient")]
    public abstract class Person : IPerson
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }

        public Person()
        {
            FullName = "Unknown";
        }

        public Person(string fullName)
        {
            FullName = fullName;
        }

        public abstract string GetRoleInfo();

        public virtual string GetShortSummary()
        {
            return $"{FullName} (ID: {GetIdString()})";
        }

        public void UpdateFullName(string newName)
        {
            if (!string.IsNullOrWhiteSpace(newName))
            {
                FullName = newName;
            }
        }

        public string GetIdString()
        {
            return Id.ToString().Substring(0, 8);
        }

        public virtual bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(FullName);
        }
    }
}