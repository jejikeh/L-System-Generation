using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS_Generation
{
    public string GenerateSentence(string sentence,LS_Rules rules)
    {
        string nextSentece = new string("");
        for(int i = 0; i < sentence.Length; i++)
        {
            char currentChar = sentence[i];
            foreach(LS_Rules.Rule rule in rules.Rules)
            {
                if (Equals(currentChar.ToString(), rule.A))
                {
                    nextSentece += rule.B;
                }
            }
        }


        return nextSentece;
    }
}
