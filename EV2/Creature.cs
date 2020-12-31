using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EV2
{
    public class Creature
    {
        public Vector2 Position { get; set; }
        public Vector2 TargetPosition { get; set; }

        public Queue<Intention> IntentionQueue;

        public string Name { get; set; }
        public int Level { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public StatGroup StatGroup { get; set; }

        public Creature()
        {

            IntentionQueue = new Queue<Intention>();
            StatGroup = new StatGroup();
        }
    }
}
