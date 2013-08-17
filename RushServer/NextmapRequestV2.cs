//watch for !nextmap
if (Regex.Match(player.LastChat, @"^\s*[!/](nextmap)$", RegexOptions.IgnoreCase).Success)
{
plugin.ConsoleWrite(plugin.R("" + player.Name + " wants to know the next map"));

String map_msg = "Next map is " + plugin.FriendlyMapName(server.NextMapFileName);
String rnd_msg = "(It may be different if the server population changes enough to activate a different map rotation.) ";
plugin.SendGlobalMessage(map_msg);
plugin.SendGlobalMessage(rnd_msg);
plugin.ServerCommand("admin.yell", map_msg, "8", "player", player.Name);

return true;
}

return true;
