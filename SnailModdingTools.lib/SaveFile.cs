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

        public int Slot { get; set; }

        public string Version { get; set; }

        public int Level { get; set; }

        public int Deaths { get; set; }

        public int Difficulty { get; set; }

        public List<string> PlayedVoicelines { get; set; }

        public SaveFile(int slot)
        {
            string[] lines = File.ReadAllLines(saveFolder + "/" + saveSlotPrefix[slot - 1] + "SaavoGame23-2.sav");
            FileStream stream = File.OpenRead(saveFolder + "/" + saveSlotPrefix[slot - 1] + "SaavoGame23-2.sav");
            StreamReader reader = new StreamReader(stream);

            Slot = slot;

            Version = reader.GetString("Game Version");

            Level = reader.GetInt("Room");

            Deaths = reader.GetInt("Deaths");

            Difficulty = reader.GetInt("Difficulty");

            PlayedVoicelines = reader.GetStringList("Played Voice Lines");

        }

        

    }
}
