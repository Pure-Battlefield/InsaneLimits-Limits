// KEY CONSTANTS must be customized per server
// Only show the welcome message once per player session: first spawn of the first round.
// (depends on logic in the InsaneLimits expression as well)
if( (player.RoundsTotal > 0) || 
        (limit.Activations(player.Name) > 1) )
        return false;
        
// -----------------------------------------------------------------------
//
// KEY CONSTANTS (STANDARD)
//
// -----------------------------------------------------------------------

// -----------------------------------------------------------------------
//
// WELCOME MESSAGES
//
// -----------------------------------------------------------------------

// Main welcome message: Shown in yell, and also chat box if server is populated
string greet_1 = "Welcome to PURE BATTLEFIELD!";
string greet_2 = "Please type !help for rules and other commands.";
string greet_3 = "We are an open gaming community; all are welcome.";
string greet_4 = "Join us at purebattlefield.org!";

// Low Population welcome message: Shown in chat if server pop is below 20
List<String> seed = new List<String>();
seed.Add("Attention, soldier! Let's get this server going!");
seed.Add("We'll run Damavand Rush until we get more players.");
seed.Add("Please type !help for server rules and other commands.");

// string seedingGameTypeName = "Rush";
// string nextGameTypeName = "Conquest";
//seed.Add("1-" + maxSeedingPopulation + " players at round start: " + seedingGameTypeName);
//seed.Add("" + (maxSeedingPopulation + 1) + "+ players at round start: " + nextGameTypeName);

// -----------------------------------------------------------------------
//
// END WELCOME MESSAGES
//
// -----------------------------------------------------------------------

// -----------------------------------------------------------------------
//
// DO THE WORK
//
// -----------------------------------------------------------------------

// Show the same welcome yell everytime.
string yell = "" + greet_1 + "\n\n" + greet_2 + "\n\n" + greet_3 + "\n" + greet_4;
plugin.ServerCommand("admin.yell", yell, "20", "player", player.Name);

// Are we currently seeding?
bool currentlySeeding = false;
if( (server.PlayerCount < 20) 
  )
{
        currentlySeeding = true;
}

// If we're seeding, show one message in chat, otherwise show the yell content again in chat
if( currentlySeeding )
{
        // Show the message
        foreach( string X in seed )
                plugin.ServerCommand("admin.say", X, "player", player.Name);
}
else
{
        // Show welcome message in chat for populated server
        plugin.ServerCommand("admin.say", greet_1, "player", player.Name);
        plugin.ServerCommand("admin.say", greet_2, "player", player.Name);
        plugin.ServerCommand("admin.say", greet_3, "player", player.Name);
        plugin.ServerCommand("admin.say", greet_4, "player", player.Name);
}

return false;