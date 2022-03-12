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

        public int level;

        public int deaths;

        public int difficulty;

        public List<string> playedVoicelines = new List<string>();

        public SaveFile(int slot)
        {
            string[] lines = File.ReadAllLines(saveFolder + "/" + saveSlotPrefix[slot - 1] + "SaavoGame23-2.sav");
            FileStream stream = File.OpenRead(saveFolder + "/" + saveSlotPrefix[slot - 1] + "SaavoGame23-2.sav");
            StreamReader reader = new StreamReader(stream);

            this.Slot = slot;

            Version = reader.GetString("Game Version");

            level = reader.GetInt("Room");

            deaths = reader.GetInt("Deaths");

            difficulty = reader.GetInt("Difficulty");

            int played = reader.GetInt("Played Voice Lines");

            for(int i = 0; i < played; i++)
            {
                playedVoicelines.Add(reader.ReadLine()!);
            }

        }

        

    }
}
