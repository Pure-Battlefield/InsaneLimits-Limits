string[] chatwords = Regex.Split(player.LastChat, @"\s+");
        
foreach(String chatword in chatwords) 
{
        if (Regex.Match(chatword, "^admin[s]?[^a-z]*$", RegexOptions.IgnoreCase).Success)
        {
                string msg1 = "Need to get in touch with an admin? Type !pageadmins [message]." ;
                plugin.ServerCommand ( "admin.say" , msg1, "player" , player.Name ) ;
                plugin.ServerCommand ( "admin.yell" , msg1 , "8" , "player" , player.Name ) ;
        }
}