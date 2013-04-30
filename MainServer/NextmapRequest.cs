//Content in the ANNOUNCEMENTS section NEEDS to be customized for each server and must match between !nextmap limit and Announce Next Map and Mode limit (starting at line 44).

// -----------------------------------------------------------------------
//
// DEFINITIONS AND TRIGGER CRITIERA FOR GAMETYPE SWITCHING ANNOUNCEMENTS
//
// -----------------------------------------------------------------------

int numAnnouncements = 5;

// This is not a struct because InsaneLimits was throwing all kinds of fucked-up
// compile errors when I tried to make it a struct and I eventually gave up.
List<string>[] announcementGameTypes = new List<string>[numAnnouncements];
int[] announcementMinPlayers = new int[numAnnouncements];
int[] announcementMaxPlayers = new int[numAnnouncements];
bool[] announcementServerNameMatchRequired = new bool[numAnnouncements];
string[] announcementServerName1 = new string[numAnnouncements];
string[] announcementServerName2 = new string[numAnnouncements];
List <string>[] announcementText = new List<string>[numAnnouncements];

for( int i=0; i < numAnnouncements; i++ )
{
  announcementGameTypes[i] = new List<string>();
        announcementText[i] = new List<string>();
}

// Each announcement will get triggered if & only if:
// - gametype matches
// - servername matches (these must be listed first in the array)
// - population is within range 

// Message replacement strings:
// %m: next map name
// %s: " (teams switch sides)" if next round is same map, "" otherwise

// -----------------------------------------------------------------------
//
// ANNOUNCEMENTS
//
// -----------------------------------------------------------------------

/*
Below is an example of 4 different announcements. Please use this example to build the announcements for each server.
These examples are from the Main server

// damavand rush
announcementGameTypes[0].Add( "RushLarge0" ); //Game types can be found in "BF3 friendly game modes" section
announcementMinPlayers[0] = 1;
announcementMaxPlayers[0] = 64;
announcementServerNameMatchRequired[0] = true;
announcementServerName1[0] = "PURE BATTLEFIELD: Damavand Rush madness!";
announcementServerName2[0] = "PURE BATTLEFIELD: Defaults | $25 TS giveaway Sat";
announcementText[0].Add( "Next map is based on players at start of next round:" );
announcementText[0].Add( "> 20: Random map from \"Popular Rush\" rotation" );
announcementText[0].Add( "> 32: Random map from \"Popular Conquest\" rotation" );
announcementText[0].Add( "Damavand Peak repeats until then." );

// popular rush
announcementGameTypes[1].Add( "RushLarge0" );
announcementMinPlayers[1] = 1;
announcementMaxPlayers[1] = 64;
announcementServerNameMatchRequired[1] = false;
announcementServerName1[1] = "";
announcementServerName2[1] = "";
announcementText[1].Add( "Next map is based on players at start of next round:" );
announcementText[1].Add( "> 40: Random map from \"Popular Conquest\" rotation" );
announcementText[1].Add( "< 10: Damavand Peak" );
announcementText[1].Add( "Otherwise: %m%s" );

// popular conquest
// this must come before the other conquest because it has a server name match.
announcementGameTypes[2].Add( "ConquestLarge0" );
announcementGameTypes[2].Add( "ConquestAssaultLarge0" );
announcementMinPlayers[2] = 1;
announcementMaxPlayers[2] = 64;
announcementServerNameMatchRequired[2] = true;
announcementServerName1[2] = "PURE BATTLEFIELD: Reddit | Default gameplay | TeamSpeak";
announcementServerName2[2] = "PURE BATTLEFIELD: Defaults | $25 TS giveaway Sat!";
announcementText[2].Add( "Next map is based on players at start of next round:" );
announcementText[2].Add( "> 52: Random map from \"Full Conquest\" rotation" );
announcementText[2].Add( "< 32: Random map from \"Popular Rush\" rotation" );
announcementText[2].Add( "Otherwise: %m" );

// full conquest (lower population)
announcementGameTypes[3].Add( "ConquestLarge0" );
announcementGameTypes[3].Add( "ConquestAssaultLarge0" );
announcementMinPlayers[3] = 1;
announcementMaxPlayers[3] = 45;
announcementServerNameMatchRequired[3] = false;
announcementServerName1[3] = "";
announcementServerName2[3] = "";
announcementText[3].Add( "Next map is based on players at start of next round:" );
announcementText[3].Add( "< 32: Random map from \"Popular Rush\" rotation" );
announcementText[3].Add( "Otherwise: %m" );

// full conquest (higher population)
announcementGameTypes[4].Add( "ConquestLarge0" );
announcementGameTypes[4].Add( "ConquestAssaultLarge0" );
announcementMinPlayers[4] = 46;
announcementMaxPlayers[4] = 64;
announcementServerNameMatchRequired[4] = false;
announcementServerName1[4] = "";
announcementServerName2[4] = "";
announcementText[4].Add( "Next map: %m" );
*/

// damavand rush
announcementGameTypes[0].Add( "RushLarge0" );
announcementMinPlayers[0] = 1;
announcementMaxPlayers[0] = 64;
announcementServerNameMatchRequired[0] = true;
announcementServerName1[0] = "PURE BATTLEFIELD 1: Damavand Rush madness!";
announcementServerName2[0] = "PURE BATTLEFIELD: Defaults | $25 TS giveaway Sat";
announcementText[0].Add( "Next map is based on players at start of next round:" );
announcementText[0].Add( "> 20: Random map from \"Popular Rush\" rotation" );
announcementText[0].Add( "> 32: Random map from \"Popular Conquest\" rotation" );
announcementText[0].Add( "Damavand Peak repeats until then." );

// popular rush
announcementGameTypes[1].Add( "RushLarge0" );
announcementMinPlayers[1] = 1;
announcementMaxPlayers[1] = 64;
announcementServerNameMatchRequired[1] = false;
announcementServerName1[1] = "";
announcementServerName2[1] = "";
announcementText[1].Add( "Next map is based on players at start of next round:" );
announcementText[1].Add( "> 40: Random map from \"Popular Conquest\" rotation" );
announcementText[1].Add( "< 10: Damavand Peak" );
announcementText[1].Add( "Otherwise: %m%s" );

// popular conquest
// this must come before the other conquest because it has a server name match.
announcementGameTypes[2].Add( "ConquestLarge0" );
announcementGameTypes[2].Add( "ConquestAssaultLarge0" );
announcementMinPlayers[2] = 1;
announcementMaxPlayers[2] = 64;
announcementServerNameMatchRequired[2] = true;
announcementServerName1[2] = "PURE BATTLEFIELD 1: Rush/Conquest | Friendly | Teamplay";
announcementServerName2[2] = "PURE BATTLEFIELD: Defaults | $25 TS giveaway Sat!";
announcementText[2].Add( "Next map is based on players at start of next round:" );
announcementText[2].Add( "> 52: Random map from \"Full Conquest\" rotation" );
announcementText[2].Add( "< 32: Random map from \"Popular Rush\" rotation" );
announcementText[2].Add( "Otherwise: %m" );

// full conquest (lower population)
announcementGameTypes[3].Add( "ConquestLarge0" );
announcementGameTypes[3].Add( "ConquestAssaultLarge0" );
announcementMinPlayers[3] = 1;
announcementMaxPlayers[3] = 45;
announcementServerNameMatchRequired[3] = false;
announcementServerName1[3] = "";
announcementServerName2[3] = "";
announcementText[3].Add( "Next map is based on players at start of next round:" );
announcementText[3].Add( "< 32: Random map from \"Popular Rush\" rotation" );
announcementText[3].Add( "Otherwise: %m" );

// full conquest (higher population)
announcementGameTypes[4].Add( "ConquestLarge0" );
announcementGameTypes[4].Add( "ConquestAssaultLarge0" );
announcementMinPlayers[4] = 46;
announcementMaxPlayers[4] = 64;
announcementServerNameMatchRequired[4] = false;
announcementServerName1[4] = "";
announcementServerName2[4] = "";
announcementText[4].Add( "Next map: %m" );

// -----------------------------------------------------------------------
//
// END ANNOUNCEMENTS
//
// -----------------------------------------------------------------------


// -----------------------------------------------------------------------
//
// HUMAN-READABLE MAP AND GAMETYPE NAMES
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

/* BF3 friendly game modes */
Dictionary<string, string> Modes = new Dictionary<string, string>();    
Modes.Add("ConquestLarge0", "Conquest Large");
Modes.Add("ConquestSmall0", "Conquest Smalll");
Modes.Add("RushLarge0", "Rush");
Modes.Add("SquadRush0", "Squad Rush");
Modes.Add("SquadDeathMatch0", "Squad Deathmatch");
Modes.Add("TeamDeathMatch0", "Team Deathmatch");
// Back to Karkand modes
Modes.Add("ConquestAssaultLarge0", "Conquest Assault");
Modes.Add("ConquestAssaultSmall0", "Conquest Assault");
Modes.Add("ConquestAssaultSmall1", "Conquest Assault");
// Close Quarters modes
Modes.Add("Domination0", "Conquest Domination");
Modes.Add("GunMaster0", "Gun Master");
Modes.Add("TeamDeathMatchC0", "TDM Close Quarters");
// Armoured Kill modes
Modes.Add("TankSuperiority0","Tank Superiority");
// Aftermath modes
Modes.Add("Scavenger0","Scavenger");
// End Game modes
Modes.Add("AirSuperiority0","Air Superiority");
Modes.Add("CaptureTheFlag0","CaptureTheFlag");

if( !Maps.ContainsKey(server.MapFileName) || 
	!Maps.ContainsKey(server.NextMapFileName) || 
	!Modes.ContainsKey(server.NextGamemode) )
{
	plugin.ConsoleWrite(plugin.R("[One of the NextMapInfo limits] ERROR: Map name or gametype name not found in dictionary"));
	return false;
}
// -----------------------------------------------------------------------
//
// END MAP AND GAMETYPE NAMES
//
// -----------------------------------------------------------------------

// -----------------------------------------------------------------------
//
// MAIN WORK BEGINS HERE
//
// -----------------------------------------------------------------------
        
int? gameTypeSwitchingAnnouncementIndex = null;
bool announcementFound = false;
string replacedMsg;

plugin.ConsoleWrite(plugin.R("%p_n%: !nextmap"));

// Figure out which predefined gametype switching announcements applies right now.
// requires gametype match, population within the defined range, and maybe a server name match
for( int i=0; i < numAnnouncements; i++ )
{
	foreach( string gameType in announcementGameTypes[i] )
	{
		if( (server.Gamemode == gameType) &&
			(server.PlayerCount >= announcementMinPlayers[i]) &&
			(server.PlayerCount <= announcementMaxPlayers[i]) &&
			(
				!announcementServerNameMatchRequired[i] ||
				(announcementServerName1[i] == server.Name) ||
				(announcementServerName2[i] == server.Name) 
			) &&
			!announcementFound )
		{
			// match.  We will use this announcement.
			gameTypeSwitchingAnnouncementIndex = i;
			// stop searching -- prevents us from matching other announcements
			// (e.g. we have two conquest announcements, don't want to require a server name
			// match for both if not needed)
			announcementFound = true;
		}
	}
}

if( !announcementFound )
{
	plugin.ConsoleWrite( "ERROR: No matching announcement found for next map announcement." );
	return false;
}

// OK, now print messaging, starting with any enqueued messages.
foreach( string msg in announcementText[gameTypeSwitchingAnnouncementIndex.Value] )
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
	
	plugin.ServerCommand( "admin.say", replacedMsg, "player", player.Name );
}
