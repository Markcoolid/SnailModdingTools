using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailModdingTools.lib
{
    public static class SaveFileReader
    {
        public static string GetString(this StreamReader reader, string name)
        {
            string? line;
            while (true)
            {
                line = reader.ReadLine();
                if (line == null)
                {
                    throw new NullReferenceException();
                }
                if (line == name)
                {
                    string? variable = reader.ReadLine();
                    if (variable == null)
                    {
                        throw new NullReferenceException();
                    }
                    return variable;
                }
            }
        }

        public static int GetInt(this StreamReader reader, string name)
        {
            string? line;
            while (true)
            {
                line = reader.ReadLine();
                if (line == null)
                {
                    throw new NullReferenceException();
                }
                if (line == name)
                {
                    string? variable = reader.ReadLine();
                    if (variable == null)
                    {
                        throw new NullReferenceException();
                    }
                    return int.Parse(variable);
                }
            }
        }

        public static List<string> GetStringList(this StreamReader reader, string name)
        {
            string? line;
            while(true)
            {
                line = reader.ReadLine();
                if(line == null)
                {
                    throw new NullReferenceException();
                }
                if(line == name)
                {
                    int variable = int.Parse(reader.ReadLine()!);
                    List<string> list = new List<string>();
                    for(int i = 0; i < variable; i++)
                    {
                        list.Add(reader.ReadLine()!);
                    }
                    return list;
                }
            }
        }
    }
}
