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

    public void DrawTree(List<LSystem.LS_TurtleStep> steps)
    {

        foreach(LSystem.LS_TurtleStep step in steps)
        {
            Instantiate(_prefab,step.Position,Quaternion.identity);
            //Debug.Log(step.Direction);
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