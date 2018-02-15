using System;
using System.Collections.Generic;

namespace Koa.Model
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<BuildingLevel> Levels { get; set; } = new List<BuildingLevel>();

        public override string ToString()
        {
            return Name;
        }
    }

    public class BuildingLevel
    {
        public int Id { get; set; }

        public Building Building { get; set; }

        public int Level { get; set; }
        public int HeroXP { get; set; }

        public int Power { get; set; }

        public IList<BuildingRequirement> Requirements { get; set; } = new List<BuildingRequirement>();

        public IList<MaterialRequirement> Materials { get; set; } = new List<MaterialRequirement>();

        public TimeSpan Time { get; set; }
    }

    public class BuildingRequirement
    {
        public int Id { get; set; }

        public BuildingLevel BuildingLevel { get; set; }
        public BuildingLevel Requirement { get; set; }
    }

    public class MaterialRequirement
    {
        public int Id { get; set; }

        public BuildingLevel BuildingLevel { get; set; }

        public Material Material { get; set; }

        public int Amount { get; set; }
    }


    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}