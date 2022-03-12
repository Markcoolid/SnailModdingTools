using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailModdingTools.lib
{
    public class SaveFile
    {
        static string[] saveSlotPrefix =
        {
            "",
            "S2-",
            "S3-"
        };

        public static string saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Will_You_Snail";

        string slot;
        public string Slot => slot;

        public string version;

        public int level;

        public int deaths;

        public int difficulty;

        public List<string> playedVoicelines = new List<string>();

        public SaveFile(int slot)
        {
            string[] lines = File.ReadAllLines(saveFolder + "/" + saveSlotPrefix[slot - 1] + "SaavoGame23-2.sav");
            FileStream stream = File.OpenRead(saveFolder + "/" + saveSlotPrefix[slot - 1] + "SaavoGame23-2.sav");
            StreamReader reader = new StreamReader(stream);

            this.slot = slot.ToString();

            version = reader.GetString("Game Version");

            level = reader.GetInt("Room");

            while (true)
            {
                string line = reader.ReadLine()!;
                if (line == "Deaths")
                {
                    break;
                }
            }
            deaths = int.Parse(reader.ReadLine()!);

            while (true)
            {
                string line = reader.ReadLine()!;
                if (line == "Difficulty")
                {
                    break;
                }
            }
            difficulty = int.Parse(reader.ReadLine()!);

            while (true)
            {
                string line = reader.ReadLine()!;
                if (line == "Played Voice Lines")
                {
                    break;
                }
            }
            int played = int.Parse(reader.ReadLine()!);

            for(int i = 0; i < played; i++)
            {
                playedVoicelines.Add(reader.ReadLine()!);
            }

        }

        

    }
}
