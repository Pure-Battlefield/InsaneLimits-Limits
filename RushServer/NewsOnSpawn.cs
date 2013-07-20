// NEWS SECTION should have content from Server Content tab in Content / Config spreadsheet
// If this isn't the right time to do the message, abort.
// (limit.Activations(player.Name) == 1): first spawn of each round only 
// (player.RoundsTotal > 0): skip the first round that this player is on the server
if(        !(
                (limit.Activations(player.Name) == 1) &&
                (player.RoundsTotal > 0)
         )
 )
        return false; 

/* NEWS SECTION */
  	
string news_1 = "SERVER NEWS: July 8th"; 
string news_2 = "A celebration of PURE's first anniversary!"; 
string news_3 = "Saturday 7/27: 11-4 PDT / 2-7 EDT";
string news_4 = "";

List<string> News = new List<string>(); 
News.Add(news_1);
News.Add(news_2);
News.Add(news_3);
News.Add(news_4);

//creates a newsyell string for yelling the news
string newsyell = "" + news_1 + "\n\n" + news_2 + "\n" + news_3 + "\n" + news_4;

foreach(string X in News)
{
        plugin.ServerCommand("admin.say", X, "player", player.Name);
        
}

//This will Yell the news message only required for urgent news
plugin.ServerCommand("admin.yell", newsyell, "10", "player", player.Name);

return false;
