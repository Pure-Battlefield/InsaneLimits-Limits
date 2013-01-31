/* Extract the command */
String command = plugin.ExtractInGameCommand(player.LastChat);

/* Sanity check the command */
if (null == command || command.Length == 0)
        return false;

/* Parse the command */
if (Regex.Match(command, ""^listadmins$"", RegexOptions.IgnoreCase).Success)
{
        plugin.ConsoleWrite( plugin.R(""[!listadmins limit]: %p_n%: !listadmins"") );

        String adminList = ""Admins online: "";
        bool found = false;
        List<PlayerInfoInterface> players = new List<PlayerInfoInterface>();
        players.AddRange(team1.players);
        players.AddRange(team2.players);
        if (team3.players.Count > 0)
                players.AddRange(team3.players);
        if (team4.players.Count > 0)
                players.AddRange(team4.players);

        foreach (PlayerInfoInterface p in players)
        {
                if (plugin.isInList(p.Name, ""admins""))
                {
                        if (found)
                           adminList = adminList + "", "" + p.Name;
                        else
                           adminList = adminList + p.Name;
                        found = true;
                }
        }
        
        if (found)
        {
                string msg0 = ""You may send a message to all online admins by typing !pageadmins [message]."";
                   plugin.ServerCommand(""admin.say"", adminList, ""player"", player.Name);
                plugin.ServerCommand(""admin.say"", msg0, ""player"", player.Name);
        }
        else
        {
                string msg1 = ""Sorry, none of our admins are currently online."";
                string msg2 = ""If you need help, you may page our admins by typing !pageadmins [message]."";
                plugin.ServerCommand(""admin.say"", msg1, ""player"", player.Name);
                plugin.ServerCommand(""admin.say"", msg2, ""player"", player.Name);
        }
}

return false;
