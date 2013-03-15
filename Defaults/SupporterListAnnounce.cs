// If this isn't the right time to do the message, abort.
// (server.RoundsTotal % 2 == 1): odd-numbered rounds only
// (limit.Activations(player.Name) == 2): second spawn of a round only 
if(        
	!(
		(server.RoundsTotal % 2 == 1) && 
		(limit.Activations(player.Name) == 2)
	 )
  ) 
	return false; 

string supporterList = "";
// Are any of our supporters currently online?  (If not, we won't print anything)
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
	if( plugin.isInList(p.Name, "supporters") )
	{
		if( found )
		{
			supporterList = supporterList + ", " + p.Name;
		}
		else
		{
			supporterList = supporterList + p.Name;
			found = true;
		}
	}
}

if( found )
{
	string introText = "Thanks to our donors & volunteers currently online: ";
	plugin.ServerCommand("admin.say", introText + supporterList, "player", player.Name);
}

return false;
