using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailModdingTools.lib
{
    public class Level
    {
        public static Dictionary<int, string> levelName = new Dictionary<int, string>()
        {
            {29, "A01"},
            {144, "Level Select" }
        };

        public static string GetLevelName(int level)
        {
            if (!levelName.ContainsKey(level)) return "Level is not yet named";

            return levelName[level];
        }
    }
}
