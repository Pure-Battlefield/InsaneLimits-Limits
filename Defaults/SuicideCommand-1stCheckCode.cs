if ( Regex.Match ( player.LastChat, @""(?:stuck|bugged)"", RegexOptions.IgnoreCase ).Success ) 
{
        string msg1 = ""If you are stuck or bugged, the !suicide command may help."" ;
        plugin.ServerCommand ( ""admin.say"" , msg1, ""player"" , player.Name ) ;
}
        
return true;