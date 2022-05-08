L-System for Unity.

## How to use?
1. Prepare strings:

```C#
// First create axiom and sentence
private string _axiom = "FF";  // like a starting point
private _sentence = _axiom 
```

2. l-system classes
```C#
private LSystem.StringGeneration.LS_Generation _lsGeneration = new LSystem.StringGeneration.LS_Generation(); // l-system generator
private LSystem.LS_Turtle _turtle = new LSystem.LS_Turtle();
```
3. Generate sentence
```C#
// generate a new sentence
_sentence = _lsGeneration.GenerateSentence(_sentence, _rules); // return a string
```
4. Generate points
```C#
_turtle.GenerateSteps(_sentence, Vector3.zero, _length, _angle); // return a  TurtleStep class (vector3 position, direction; int length);
```
you can re-write LS_TutrleStep to just use Vector3 instead of class properties
