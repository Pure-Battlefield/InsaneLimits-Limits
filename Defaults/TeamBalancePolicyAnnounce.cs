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
/*
message.Add( "If ticket difference > 25%, teams get shuffled" );
message.Add( "between rounds, keeping squads intact." );
message.Add( "Shuffling is based on players' Battlelog stats." );
*/

// messaging below is for InsaneBalancer
if( server.PlayerCount <= maxPopulationForAlwaysShufflingSquads )
{
        message.Add( "Teams are shuffled after each map." );
        message.Add( "If " + maxPopulationForAlwaysShufflingSquads + " or fewer players, squads are split pre-shuffle." );
        message.Add( "Squads are otherwise kept intact whenever possible." );
}
else
{
        message.Add( "Teams are shuffled after each map." );
        message.Add( "If under 24 players, squads are split pre-shuffle." );
        message.Add( "Squads are otherwise kept intact whenever possible." );
}

foreach( string msg in message )
{
        plugin.SendGlobalMessage( plugin.R(msg) );
}

return false;
