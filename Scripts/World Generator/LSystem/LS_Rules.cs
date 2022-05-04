using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LS_Rules 
{
    [System.Serializable]
    public class Rule
    {
        [SerializeField]
        public string A, B;
        public Rule(string a, string b)
        {
            A = a; B = b;
        }
    }

    [SerializeField] private List<Rule> _rules;
    public List<Rule> Rules { get { return _rules; } }

    public LS_Rules(List<Rule> rules)
    {
        _rules = rules;
    }
}
