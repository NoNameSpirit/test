using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class AnimationConstant
    {
        public static class Character 
        {
            public const string Run = "run";
            public const string Attack = "attack";
            public const string Die = "Die";
            public const string Hurt = "Hurt";
            public const string Alive = "Alive";
            public const string RunVerticalUp = "RunVerticalUp";
            public const string RunVerticalDown = "RunVerticalDown";
            public const string AttackVerticalUp = "AttackVerticalUp";
            public const string AttackVerticalDown = "AttackVerticalDown";
        }

        public static class Slime
        {
            public const string Hurt = "Hurt";
            public const string Death = "IsDeath";
            public const string Attack = "Attack";
            public const string MoveToPlayer = "MoveToPlayer";
        }
    }
}
