// --------------------------------------------------------------------------------------------------------------------------------------
//
// CONFIGURATION VARIABLES
//
// --------------------------------------------------------------------------------------------------------------------------------------

// The "scenario_#_email_body" variables support a number of string replacements:
//
// [current_server_population]      Total number of players currently on the server
// [current_non_seeder_population]  Total number of non-seeders currently on the server
// [current_seeder_population]      Total number of seeders currently on the server
// [current_seeder_names]           "They are: " + list of seeder names currently on the server
// [current_idle_seeder_population] Total number of idle seeders currently on the server
// [current_idle_seeder_names]      "They are: " + list of idle seeder names currently on the server
// [ideal_seeder_population]        Ideal number of seeders on the server in times of need
// [server_url]  					URL for the server in need of seeding
// [seeder_list_url]				URL for the list of server seeder account names

// Debug levels
// 0:  No debug data
// 1:  Debug info appended to regular e-mails
// 2:  Same as level 1, but override email recipients & subject line with debug values
// 3:  Same as level 2, plus debug info sent even if no scenarios are triggered
// 4:  Same as level 3, plus resets the "last time triggered" for all scenarios to 0
int debug_level = 1;
string debug_email_recipients = "jhogan@purebattlefield.org";					// comma-separated list
string debug_email_subject = "Seeder notification debug e-mail";

// Global variables
int ideal_seeder_population = 4;
int idle_threshold_seconds = 360;		// length of time before a seeder is considered idle.  (NOTE: Currently approximated by whether a seeder has a score of 0, and the round is at least this many seconds old 
string seeder_list_url = "http://seeders.purebattlefield.org";

// Max population for each server
int[] max_server_population = new int[3];
max_server_population[1] = 64;
max_server_population[2] = 48;

// Scenario 1 (Population critically low) variables
int scenario_1_max_current_non_seeder_population = 6;
int scenario_1_max_current_seeder_population = 2;
int scenario_1_min_minutes_since_last_scenario_1_trigger_daytime = 20;
int scenario_1_min_minutes_since_last_scenario_1_trigger_nighttime = 180;

// The following variables are based on the server's time:
int scenario_1_nighttime_start_hour = 0;		
int scenario_1_nighttime_start_minute = 0;
int scenario_1_nighttime_end_hour = 9;
int scenario_1_nighttime_end_minute = 0;

string scenario_1_email_recipients = "seeders@purebattlefield.org";			// comma-separated list
string scenario_1_email_subject = "All hands on deck! Seeders urgently needed!";
List <string> scenario_1_email_body = new List <string>();
scenario_1_email_body.Add( "The server currently has only [current_non_seeder_population] players (excluding seeders).  We need some seeder help!  Click here: [server_url]" );
scenario_1_email_body.Add( "" );
scenario_1_email_body.Add( "Our goal is to have [ideal_seeder_population] seeders on the server; currently we have [current_seeder_population]." );
scenario_1_email_body.Add( "[current_seeder_names]" );
scenario_1_email_body.Add( "" );
scenario_1_email_body.Add( "If you join, please check the scoreboard to make sure you're not bumping the server over [ideal_seeder_population] seeders.  The current seeder accounts are listed here: [seeder_list_url]" );
scenario_1_email_body.Add( "" );
scenario_1_email_body.Add( "Thank you for your service to PURE!" );

// Scenario 2 (Population modest) variables
int[] scenario_2_max_current_server_population = new int[65];				// defines what the threshold should be for a server of a particular max size
scenario_2_max_current_server_population[64] = 42;
scenario_2_max_current_server_population[48] = 30;
int scenario_2_max_current_seeder_population = 2;
int scenario_2_min_minutes_since_last_scenario_1_trigger = 180;
int scenario_2_min_minutes_since_last_scenario_2_trigger = 180;

// The following variables are based on the server's time:
int scenario_2_silent_start_hour = 6;		
int scenario_2_silent_start_minute = 0;
int scenario_2_silent_end_hour = 21;
int scenario_2_silent_end_minute = 0;

string scenario_2_email_recipients = "seeders@purebattlefield.org";			// comma-separated list
string scenario_2_email_subject = "Seeders needed on the front!";
List <string> scenario_2_email_body = new List <string>();
scenario_2_email_body.Add( "The server currently has [current_server_population] people on it.  We need some seeder help!  Click here: [server_url]" );
scenario_2_email_body.Add( "" );
scenario_2_email_body.Add( "Our goal is to have [ideal_seeder_population] seeders on the server; currently we have [current_seeder_population]." );
scenario_2_email_body.Add( "[current_seeder_names]" );
scenario_2_email_body.Add( "" );
scenario_2_email_body.Add( "At moderate server populations, seeders can greatly extend server activity into the late evening.  More importantly, having those seeders still around at the crack of dawn gives us a huge head start in the morning." );
scenario_2_email_body.Add( "" );
scenario_2_email_body.Add( "If you join, please check the scoreboard to make sure you're not bumping the server over [ideal_seeder_population] seeders.  The current seeder accounts are listed here: [seeder_list_url]" );
scenario_2_email_body.Add( "" );
scenario_2_email_body.Add( "Thank you for your service to PURE!" );

// Scenario 3 (Too many seeders) variables
int scenario_3_min_current_idle_seeder_population = 6;
int scenario_3_min_minutes_since_last_scenario_3_trigger = 20;

string scenario_3_email_recipients = "seeders@purebattlefield.org,admins@purebattlefield.org";		// comma-separated list
string scenario_3_email_subject = "Too many seeders -- players are being scared away!";
List <string> scenario_3_email_body = new List <string>();
scenario_3_email_body.Add( "The server currently has [current_idle_seeder_population] idle seeders on it.  This is too many!" );
scenario_3_email_body.Add( "" );
scenario_3_email_body.Add( "Too many idle seeders can actually drive players away, because they join expecting a lively game, only to find a quiet battlefield." );
scenario_3_email_body.Add( "" );
scenario_3_email_body.Add( "Our goal is to have no more than [ideal_seeder_population] idle seeders on the server; currently we have [current_idle_seeder_population].");
scenario_3_email_body.Add( "[current_idle_seeder_names]" );
scenario_3_email_body.Add( "" );
scenario_3_email_body.Add( "Idle seeders, please log out, or admins, please log on to kick.  Thanks!" );

// --------------------------------------------------------------------------------------------------------------------------------------
//
// VARIABLE DECLARATIONS & INITIALIZATIONS
//
// --------------------------------------------------------------------------------------------------------------------------------------

// general
int scenario_triggered = 0;		// Has a scenario been triggered yet?  (Only one per limit execution)
int server_number = 0;
string server_url;

// scenario trigger history
DateTime zero_time = new DateTime( 1, 1, 1, 0, 0, 0 );

string key_last_scenario_1_trigger = "last_scenario_1_trigger";
string key_last_scenario_2_trigger = "last_scenario_2_trigger";
string key_last_scenario_3_trigger = "last_scenario_3_trigger";

if( !server.Data.issetObject(key_last_scenario_1_trigger) )
	server.Data.setObject( key_last_scenario_1_trigger, zero_time );
if( !server.Data.issetObject(key_last_scenario_2_trigger) )
	server.Data.setObject( key_last_scenario_2_trigger, zero_time );
if( !server.Data.issetObject(key_last_scenario_3_trigger) )
	server.Data.setObject( key_last_scenario_3_trigger, zero_time );
	
DateTime last_scenario_1_trigger = (DateTime) server.Data.getObject( key_last_scenario_1_trigger );
DateTime last_scenario_2_trigger = (DateTime) server.Data.getObject( key_last_scenario_2_trigger );
DateTime last_scenario_3_trigger = (DateTime) server.Data.getObject( key_last_scenario_3_trigger );

// population counters
int current_seeder_population = 0;
int current_non_seeder_population = 0;
int current_idle_seeder_population = 0;

// player lists
List <PlayerInfoInterface> allPlayers = new List <PlayerInfoInterface>();
List <string> current_seeder_names_list = new List <string>();
List <string> current_idle_seeder_names_list = new List <string>();
string current_seeder_names = "";
string current_idle_seeder_names = "";

// e-mail data
string email_recipients = "";
string email_subject_prefix = "";
string email_subject = "";
List <string> email_body = new List <string>();
string idle_debug_info = "";

// scratchpad variables
string str;

// scenario 1 specific
int min_minutes_since_last_scenario_1_trigger = 0;

// notification time windows
DateTime nighttime_start = new DateTime( 1, 1, 1, 0, 0, 0 );
DateTime nighttime_end = new DateTime( 1, 1, 1, 0, 0, 0 );
DateTime silent_start = new DateTime( 1, 1, 1, 0, 0, 0 );
DateTime silent_end = new DateTime( 1, 1, 1, 0, 0, 0 );
TimeSpan one_day = new TimeSpan( 1, 0, 0, 0 );

// --------------------------------------------------------------------------------------------------------------------------------------
//
// DETERMINE SERVER NUMBER, SERVER URL, E-MAIL PREFIX
//
// --------------------------------------------------------------------------------------------------------------------------------------

// figure out server number, URL, and e-mail subject prefix
Match nextMatch = Regex.Match(server.Name, "PURE BATTLEFIELD [0-9]+");
if( !nextMatch.Success )
{
	email_subject_prefix = "[UNKNOWN SERVER] ";
	server_url = "[UNKNOWN URL]";
}
else
{
	string[] words = nextMatch.Value.Split(' ');
	server_number = Convert.ToInt32( words[2] );
	email_subject_prefix = "[SERVER " + server_number + "] ";
	server_url = "http://server" + server_number + ".purebattlefield.org";
}

// --------------------------------------------------------------------------------------------------------------------------------------
//
// DETERMINE PLAYER COUNTS AND LISTS
//
// --------------------------------------------------------------------------------------------------------------------------------------

// determine total number of players
int current_server_population = server.PlayerCount;

// determine identity & count of seeders vs. non-seeders

// prep
allPlayers.AddRange( team1.players );
allPlayers.AddRange( team2.players );
allPlayers.AddRange( team3.players );
allPlayers.AddRange( team4.players );

bool firstSeederAdded = false;
bool firstIdleSeederAdded = false;

// check if each player is a seeder
foreach( PlayerInfoInterface p in allPlayers )
{
	if( plugin.isInList(p.Name, "Seeders") )
	{
		// they're a seeder!
		if( !firstSeederAdded )
			current_seeder_names += "They are: ";
		else
			current_seeder_names += ", ";
		current_seeder_names += p.Name;
		current_seeder_names_list.Add( p.Name );
		current_seeder_population++;
		firstSeederAdded = true;

		// Build a string of debug info containing information on the seeders' idle status
		idle_debug_info += p.Name + ": " + p.ScoreRound + " points | ";
		// idle_debug_info += p.Name + ": " + plugin.CheckPlayerIdle(p.Name) + " seconds idle | ";	// this is commented out because CheckPlayerIdle() seems broken -- always returns 0

		// are they an IDLE seeder?
		// if( plugin.CheckPlayerIdle(s) > idle_threshold_seconds )		// this is commented out because CheckPlayerIdle() seems broken -- always returns 0
		if( (server.TimeRound > idle_threshold_seconds) && (p.ScoreRound == 0) )
		{
			// yes, they're an idle seeder!
			if( !firstIdleSeederAdded )
				current_idle_seeder_names += "They are: ";
			else
				current_idle_seeder_names += ", ";
			current_idle_seeder_names += p.Name;
			current_idle_seeder_names_list.Add( p.Name );
			current_idle_seeder_population++;
			firstIdleSeederAdded = true;
		}
	}
}

// calculate number of non-seeders online
current_non_seeder_population = current_server_population - current_seeder_population;

// --------------------------------------------------------------------------------------------------------------------------------------
//
// CALCULATE TIME SINCE LAST SCENARIO TRIGGERS
//
// --------------------------------------------------------------------------------------------------------------------------------------

// determine time since each scenario was last triggered
TimeSpan time_since_last_scenario_1_trigger = DateTime.Now - last_scenario_1_trigger;
TimeSpan time_since_last_scenario_2_trigger = DateTime.Now - last_scenario_2_trigger;
TimeSpan time_since_last_scenario_3_trigger = DateTime.Now - last_scenario_3_trigger;

int minutes_since_last_scenario_1_trigger = Convert.ToInt32( Math.Truncate(time_since_last_scenario_1_trigger.TotalMinutes) );
int minutes_since_last_scenario_2_trigger = Convert.ToInt32( Math.Truncate(time_since_last_scenario_2_trigger.TotalMinutes) );
int minutes_since_last_scenario_3_trigger = Convert.ToInt32( Math.Truncate(time_since_last_scenario_3_trigger.TotalMinutes) );


// --------------------------------------------------------------------------------------------------------------------------------------
//
// NIGHTTIME WINDOW CALCULATIONS
//
// --------------------------------------------------------------------------------------------------------------------------------------

// We begin by figuring out whether it's daytime or nighttime (as per the definition of scenario 1)
nighttime_start = new DateTime( DateTime.Now.Year,
								DateTime.Now.Month,
								DateTime.Now.Day,
								scenario_1_nighttime_start_hour,
								scenario_1_nighttime_start_minute,
								0 );

nighttime_end = new DateTime(   DateTime.Now.Year,
								DateTime.Now.Month,
								DateTime.Now.Day,
								scenario_1_nighttime_end_hour,
								scenario_1_nighttime_end_minute,
								0 );

// When we initialized nighttime_start and nighttime_end above, we assumed that they were on the same day.
// However, these times might actually span two different days (e.g. 11pm - 7am).
// That doesn't work, because nighttime_start then ends up being AFTER nighttime_end.
// In this case, we need to "fix" this by subtracting a day from nighttime_start, or adding a day to nighttime_end.									
if( nighttime_end <= nighttime_start )
{
	if( DateTime.Now <= nighttime_end )
		nighttime_start -= one_day;
	else
		nighttime_end += one_day;
}


// --------------------------------------------------------------------------------------------------------------------------------------
//
// SILENT WINDOW CALCULATIONS
//
// --------------------------------------------------------------------------------------------------------------------------------------

// We begin by figuring out whether it's uring the silent window (as per the definition of scenario 2)
silent_start = new DateTime( DateTime.Now.Year,
							 DateTime.Now.Month,
							 DateTime.Now.Day,
							 scenario_2_silent_start_hour,
							 scenario_2_silent_start_minute,
							 0 );

silent_end = new DateTime(   DateTime.Now.Year,
							 DateTime.Now.Month,
						  	 DateTime.Now.Day,
							 scenario_2_silent_end_hour,
							 scenario_2_silent_end_minute,
							 0 );

// When we initialized silent_start and silend_end above, we assumed that they were on the same day.
// However, these times might actually span two different days (e.g. 11pm - 7am).
// That doesn't work, because silent_start then ends up being AFTER silent_end.
// In this case, we need to "fix" this by subtracting a day from silent_start, or adding a day to silent_end.									
if( silent_end <= silent_start )
{
	if( DateTime.Now <= silent_end )
		silent_start -= one_day;
	else
		silent_end += one_day;
}


// --------------------------------------------------------------------------------------------------------------------------------------
//
// SCENARIO 1 EVALUATION
//
// --------------------------------------------------------------------------------------------------------------------------------------

// Set the "minimum time since last scenario 1 notification" threshold appropriately, depending on whether it's nighttime or not.
if( (DateTime.Now >= nighttime_start) &&
	(DateTime.Now <= nighttime_end) )
{
	// it's nighttime!
	min_minutes_since_last_scenario_1_trigger = scenario_1_min_minutes_since_last_scenario_1_trigger_nighttime;
}
else
{
	// it's daytime!
	min_minutes_since_last_scenario_1_trigger = scenario_1_min_minutes_since_last_scenario_1_trigger_daytime;
}

// primary scenario evaluation
if(
	(current_non_seeder_population <= scenario_1_max_current_non_seeder_population) &&
	(current_seeder_population <= scenario_1_max_current_seeder_population) &&
	(minutes_since_last_scenario_1_trigger >= min_minutes_since_last_scenario_1_trigger)
  )
{
	scenario_triggered = 1;
	server.Data.setObject( key_last_scenario_1_trigger, DateTime.Now );

	email_recipients = scenario_1_email_recipients;
	email_subject = scenario_1_email_subject;
	email_body = scenario_1_email_body;
}


// --------------------------------------------------------------------------------------------------------------------------------------
//
// SCENARIO 2 EVALUATION
//
// --------------------------------------------------------------------------------------------------------------------------------------

if( scenario_triggered == 0 )
{
	if(
		(current_server_population <= scenario_2_max_current_server_population[max_server_population[server_number]]) &&
		(current_seeder_population <= scenario_2_max_current_seeder_population) &&
		(minutes_since_last_scenario_1_trigger >= scenario_2_min_minutes_since_last_scenario_1_trigger ) &&
		(minutes_since_last_scenario_2_trigger >= scenario_2_min_minutes_since_last_scenario_2_trigger ) &&
		!((DateTime.Now >= silent_start) && (DateTime.Now <= silent_end))
	  )
	{
		scenario_triggered = 2;
		server.Data.setObject( key_last_scenario_2_trigger, DateTime.Now );
		
		email_recipients = scenario_2_email_recipients;
		email_subject = scenario_2_email_subject;
		email_body = scenario_2_email_body;
	}
}


// --------------------------------------------------------------------------------------------------------------------------------------
//
// SCENARIO 3 EVALUATION
//
// --------------------------------------------------------------------------------------------------------------------------------------

if( scenario_triggered == 0 )
{
	if(
		(current_idle_seeder_population >= scenario_3_min_current_idle_seeder_population) &&
		(minutes_since_last_scenario_3_trigger >= scenario_3_min_minutes_since_last_scenario_3_trigger)
	  )
	{
		scenario_triggered = 3;		
		server.Data.setObject( key_last_scenario_3_trigger, DateTime.Now );

		email_recipients = scenario_3_email_recipients;
		email_subject = scenario_3_email_subject;
		email_body = scenario_3_email_body;
	}
}


// --------------------------------------------------------------------------------------------------------------------------------------
//
// PREPARE AND SEND E-MAIL
//
// --------------------------------------------------------------------------------------------------------------------------------------

if( (scenario_triggered != 0) || (debug_level >= 3) )
{
	// perform string replacement in e-mail body
	for( int i = 0; i < email_body.Count; i++ )
	{
		email_body[i] = email_body[i].Replace( "[current_server_population]", Convert.ToString(current_server_population) );
		email_body[i] = email_body[i].Replace( "[current_non_seeder_population]", Convert.ToString(current_non_seeder_population) );
		email_body[i] = email_body[i].Replace( "[current_seeder_population]", Convert.ToString(current_seeder_population) );
		email_body[i] = email_body[i].Replace( "[current_seeder_names]", current_seeder_names );
		email_body[i] = email_body[i].Replace( "[current_idle_seeder_population]", Convert.ToString(current_idle_seeder_population) );
		email_body[i] = email_body[i].Replace( "[current_idle_seeder_names]", current_idle_seeder_names );
		email_body[i] = email_body[i].Replace( "[ideal_seeder_population]", Convert.ToString(ideal_seeder_population) );
		email_body[i] = email_body[i].Replace( "[server_url]", server_url );
		email_body[i] = email_body[i].Replace( "[seeder_list_url]", seeder_list_url );
	}
	
	// add debug info if appropriate
	if( debug_level >= 1 )
	{
		email_body.Add( "" );
		email_body.Add( "--------------------------------------------------------------" );
		email_body.Add( "" );
		email_body.Add( "DEBUG INFO:" );
		email_body.Add( "" );	
		email_body.Add( "scenario_triggered = " + scenario_triggered );		
		email_body.Add( "" );		
		email_body.Add( "current_server_population = " + current_server_population );
		email_body.Add( "current_non_seeder_population = " + current_non_seeder_population );
		email_body.Add( "current_seeder_population = " + current_seeder_population );
		email_body.Add( "current_idle_seeder_population = " + current_idle_seeder_population );
		email_body.Add( "current_seeder_names = " + current_seeder_names );
		email_body.Add( "current_idle_seeder_names = " + current_idle_seeder_names );
		email_body.Add( "" );
		email_body.Add( "idle_threshold_seconds = " + idle_threshold_seconds );
		email_body.Add( "seconds since round started = " + Convert.ToString(server.TimeRound) );
		email_body.Add( idle_debug_info );
		email_body.Add( "" );
		email_body.Add( "nighttime_start = " + nighttime_start.ToString() );
		email_body.Add( "nighttime_end = " + nighttime_end.ToString() );
		email_body.Add( "silent_start = " + silent_start.ToString() );
		email_body.Add( "silent_end = " + silent_end.ToString() );
		email_body.Add( "current time = " + DateTime.Now.ToString() );
		email_body.Add( "" );		
		email_body.Add( "last_scenario_1_trigger = " + last_scenario_1_trigger.ToString() );
		email_body.Add( "last_scenario_2_trigger = " + last_scenario_2_trigger.ToString() );
		email_body.Add( "last_scenario_3_trigger = " + last_scenario_3_trigger.ToString() );
		email_body.Add( "minutes_since_last_scenario_1_trigger = " + minutes_since_last_scenario_1_trigger );
		email_body.Add( "minutes_since_last_scenario_2_trigger = " + minutes_since_last_scenario_2_trigger );
		email_body.Add( "minutes_since_last_scenario_3_trigger = " + minutes_since_last_scenario_3_trigger );
		email_body.Add( "" );
		email_body.Add( "min_minutes_since_last_scenario_1_trigger = " + min_minutes_since_last_scenario_1_trigger );
		email_body.Add( "scenario_2_max_current_server_population[" + max_server_population[server_number] + "] = " + scenario_2_max_current_server_population[max_server_population[server_number]] );
		email_body.Add( "" );
		email_body.Add( "email_subject_prefix = " + email_subject_prefix );
		email_body.Add( "" );
		email_body.Add( "debug_level = " + debug_level );
		
		if( debug_level >= 2 )
		{
			email_recipients = debug_email_recipients;
			email_subject = debug_email_subject;
		}
	}

	// concatenate the email body strings together
	string email_body_string = "";
	for( int i = 0; i < email_body.Count; i++ )
		email_body_string += email_body[i] += "\n";
		
	// send the e-mail!
	plugin.SendMail( email_recipients, email_subject_prefix + email_subject, email_body_string );
}


// --------------------------------------------------------------------------------------------------------------------------------------
//
// CLEANUP WORK
//
// --------------------------------------------------------------------------------------------------------------------------------------

if( debug_level >= 4 )
{
	server.Data.setObject( key_last_scenario_1_trigger, zero_time );
	server.Data.setObject( key_last_scenario_2_trigger, zero_time );
	server.Data.setObject( key_last_scenario_3_trigger, zero_time );
}
