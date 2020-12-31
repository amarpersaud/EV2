using System.Collections.Generic;

namespace EV2
{
    public struct StatGroup
    {
        public int Exp { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public Dictionary<StatName, int> Stats;

    }
    public enum StatName
    {
        ATK,
        DEF,
        VIT,
        INT,
        WIS,
        LUK,
        AGI,
        DEX
    }
}