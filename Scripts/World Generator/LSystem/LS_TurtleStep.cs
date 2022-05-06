using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LSystem
{
    public class LS_TurtleStep
    {
        public Vector3 Position, Direction;
        public int Length;

        public LS_TurtleStep(Vector3 position, Vector3 direction, int length)
        {
            Position = position;
            Direction = direction;
            Length = length;
        }
        public LS_TurtleStep(Vector3 position)
        {
            Position = position;
        }
        public LS_TurtleStep(LS_TurtleStep turtle)
        {
            Position = turtle.Position; Direction = turtle.Direction; Length = turtle.Length;
        }
    }

    public enum EncodingSteps
    {
        save = '[',
        load = ']',
        draw = 'F',
        turnRight = '+',
        turnLeft = '-'
    }
}
