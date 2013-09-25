/* Extract the command */
string command = plugin.ExtractInGameCommand(player.LastChat);

/* Sanity check the command */
if (null == command || command.Length == 0)
{
        return false;
}
        
if (Regex.Match(command, @"^pageadmin(s)?\s*$", RegexOptions.IgnoreCase).Success) 
{
        plugin.ServerCommand("admin.say", "Please include a message to page the admin team: \"!pageadmins [message]\"", "player", player.Name);
        return false;
}
        
if (Regex.Match(command, @"^pageadmin(s)?\s+.+$", RegexOptions.IgnoreCase).Success) 
{        
        List<PlayerInfoInterface> players = new List<PlayerInfoInterface>();
        players.AddRange(team1.players);
        players.AddRange(team2.players);
        
        List<string> homeAdminsOnline = new List<string>();
        	List<string> visitAdminsOnline = new List<string>();
        foreach (PlayerInfoInterface p in players) 
        {
                if (plugin.isInList(p.Name, "homeAdmins") ) 
                {
                        homeAdminsOnline.Add(p.Name);
                }
				if (plugin.isInList(p.Name, "visitAdmins") )
				{
						visitAdminsOnline.Add(p.Name);
				}
        }
        if(homeAdminsOnline.Count > 0)
        {
                /* Make the comma separated list of admin names */
                string adminListString = String.Join(", ", homeAdminsOnline.ToArray(), 0, homeAdminsOnline.Count);
                string[] playerCommand = command.Split(' ');
                string playerMessage = String.Join(" ", playerCommand, 1, playerCommand.Length -1);
                                
                plugin.ServerCommand("admin.say", "Your message has been sent to all admins currently on the server: " + adminListString, "player", player.Name);
                
                foreach(string adminName in homeAdminsOnline)
                {
                        plugin.ServerCommand("admin.yell", "Admin page from " + player.Name + ": " + playerMessage, "30", "player", adminName);
                        plugin.ServerCommand("admin.say", "Admin page from " + player.Name + ": " + playerMessage, "player", adminName);
                }
			return false;	
        }
        if(visitAdminsOnline.Count > 0)
		{
                /* Make the comma separated list of admin names */
                string adminListString = String.Join(", ", visitAdminsOnline.ToArray(), 0, visitAdminsOnline.Count);
                string[] playerCommand = command.Split(' ');
                string playerMessage = String.Join(" ", playerCommand, 1, playerCommand.Length -1);
                                
                plugin.ServerCommand("admin.say", "Your message has been sent to all admins currently on the server: " + adminListString, "player", player.Name);
                
                foreach(string adminName in visitAdminsOnline)
                {
                        plugin.ServerCommand("admin.yell", "Admin page from " + player.Name + ": " + playerMessage, "30", "player", adminName);
                        plugin.ServerCommand("admin.say", "Admin page from " + player.Name + ": " + playerMessage, "player", adminName);
                }
			return false;	
        }		
		else
        {
                string noAdmins = "No admins are currently on the server, so the admin team is being paged by phone.  We will try to respond ASAP.";
                plugin.ServerCommand("admin.say", noAdmins, "player", player.Name);
                return true;
        }
}
return false;
