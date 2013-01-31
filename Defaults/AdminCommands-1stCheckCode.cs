if( Regex.Match(player.LastChat, @""^\s*[!/][!/]?(adminhelp)$"", RegexOptions.IgnoreCase).Success )
{
        string adm_1 = ""/@(p)say, /@(p)yell ([player]) [text]"";
        string adm_2 = ""/!kill, /!kick, /!ban [player] [reason]"";
        string adm_3 = ""/@switch, /@switchnow [player] (fails intermittently)"";
        string adm_4 = ""/!adminhelp2: Additional commands"";

        List<string> ADM = new List<string>();
        ADM.Add(adm_1);
        ADM.Add(adm_2);
        ADM.Add(adm_3);
        ADM.Add(adm_4);

        plugin.ConsoleWrite(plugin.R(""%p_n%: /!adminhelp""));

        if ( plugin.isInList ( player.Name, ""admins"" ) )
        {
                foreach(string X in ADM)
                        plugin.ServerCommand(""admin.say"", X, ""player"", player.Name);
        }
        else
        {
                plugin.ServerCommand(""admin.say"", ""You are not an admin!"", ""player"", player.Name);
        }

        return false;
}

return true;