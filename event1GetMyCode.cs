//watch for /getcode in the chatbox
if( Regex.Match(player.LastChat, @"^\s*[!/](getcode)$", RegexOptions.IgnoreCase).Success )
{
    //set score minimum
    int threshold = 500;

    //is that player eligible?
    if(player.Score >= threshold){

        //you win!
        string success = "Congratulations! You are now eligible for the $100 giveaway!";
        plugin.ServerCommand ( "admin.say" , success, "player" , player.Name ) ;
        
        //would this actually work? the random class must exist within insanelimits
        Random RndNum = new Random();
        
        //make a random 5 digit number, not perfect, but works, and it's okay if there is a duplicate, easy to write down quickly
        int RnNum = RndNum.Next(10000,99999);

        //tell player that number
        string yourNum = "Your unique # is " + RnNum;
        plugin.ServerCommand ( "admin.say" , yourNum, "player" , player.Name ) ;
        //i found this function in the insanelimits source code, I don't know if it works, should yell the number and keep it there for 999999
        //in case the chatbox floods away the number
        SendPlayerYellV(player.Name, "Your unique # is " + RnNum, 999999)
        
        //visit purebattlefield (or some other website!)
        plugin.ServerCommand ( "admin.say" , "Visit purebattlefield.org to enter your code!", "player", player.Name );
        
        //Log a file that's dated with 1EVENT.csv in some folder somewhere
        String logName = plugin.R("Logs/%server_host%_%server_port%/1EVENTlog/") + "1EVENT.csv";
        String line = player.Name + "," + RnNum;
        plugin.Log(logName, line);
        return false;

    }else{

        //you lose!
        string scoreTooLow = "Your in-game score is below the current threshold of " + threshold + ".";
        plugin.ServerCommand ( "admin.say", scoreTooLow, "player" , player.Name ) ;
        string tryAgain = "Try again when your score is above " + threshold + "! NOTE: You can only enter once - if you already have successfully requested a code, you're set!";
        plugin.ServerCommand ( "admin.say", tryAgain, "player" , player.Name ) ;
        return false;
    }
}

return true;