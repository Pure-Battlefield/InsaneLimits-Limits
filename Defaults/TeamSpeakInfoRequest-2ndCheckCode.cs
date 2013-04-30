if( Regex.Match(player.LastChat, @"^\s*[!/](tsinfo)$", RegexOptions.IgnoreCase).Success ||
        Regex.Match(player.LastChat, @"^\s*[!/](teamspeak)$", RegexOptions.IgnoreCase).Success )
{
        string ts_1 = "Server: teamspeak.purebattlefield.org";
        string ts_2 = "Our server automatically groups you w/your squad.";
        string ts_3 = "Setup guide at teamspeakguide.purebattlefield.org.";
        string ts_4 = "Additional TeamSpeak commands: !tshelp";

        List<string> TS3= new List<string>();
        TS3.Add(ts_1);
        TS3.Add(ts_2);
        TS3.Add(ts_3);
        TS3.Add(ts_4);

        plugin.ConsoleWrite(plugin.R("%p_n%: !tsinfo"));

        foreach(string X in TS3)
                plugin.ServerCommand("admin.say", X, "player", player.Name);

        return false;
}

return true;