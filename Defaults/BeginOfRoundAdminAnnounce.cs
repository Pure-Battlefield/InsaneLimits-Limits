// If this isn't the right time to do the message, abort.
// (server.RoundsTotal % 2 == 0): even-numbered rounds only
// (limit.Activations(player.Name) == 2): second spawn of a round only 
if(        
        !(
                (server.RoundsTotal % 2 == 0) && 
                (limit.Activations(player.Name) == 2)
         )
  ) 
        return false; 

String adminList = "Admins online: ";
bool found = false;

// Make a list of all players currently on the server
List<PlayerInfoInterface> players = new List<PlayerInfoInterface>();
players.AddRange( team1.players );
players.AddRange( team2.players );
if( team3.players.Count > 0 )
   players.AddRange( team3.players );
if( team4.players.Count > 0 )
   players.AddRange( team4.players );

// Make a list of all supporters currently on the server   
foreach( PlayerInfoInterface p in players )
{
        if( plugin.isInList(p.Name, "admins") )
        {
                if( found )
                {
                        adminList = adminList + ", " + p.Name;
                }
                else
                {
                        adminList = adminList + p.Name;
                        found = true;
                }
        }
}

if( found )
{
   string msg1 = "Type !listadmins to see this list at any time.";
   plugin.ServerCommand("admin.say", adminList, "player", player.Name);
   plugin.ServerCommand("admin.say", msg1, "player", player.Name);
}
else 
{
   string msg2 = "Sorry, none of our admins are currently online.";
   string msg3 = "If you need help, you may page our admins via e-mail by typing !pageadmins [message].";
   plugin.ServerCommand("admin.say", msg2, "player", player.Name);
   plugin.ServerCommand("admin.say", msg3, "player", player.Name);
}      

return false;