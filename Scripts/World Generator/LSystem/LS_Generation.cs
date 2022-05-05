using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSystem.StringGeneration
{
    public class LS_Generation
    {
        public string GenerateSentence(string sentence, LS_Rules rules)
        {
            string nextSentece = new string("");
            foreach (char c in sentence)
            {
                nextSentece += GenerateNextStep(c, rules);
            }

            return nextSentece;
        }

        private string GenerateNextStep(char c, LS_Rules rules)
        {
            bool found = false;
            foreach (LS_Rules.Rule rule in rules.Rules)
            {
                if (Equals(c.ToString(), rule.A))
                {
                    found = true;
                    return rule.B;
                }
            }
            if (!found)
            {
                return c.ToString();
            }

            return new string("");

        }
    }
}
