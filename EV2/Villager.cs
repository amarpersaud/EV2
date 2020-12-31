using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EV2
{
    public class Villager : Creature
    {
        
        public Occupation Occupation;

        
        public Villager(Vector2 Position)
        {
            this.Position = Position;
            //this.Name = NameGenerator.GenerateName();
        }


    }
    public enum Gender
    {
        Male,
        Female
    }
}
