//watch for !nextmap
if (Regex.Match(player.LastChat, @"^\s*[!/](nextmap)$", RegexOptions.IgnoreCase).Success)
{
plugin.ConsoleWrite("" + player.Name + " wants to know the next map");

String map_msg = "Next map is " + plugin.FriendlyMapName(server.NextMapFileName);
String rnd_msg = "(It may be different if the server population changes enough to activate a different map rotation.) ";
plugin.ServerCommand("admin.say", map_msg, "player", player.Name);
plugin.ServerCommand("admin.say", rnd_msg, "player", player.Name);
plugin.ServerCommand("admin.yell", map_msg, "8", "player", player.Name);

return true;
}

return true;
