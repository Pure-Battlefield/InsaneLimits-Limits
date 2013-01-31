if ( Regex.Match ( player.LastChat, @"^\s*[@!](?:suicide)", RegexOptions.IgnoreCase).Success )
{
string msg2 = "Committing seppuku in 3 seconds!" ;
        plugin.ServerCommand ( "admin.say" , msg2 , "player" , player.Name ) ;
        plugin.ServerCommand ( "admin.yell" , msg2 , "8", "player" , player.Name ) ;
        plugin.KillPlayer ( player.Name , 3 );
}

return false;