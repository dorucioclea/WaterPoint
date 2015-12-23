using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WaterPoint.Api.Common
{
    public static class SearchTermHelper
    {
        private const string BlackListCharacters = "[*=]";
        private const string SpecialCharacters = "^[-&+#;@\"]$"; //removed from search if standalone
        private const string NumericCharacters = "^[0-9]$"; //removed from serach if standalone

        public static bool IsSearchable(string searchTerm)
        {
            var tokens = TokenizeSearchTerm(searchTerm);
            return tokens.Length > 0;
        }

        public static string ConvertToSearchTerm(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || !IsSearchable(searchTerm))
                return string.Empty;

            var sb = new StringBuilder();

            var searchTokens = TokenizeSearchTerm(searchTerm);

            for (var i = 0; i < searchTokens.Length; i++)
            {
                if (i > 0)
                    sb.Append(" AND ");

                sb.AppendFormat($"\"{searchTokens[i]}{"*"}\"");
            }

            return sb.Length > 0 ? sb.ToString() : "\"\"";
        }

        private static string[] TokenizeSearchTerm(string searchTerm)
        {
            var filteredTokens = new string[0];

            var result = TrimSearch(searchTerm);
            if (result == null)
                return EscapeQuotes(filteredTokens);

            var tokens = result.Split(' ');

            filteredTokens = tokens.Where(token => !Regex.Match(token, NumericCharacters).Success).ToArray();

            filteredTokens = filteredTokens.Where(token => !Regex.Match(token, SpecialCharacters).Success).ToArray();

            return EscapeQuotes(filteredTokens);
        }

        private static string TrimSearch(string searchTerm)
        {
            string searchText = null;
            string trimText = searchTerm.Trim();

            if (trimText.Length > 1)
            {
                trimText = Regex.Replace(trimText, BlackListCharacters, string.Empty);
                trimText = trimText.Trim();
                trimText = Regex.Replace(trimText, @" +", " ");
                searchText = trimText;
            }

            return searchText;
        }

        private static string[] EscapeQuotes(string[] tokens)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                tokens[i] = tokens[i].Replace("\"", "\"\"");
            }
            return tokens;
        }
    }
}
