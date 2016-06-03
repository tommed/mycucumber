using System.Collections.Generic;
using System.Text;

namespace MyCucumber
{
    public class Statement
    {
        public Statement(string input)
        {
            this.StringLiteral = input ?? ""; // get rid of those yucky nulls
            this.Tokens = ExtractTokens();
        }

        private IEnumerable<string> ExtractTokens()
        {
            bool inToken = false;
            var buffer = new StringBuilder();
            foreach (var c in StringLiteral)
            {
                if (c == '{' && !inToken)
                {
                    buffer.Clear();
                    inToken = true;
                    continue;
                }

                if (c == '}' && inToken && buffer.Length > 0)
                {
                    yield return buffer.ToString();
                    buffer.Clear();
                    inToken = false;
                    continue;
                }

                buffer.Append(c);
            }
        }

        public IEnumerable<string> Tokens { get; set; }
        public string StringLiteral { get; set; }
    }
}
