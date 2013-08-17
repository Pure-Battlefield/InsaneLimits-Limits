if( limit.Activations() > 1 )
        return false;

plugin.ConsoleWrite("Announcing the next map...");

String map_msg = "Next map is " + plugin.FriendlyMapName(server.NextMapFileName) + " " + plugin.FriendlyModeName(server.NextGamemode);
String rnd_msg = "(It may be different if the server population changes enough to activate a different map rotation.) ";
plugin.ServerCommand("admin.say", StripModifiers(E(map_msg)), "all");
plugin.ServerCommand("admin.say", StripModifiers(E(rnd_msg)), "all");

return true;