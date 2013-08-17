if( limit.Activations() > 1 )
        return false;

if((team1.RemainTicketsPercent < 15 || team2.RemainTicketsPercent < 15)){

plugin.ConsoleWrite("Announcing the next map...");

String map_msg = "Next map is " + plugin.FriendlyMapName(server.NextMapFileName) + " on " + plugin.FriendlyModeName(server.NextGamemode);
String rnd_msg = "(It may be different if the server population changes enough to activate a different map rotation.) ";
plugin.ServerCommand("admin.say", map_msg, "all");
plugin.ServerCommand("admin.say", rnd_msg, "all");

return true;
}
return true;