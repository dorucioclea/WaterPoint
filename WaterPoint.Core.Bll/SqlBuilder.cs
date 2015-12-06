﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll
{
    public abstract class SqlBuilder<T>
    {
        public string Columns { get; set; }
        protected string ParentTable { get; set; }
        protected Type Type { get; set; }
        protected List<PropertyInfo> Properties { get; set; }

        protected SqlBuilder()
        {
            Type = typeof(T);

            var tableAttribute = Type.GetCustomAttribute(typeof(TableAttribute)) as TableAttribute;

            if (tableAttribute == null)
                throw new InvalidDataException("Missing TableAttribute.");

            ParentTable = $"[{tableAttribute.Schema}].[{tableAttribute.Table}]";

            Properties = Type.GetProperties().ToList();
        }
    }

    public static class SqlBuilderHelper
    {
        public static bool ShouldIgnore(PropertyInfo property, IEnumerable<Type> attributes)
        {
            foreach (var attribute in attributes)
            {
                var f = property.GetCustomAttribute(attribute);

                if (f != null)
                    return true;
            }

            return false;
        }
    }


    public static class Search
    {
        private const string BlackListCharacters = "[*=]"; //removed from search
        private const string SpecialCharacters = "^[-&+#;@\"]$"; //removed from search if standalone
        private const string NumericCharacters = "^[0-9]$"; //removed from serach if standalone

        public static bool IsSearchable(string searchTerm)
        {
            var tokens = TokenizeSearchTerm(searchTerm);
            return tokens.Length > 0;
        }

        public static string[] TokenizeSearchTerm(string searchTerm)
        {
            var filteredTokens = new string[0];

            var result = TrimSearch(searchTerm);
            if (result != null)
            {
                var tokens = result.Split(' ');

                filteredTokens = tokens.Where(token => !Regex.Match(token, NumericCharacters).Success).ToArray();
                filteredTokens = filteredTokens.Where(token => !Regex.Match(token, SpecialCharacters).Success).ToArray();
            }

            return EscapeQuotes(filteredTokens);
        }

        /// <summary>
        /// Create the sql search parameter @search_cmd
        /// </summary>
        public static string CreateSearchCmd(string[] searchTokens)
        {
            var searchExpression = new StringBuilder();

            //Add the search tokens
            for (var i = 0; i < searchTokens.Length; i++)
            {
                if (i > 0)
                    searchExpression.Append(" AND ");

                bool addWildCard = true; //searchTokens[i].Length > 1;
                searchExpression.AppendFormat("\"{0}{1}\"", searchTokens[i], addWildCard ? "*" : string.Empty);
            }

            return searchExpression.Length > 0 ? searchExpression.ToString() : "\"\""; //return empty search criteria is none is not specified
        }

        private static string TrimSearch(string searchTerm)
        {
            string searchText = null;
            string trimText = searchTerm.Trim();

            if (trimText.Length > 1)
            {
                trimText = Regex.Replace(trimText, BlackListCharacters, string.Empty);
                trimText = trimText.Trim();
                trimText = Regex.Replace(trimText, @" +", " "); // Turn multiple spaces into 1 space
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
