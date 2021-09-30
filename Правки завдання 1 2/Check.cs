using System;
using System.Collections.Generic;

namespace Завдання_2
{
    public sealed class Check
    {
        public string GetCheckText(List<Buy> purchases)
        {
            string checkText = "";

            foreach(Buy buy in purchases)
            {
                checkText += buy.ToString() + "\n";
            }

            return checkText;
        }
    }
}
