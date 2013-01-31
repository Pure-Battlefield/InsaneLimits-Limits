if( Regex.Match(player.LastChat, @"^\s*[!/](tshelp)$", RegexOptions.IgnoreCase).Success )
{
        string ts_1 = "!tssquads: List squads with 1-3 TS players in them";
        string ts_2 = "!tslobby: Go to lobby this round (disable squad sync)";
        string ts_3 = "!tssync: Re-enable squad sync immediately";

        List<string> TS3= new List<string>();
        TS3.Add(ts_1);
        TS3.Add(ts_2);
        TS3.Add(ts_3);

        plugin.ConsoleWrite(plugin.R("%p_n%: !tsinfo"));

        foreach(string X in TS3)
                plugin.ServerCommand("admin.say", X, "player", player.Name);

        return false;
}

return true;