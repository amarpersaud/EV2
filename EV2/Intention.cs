using System;
using System.Collections.Generic;
using System.Text;

namespace EV2
{
    public class Intention
    {
        public Action Action { get; set; }
        public object Target { get; set; }

        public bool IsValid(Creature performer)
        {
            switch (Action)
            {
                case Action.Attack:
                    if(performer is Villager)
                    {
                        return (Target is Creature) && !(Target is Villager);   //Cannot be villager attacking Villager
                    }
                    else
                    {
                        return Target is Creature;  //Monsters can attack villagers or other monsters.
                    }
                //TODO: validate other actions
            }

            if (Target == null)
            {
                return false;
            }
            return true;
        }

    }

    public enum Action
    {
        Attack,
        Create,
        Build,
        Plant,
        PickUp,
        Heal,
        Avoid,
        GoTo

    }
}
