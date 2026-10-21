namespace EnhancedPlus.ConfigStuff
{
    public struct Config
    {
        public Config()
        {
            FixBrokenHats = true;
            ShowInfoButton = "F10";
            ReturnToMenuButton = "F9";
        }

        public bool FixBrokenHats { get; set; }
        public string ShowInfoButton { get; set; }
        public string ReturnToMenuButton { get; set; }
    }
}
