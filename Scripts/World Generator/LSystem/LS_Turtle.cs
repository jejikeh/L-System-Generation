using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSystem
{
    public class LS_Turtle
    { 

        public List<TurtleStep> GenerateSteps(string sentence, Vector3 startPosition, int length, float angle)
        {
            // to save and load steps in '[' and ']' rules
            Stack<TurtleStep> savedSteps = new Stack<TurtleStep>();

            // to store all points
            List<TurtleStep> allSteps = new List<TurtleStep>();


            TurtleStep currentStep = new TurtleStep(startPosition, Vector3.forward, length);


            allSteps.Add(new TurtleStep(currentStep));

             foreach (char c in sentence)
             {
                EncodingSteps steps = (EncodingSteps) c;
                switch (steps)
                {
                    case EncodingSteps.save:
                        savedSteps.Push(new TurtleStep(currentStep));
                        break;
                    case EncodingSteps.load:
                        if (savedSteps.Count > 0)
                            currentStep = savedSteps.Pop();
                        break;
                    case EncodingSteps.draw:
                        currentStep.Position += currentStep.Direction * currentStep.Length;
                        allSteps.Add(new TurtleStep(currentStep));
                        break;
                    case EncodingSteps.turnRight:
                        currentStep.Direction = Quaternion.AngleAxis(angle, Vector3.up) * currentStep.Direction;
                        break;
                    case EncodingSteps.turnLeft:
                        currentStep.Direction = Quaternion.AngleAxis(-angle, Vector3.up) * currentStep.Direction;
                        break;
                    default:
                        break;
                }
             }

             return allSteps;
        }
    }
}
