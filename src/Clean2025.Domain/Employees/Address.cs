using Clean2025.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean2025.Domain.Employees
{
    public sealed record Address
    {
        
        public Country? Country{get;set;}
        public City? City{get;set;}
        public Town? Town{get;set;}
        public FullAddress? FullAddress{get;set;}
    }
}