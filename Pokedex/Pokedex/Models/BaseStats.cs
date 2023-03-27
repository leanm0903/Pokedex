using Pokedex.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Models
{
    public class BaseStats : IDetailModel
    {
        public decimal HealthPoints { get; set; }
        public string Name { get; set; }
    }
}
