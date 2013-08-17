//watch for /code in the chatbox
if( Regex.Match(player.LastChat, @"^\s*[!/](code)$", RegexOptions.IgnoreCase).Success )
{
    //set score minimum
    int threshold = 500;

    //is that player eligible?
    if(player.ScoreRound >= threshold){

        //you win!
        
        //would this actually work? the random class must exist within insanelimits
        Random RndNum = new Random();
        
        //make a random 5 digit number, not perfect, but works, and it's okay if there is a duplicate, easy to write down quickly
        int RnNum = RndNum.Next(10000,99999);

        //tell player that number
        string yourNum = "Your giveaway code is " + RnNum + ".";
        plugin.ServerCommand ( "admin.say" , yourNum, "player" , player.Name ) ;
        //i found this function in the insanelimits source code, I don't know if it works, should yell the number and keep it there for 999999
        //in case the chatbox floods away the number
    	// [Adama] It's 3am, so rather than messing with untested code, I'm going to skip this...
		// I'll add a message explaining that the player can just do /code again if it scrolls away.
        // SendPlayerYellV(player.Name, "Your giveaway code is " + RnNum, 999999)
        
        //visit purebattlefield (or some other website!)
        string msg = "Enter this code at register.purebattlefield.org.";
        plugin.ServerCommand ( "admin.say" , msg, "player" , player.Name ) ;
        msg = "(If it scrolls away, just type /code again.)";
        plugin.ServerCommand ( "admin.say" , msg, "player" , player.Name ) ;
        
        //Log a file that's dated with GiveawayCodes.csv in some folder somewhere
		String time = DateTime.Now.ToString("HH:mm:ss");
        String logName = plugin.R("Logs/%server_host%_%server_port%/") + "GiveawayCodes.csv";
        String line = time + "," + player.Name + "," + player.ScoreRound + "," + RnNum;
        plugin.Log(logName, line);
        return true;

    }else{

        //you lose!
        string scoreTooLow = "You need at least " + threshold + " points to receive a giveaway code.";
        plugin.ServerCommand ( "admin.say", scoreTooLow, "player" , player.Name ) ;
        return true;
    }
}

return true;
