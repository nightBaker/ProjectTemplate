using ProjectTemplate.APPLICATION.Interfaces;
using System;

namespace ProjectTemplate.INFRASTRUCTURE
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
        public int CurrentYear => DateTime.Now.Year;
    }
}
