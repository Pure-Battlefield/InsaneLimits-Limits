if( Regex.Match(player.LastChat, @""^\s*[!/]*(donate)$"", RegexOptions.IgnoreCase).Success )
{
        string msg_1 = ""Your donation helps support a community-oriented"";
        string msg_2 = ""server. Donors can get VIP queue access, team"";
        string msg_3 = ""balance immunity & more. Perks start at $5 / mo."";
        string msg_4 = ""Details: donate.purebattlefield.org"";

        List<string> msg = new List<string>();
        msg.Add(msg_1);
        msg.Add(msg_2);
        msg.Add(msg_3);
        msg.Add(msg_4);

        plugin.ConsoleWrite(plugin.R(""%p_n%: !donate""));

        foreach(string X in msg)
                plugin.ServerCommand(""admin.say"", X, ""player"", player.Name);
}

return false;