string fancy_time = DateTime.Now.ToString("HH:mm:ss");

string fancy_date = DateTime.Now.ToString("yyyy-MM-dd");

List<string> racisms = new List<string>();
        racisms.Add("nigger");
        racisms.Add("paki");
        racisms.Add("fag");
        racisms.Add("faggot");
        racisms.Add("homo");
        
string[] chatwords = Regex.Split(player.LastChat, @"\s+");
        
foreach(String chatword in chatwords) 
{
        foreach(String racism in racisms)
        {
                if (Regex.Match(chatword, "^"+racism+"[s]?[^a-z]*$", RegexOptions.IgnoreCase).Success)
                {
                        plugin.KickPlayerWithMessage(player.Name, plugin.R("[Auto-Admin] Bigoted language"));
                        plugin.SendGlobalMessage(plugin.R("%p_n% was auto-kicked for using bigoted language (not for profanity). Type \"!rules\" for details."));
                        plugin.ConsoleWarn(plugin.R("%p_n% used the word: "+racism+""));
                        plugin.ConsoleWarn(plugin.R("%p_n% was auto-kicked for using the word: "+racism+"!"));                        
                        plugin.Log("Logs/InsaneLimits_BWD.log", plugin.R("[" + fancy_date + "] [" + fancy_time + "] %p_n% said [" + player.LastChat + "]"));
                        return true;
                        
                }
        }
}