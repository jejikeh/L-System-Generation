using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSystem
{
    public class LS_Turtle
    { 

        public List<LS_TurtleStep> GenerateSteps(string sentence, Vector3 startPosition, int length, float angle)
        {
            // to save and load steps in '[' and ']' rules
            Stack<LS_TurtleStep> savedSteps = new Stack<LS_TurtleStep>();

            // to store all points
            List<LS_TurtleStep> allSteps = new List<LS_TurtleStep>();


            LS_TurtleStep currentStep = new LS_TurtleStep(startPosition, Vector3.forward, length);
            //LS_TurtleStep tempStep = new LS_TurtleStep(startPosition);


            allSteps.Add(currentStep);

             foreach (char c in sentence)
            {
                EncodingSteps steps = (EncodingSteps) c;
                switch (steps)
                {
                    case EncodingSteps.save:
                        savedSteps.Push(new LS_TurtleStep(currentStep));
                        break;
                    case EncodingSteps.load:
                        if (savedSteps.Count > 0)
                        {
                            currentStep = savedSteps.Pop();
                        }
                        break;
                    case EncodingSteps.draw:
                        currentStep.Position += currentStep.Direction * currentStep.Length;
                        //currentStep.Length -= 2;
                        allSteps.Add(new LS_TurtleStep(currentStep));
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
