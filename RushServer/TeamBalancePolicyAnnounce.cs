 if( limit.Activations() > 1 )
        return false;
        
// -----------------------------------------------------------------------
//
// KEY CONSTANTS
//
// -----------------------------------------------------------------------

int maxPopulationForAlwaysShufflingSquads = 24;

// -----------------------------------------------------------------------
//
// END KEY CONSTANTS
//
// -----------------------------------------------------------------------

        
plugin.ConsoleWrite( plugin.R("[Team balance policy announcemnt limit] Sending announcement.") );

List<string> message = new List<string>();

// messaging below is for TrueBalancer
message.Add( "Teams are shuffled after every map (every 2 rounds)." );
message.Add( "We do our best to keep squads intact." );


// messaging below is for InsaneBalancer
/*
if( server.PlayerCount <= maxPopulationForAlwaysShufflingSquads )
{
        message.Add( "Teams are shuffled by player SPM after each map." );
        message.Add( "If " + maxPopulationForAlwaysShufflingSquads + " or fewer players, squads are split pre-shuffle." );
        message.Add( "Squads are otherwise kept intact whenever possible." );
}
else
{
        message.Add( "Teams are shuffled by player SPM after each map." );
        message.Add( "Squads are kept intact whenever possible." );
        message.Add( "Different team sizes may require a few splits." );
}
*/
foreach( string msg in message )
{
        plugin.SendGlobalMessage( plugin.R(msg) );
}

return false;
