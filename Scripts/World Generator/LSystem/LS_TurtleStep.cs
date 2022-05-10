using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LSystem
{

    public struct TurtleStep
    {
        public Vector3 Position, Direction;
        public int Length;

        public TurtleStep(Vector3 position, Vector3 direction, int length)
        {
            Position = position;
            Direction = direction;
            Length = length;
        }
        public TurtleStep(TurtleStep turtleStep){
            Position = turtleStep.Position;
            Direction = turtleStep.Direction;
            Length = turtleStep.Length;
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
