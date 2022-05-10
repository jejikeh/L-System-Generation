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


    [Header("LSystem Visualizer")]
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Material _lineMaterial;
    [SerializeField] private int _length;
    [SerializeField] private float _angle;
    private List<Vector3> _steps = new List<Vector3>();


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
            DrawTree(_turtle.GenerateSteps(_sentence, Vector3.zero, _length, _angle));
        }
    }

    public void DrawTree(List<LSystem.TurtleStep> steps)
    {

        foreach(LSystem.TurtleStep step in steps)
        {
            Instantiate(_prefab,step.Position,Quaternion.identity);
            //Debug.Log(step.Direction);
        }
    }

    private void DrawLine(List<Vector3> positions)
    {
        foreach (Vector3 position in positions)
        {
            Debug.DrawLine(position,)
        }
    }
}