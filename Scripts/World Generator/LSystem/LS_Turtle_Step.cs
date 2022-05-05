using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LSystem
{
    public class LS_Turtle_Step
    {
        public Vector3 Position, Direction;
        public int Length;

        public LS_Turtle_Step(Vector3 position, Vector3 direction, int length)
        {
            Position = position;
            Direction = direction;
            Length = length;
        }
    }
}
