using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public static class TestUtility
    {
        public static string NeutralizeString(string str)
        {
            return str.Replace("\r", string.Empty).Replace("\n", string.Empty).ToLower().Replace(" ", string.Empty);
        }
    }
}
