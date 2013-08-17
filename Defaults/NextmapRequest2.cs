//watch for !nextmap
if (Regex.Match(player.LastChat, @"^\s*[!/](nextmap)$", RegexOptions.IgnoreCase).Success)
{
plugin.ConsoleWrite(plugin.R("" + player.Name + " wants to know the next map"));

String map_msg = "Next map is " + plugin.FriendlyMapName(server.NextMapFileName) + " on " + plugin.FriendlyModeName(server.NextGamemode);
String rnd_msg = "The current round is " + (server.CurrentRound+1) + " of " + server.TotalRounds;
plugin.SendGlobalMessage(map_msg);
plugin.SendGlobalMessage(rnd_msg);
plugin.ServerCommand("admin.yell", map_msg, "8", "player", player.Name);
plugin.ServerCommand("admin.yell", rnd_msg, "5", "player", player.Name);

return true;
}

return true;
