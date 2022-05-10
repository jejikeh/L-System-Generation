using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS_WorldGenerator : MonoBehaviour
{

    /* todo 
        1. Remame core files
        2. Re - create LS_RULES and LS_TURTLESTEP 
    i think merge ls_rules and ls_turtlestep (encoding steps) in one class
    where actions will be a script reference

    */

    [Header("World Generation settings")]
    [SerializeField] private string _axiom;
    [SerializeField] private LSystem.StringGeneration.LS_Rules _rules;
    private string _sentence;
    private List<LSystem.TurtleStep> _steps = new List<LSystem.TurtleStep>();


    [Header("LSystem Visualizer")]
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Material _lineMaterial;
    [SerializeField] private int _length;
    [SerializeField] private float _angle;


    private LSystem.StringGeneration.LS_Generation _lsGeneration = new LSystem.StringGeneration.LS_Generation(); // l-system generator
    private LSystem.LS_Turtle _turtle = new LSystem.LS_Turtle();

    void Start()
    {
        _sentence = _axiom;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _sentence = _lsGeneration.GenerateSentence(_sentence, _rules);
            Debug.Log(_sentence);
            _steps = _turtle.GenerateSteps(_sentence, Vector3.zero, _length, _angle);
            CreateTree(_steps);
        }
        DebugDrawLine(_steps);
    }

    public void CreateTree(List<LSystem.TurtleStep> steps)
    {

        foreach(LSystem.TurtleStep step in steps)
        {
            Instantiate(_prefab,step.Position,Quaternion.identity);
            //Debug.Log(step.Direction);
        }
    }

    private void DebugDrawLine(List<LSystem.TurtleStep> steps)
    {
        for(int i = 1; i < steps.Count; i++)
        {
            Debug.DrawLine(steps[i - 1].Position,steps[i].Position,Color.black);
        }
    }
}