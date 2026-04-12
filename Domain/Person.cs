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

        public abstract string GetRoleInfo();

    }
}
