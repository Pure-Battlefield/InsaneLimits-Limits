if( Regex.Match(player.LastChat, @"^\s*[!/](help)$", RegexOptions.IgnoreCase).Success )
{
        string help_1 = "!rules: Learn what is & isn't OK here";
        string help_2 = "!tsinfo: Squad VOIP info (TeamSpeak)";
        string help_3 = "Other commands: !aboutpure, !donate, !listadmins,";
        string help_4 = "!nextmap, !suicide, !tshelp";

        List<string> Help = new List<string>();
        Help.Add(help_1);
        Help.Add(help_2);
        Help.Add(help_3);
        Help.Add(help_4);

        plugin.ConsoleWrite(plugin.R("%p_n% wants to know the server commands"));

        foreach(string X in Help)
                plugin.ServerCommand("admin.say", X, "player", player.Name);
}

return false;