namespace SnailModdingTools.lib
{
    public static class Difficulty
    {
        public static List<string> difficultyNames = new List<string>()
        {
            "Infinitely Easy",
            "Extremely Easy",
            "Very Easy",
            "Easy"
        };

        public static string ToString(int difficulty)
        {
            return difficultyNames[difficulty];
        }
    }
}
