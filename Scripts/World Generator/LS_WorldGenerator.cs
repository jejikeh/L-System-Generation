using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS_WorldGenerator : MonoBehaviour
{
    [Header("World Generation settings")]
    [SerializeField] private string _axiom;
    [SerializeField] private LSystem.StringGeneration.LS_Rules _rules;
    private LSystem.StringGeneration.LS_Generation _lsGeneration = new LSystem.StringGeneration.LS_Generation(); // l-system generator
    private string _sentence;


    [Header("LSystem Visualizer")]
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Material _lineMaterial;
    [SerializeField] private int _length;
    [SerializeField] private float _angle;
    private List<Vector3> _steps = new List<Vector3>();


    //private LS_Turtle _turtle = new LS_Turtle();

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
            DrawTree();
        }
    }

    public void DrawTree()
    {
        Stack<LSystem.LS_Turtle> points = new Stack<LSystem.LS_Turtle>();
        Vector3 currentPosition = Vector3.zero;
        Vector3 tempPosition = Vector3.zero;
        Vector3 direction = Vector3.forward;

        _steps.Add(currentPosition);

        foreach(char c in _sentence)
        {
            EncodingSteps steps = (EncodingSteps)c;
            switch (steps)
            {
                case EncodingSteps.save:
                    points.Push(new LSystem.LS_Turtle(currentPosition, direction, _length));
                    break;
                case EncodingSteps.load:
                    if(points.Count > 0)
                    {
                        LSystem.LS_Turtle turtle = points.Pop();
                        currentPosition = turtle.Position;
                        direction = turtle.Direction;
                        _length = turtle.Length;
                    } else
                    {
                        throw new System.Exception("die");
                    }
                    break;
                case EncodingSteps.draw:
                    tempPosition = currentPosition;
                    currentPosition += direction * _length;
                    DrawLine(tempPosition, currentPosition);
                    //_length -= 2;
                    _steps.Add(currentPosition);
                    break;
                case EncodingSteps.turnRight:
                    direction = Quaternion.AngleAxis(_angle, Vector3.up) * direction; 
                    break;
                case EncodingSteps.turnLeft:
                    direction = Quaternion.AngleAxis(-_angle, Vector3.up) * direction;
                    break;
                default:
                    break;
            }
        }

        foreach(Vector3 position in _steps)
        {
            Instantiate(_prefab,position,Quaternion.identity);
        }
    }

    private void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject line = new GameObject("line");
        line.transform.position = start;
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = _lineMaterial;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}