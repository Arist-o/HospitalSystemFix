using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Domain
{
    public interface IPerson
    {
        string GetRoleInfo();
        string GetShortSummary();
        bool IsValid();
    }
}