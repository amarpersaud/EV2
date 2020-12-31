using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EV2
{
    public class Villager : Creature
    {
        public Occupation Occupation;
        
        public Villager(Vector2 Position) : base()
        {
            this.Position = Position;

        }
    }
}
