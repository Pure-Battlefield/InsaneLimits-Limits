string rule_1 = "1. Be considerate. Profanity's fine, but don't be mean.";
string rule_2 = "2. No bigoted language (e.g. \"fag\").";
string rule_3 = "3. Do not consciously hinder your team.";
string rule_4 = "For details, see rules.purebattlefield.org.";

List<string> Rules = new List<string>();
Rules.Add(rule_1);
Rules.Add(rule_2);
Rules.Add(rule_3);
Rules.Add(rule_4);

plugin.ConsoleWrite(plugin.R("%p_n% wanted to know the rules"));

foreach(string X in Rules)
{        
        plugin.ServerCommand("admin.say", X, "player", player.Name);
}
return false;