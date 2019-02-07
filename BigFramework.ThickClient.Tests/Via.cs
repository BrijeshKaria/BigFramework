using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFramework.ThickClient.Tests
{
    public class Via
    {
        public Func<string, bool> function;
        void test()
        {
            function("True");
        }
    }
}
