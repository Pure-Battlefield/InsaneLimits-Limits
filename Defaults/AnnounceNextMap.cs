if( limit.Activations() > 1 )
        return false;
        
// Message replacement strings:
// %m: next map name
// %s: " (teams switch sides)" if next round is same map, "" otherwise

// ANNOUNCEMENT text

List <string> announcementText = new List<string>();

announcementText.Add( "Next map: %m %s" );
announcementText.Add( "(It may be different if the server population changes" );
announcementText.Add( "enough to activate a different map rotation.)" );

// -----------------------------------------------------------------------
//
// HUMAN-READABLE MAP NAMES
//
// -----------------------------------------------------------------------

/* BF3 friendly map names */
Dictionary<string, string> Maps = new Dictionary<string, string>();
Maps.Add("MP_001", "Grand Bazaar");
Maps.Add("MP_003", "Tehran Highway");
Maps.Add("MP_007", "Caspian Border");
Maps.Add("MP_011", "Seine Crossing");
Maps.Add("MP_012", "Operation Firestorm");
Maps.Add("MP_013", "Damavand Peak");
Maps.Add("MP_017", "Noshahr Canals");
Maps.Add("MP_018", "Kharg Island");
Maps.Add("MP_Subway", "Operation Metro");
// Back to Karkand maps
Maps.Add("XP1_001", "Strike at Karkand");
Maps.Add("XP1_002", "Gulf of Oman");
Maps.Add("XP1_003", "Sharqi Peninsula");
Maps.Add("XP1_004", "Wake Island");
// Close Quarters maps
Maps.Add("XP2_Factory", "Scrap Metal");
Maps.Add("XP2_Office", "Operation 925");
Maps.Add("XP2_Palace", "Donya Fortress");
Maps.Add("XP2_Skybar", "Ziba Tower");
// Armoured Kill maps
Maps.Add("XP3_Desert", "Bandar Desert");
Maps.Add("XP3_Alborz", "Alborz Mountain");
Maps.Add("XP3_Valley", "Death Valley");
Maps.Add("XP3_Shield", "Armored Shield");
// Aftermath maps
Maps.Add("XP4_FD", "Markaz Monolith");
Maps.Add("XP4_Parl", "Azadi Palace");
Maps.Add("XP4_Quake", "Epicenter");
Maps.Add("XP4_Rubble", "Talah Market");
// End Game maps
Maps.Add("XP5_001", "Operation Riverside");
Maps.Add("XP5_002", "Nebandan Flats");
Maps.Add("XP5_003", "Kiasar Railroad");
Maps.Add("XP5_004", "Sabalan Pipeline");

if( !Maps.ContainsKey(server.MapFileName) || 
        !Maps.ContainsKey(server.NextMapFileName) )
{
        plugin.ConsoleWrite(plugin.R("[One of the NextMapInfo limits] ERROR: Map name not found in dictionary"));
        return false;
}
// -----------------------------------------------------------------------
//
// END MAP NAMES
//
// -----------------------------------------------------------------------

// -----------------------------------------------------------------------
//
// MAIN WORK BEGINS HERE
//
// -----------------------------------------------------------------------
        
string replacedMsg;

plugin.ConsoleWrite(plugin.R("[Next map announcement limit] Sending announcement"));

// OK, now print messaging, starting with any enqueued messages.
foreach( string msg in announcementText )
{
        // replace the %m and %s substrings as appropriate, based on whether another round is left in this map
        // Note that server.TotalRounds is equal to current round number MINUS ONE (i.e. counting starts at zero), so the math on the next line looks weird:
        if( (server.TotalRounds - server.CurrentRound) > 1 )
        {
                replacedMsg = msg.Replace( "%m", Maps[server.MapFileName] );
                replacedMsg = replacedMsg.Replace( "%s", " (teams switch sides)" );
        }
        else
        {
                replacedMsg = msg.Replace( "%m", Maps[server.NextMapFileName] );
                replacedMsg = replacedMsg.Replace( "%s", "" );
        }
        
        plugin.SendGlobalMessage( replacedMsg );
}
