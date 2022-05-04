using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS_WorldGenerator : MonoBehaviour
{
    [Header("World Gen settings")]
    [SerializeField] private LS_Rules _rules;
    [SerializeField] private string _axiom;
    private string _sentence;

    private LS_Generation _lsGeneration = new LS_Generation();

    void Start()
    {
        _sentence = _axiom;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _sentence = _lsGeneration.GenerateSentence(_sentence,_rules);
            Debug.Log(_sentence);

        }
    }
}
