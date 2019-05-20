using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRegex
{
    class FindReplace
    {
        private List<Pair> fnrList;

        FindReplace()
        {
            fnrList = new List<Pair>();
        }
        
        public void Add(string find, string replace)
        {
            fnrList.Add(new Pair(find, replace));
        }
    }


    struct Pair
    {
        public string Find { get; }
        public string Replace { get; }

        public Pair(String find, String replace)
        {
            Find = find;
            Replace = replace;
        }
    }
}
