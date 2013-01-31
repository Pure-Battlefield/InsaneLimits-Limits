if( Regex.Match(player.LastChat, @""^\s*[!/][!/]?(adminhelp2)$"", RegexOptions.IgnoreCase).Success )
{
        string adm_1 = ""/!nosync: Disable TS squad sync for you this round"";
        string adm_2 = ""/!restart, /!nextlevel (seeding or emergency use only)"";

        List<string> ADM = new List<string>();
        ADM.Add(adm_1);
        ADM.Add(adm_2);

        plugin.ConsoleWrite(plugin.R(""%p_n%: /!adminhelp2""));

        if ( plugin.isInList ( player.Name, ""admins"" ) )
        {
                foreach(string X in ADM)
                        plugin.ServerCommand(""admin.say"", X, ""player"", player.Name);
        }
        else
        {
                plugin.ServerCommand(""admin.say"", ""You are not an admin!"", ""player"", player.Name);
        }
}
        
return false;