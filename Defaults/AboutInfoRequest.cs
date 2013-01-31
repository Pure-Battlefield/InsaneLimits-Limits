if( Regex.Match(player.LastChat, @""^\s*[!/](aboutpure)$"", RegexOptions.IgnoreCase).Success )
{
        string about_1 = ""We use all maps (when full), default settings (incl."";
        string about_2 = ""vehicle spawns), modest tickets, a squad-preserving"";
        string about_3 = ""team balancer, squad VOIP (TS3Sync) & many"";
        string about_4 = ""admins. Open community: purebattlefield.reddit.com."";

        List<string> About = new List<string>();
        About.Add(about_1);
        About.Add(about_2);
        About.Add(about_3);
        About.Add(about_4);

        plugin.ConsoleWrite(plugin.R(""%p_n%: !aboutpure""));

        foreach(string X in About)
                plugin.ServerCommand(""admin.say"", X, ""player"", player.Name);
}
                
return false;
