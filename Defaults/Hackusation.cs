List<string> hacks = new List<string>();
        hacks.Add("hack");
        hacks.Add("hacks");
        hacks.Add("hacking");
        hacks.Add("hacker");
        hacks.Add("cheat");
        hacks.Add("cheats");
        hacks.Add("cheater");
        hacks.Add("cheating");
        
string[] chatwords = Regex.Split(player.LastChat, @"\s+");
        
foreach(String chatword in chatwords) 
{
        foreach(String hack in hacks)
        {
                if (Regex.Match(chatword, "^"+hack+"[s]?[^a-z]*$", RegexOptions.IgnoreCase).Success)
                {
                        string msg1 = "Use the !pageadmin command for serious cheating accusations backed by evidence. We take accusations seriously and will investigate." ;
  					plugin.ServerCommand ( "admin.say" , msg1, "player" , player.Name ) ;
						plugin.ServerCommand ( "admin.yell" , msg1 , "8" , "player" , player.Name ) ;
                        return true;
                        
                }
        }
}
