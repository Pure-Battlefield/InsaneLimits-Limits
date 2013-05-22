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

String homeAdminList = "Admins online: ";
String visitAdminList = "Visiting admins from other PURE servers: ";
int hfound = 0;
bool vfound = false;

// Make a list of all players currently on the server
List<PlayerInfoInterface> players = new List<PlayerInfoInterface>();
players.AddRange( team1.players );
players.AddRange( team2.players );
if( team3.players.Count > 0 )
   players.AddRange( team3.players );
if( team4.players.Count > 0 )
   players.AddRange( team4.players );

// Make a list of all admins currently on the server   
foreach( PlayerInfoInterface p in players )
{
        if( plugin.isInList(p.Name, "homeAdmins") )
        {
                if( hfound > 0 )
                {
                        homeAdminList = homeAdminList + ", " + p.Name;
                }
                else
                {
                        homeAdminList = homeAdminList + p.Name;
                        hfound ++;
                }
        }
		
		if( plugin.isInList(p.Name, "visitAdmins") )
        {
                if( vfound )
                {
                        visitAdminList = visitAdminList + ", " + p.Name;
                }
                else
                {
                        visitAdminList = visitAdminList + p.Name;
                        vfound = true;
                }
        }
}

if( hfound > 0 )
{
	plugin.ServerCommand("admin.say", homeAdminList, "player", player.Name);
	string msg1 = "Type !listadmins to see this list at any time.";
	plugin.ServerCommand("admin.say", msg1, "player", player.Name);
	return false;
}

if ( ( hfound == 0 ) && ( vfound ) )
{
	plugin.ServerCommand("admin.say", visitAdminList, "player", player.Name);
	string msg2 = "You may send a message to all online admins by typing !pageadmins [message].";
	plugin.ServerCommand("admin.say", msg2, "player", player.Name);
}

else 
{
   string msg3 = "Sorry, none of our admins are currently online.";
   string msg4 = "If you need help, you may page our admins via e-mail by typing !pageadmins [message].";
   plugin.ServerCommand("admin.say", msg3, "player", player.Name);
   plugin.ServerCommand("admin.say", msg4, "player", player.Name);
}      

return false;
