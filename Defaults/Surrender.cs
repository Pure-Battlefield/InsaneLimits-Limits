/*
Description: Pure Battlefield surrender limit for Insane Limits plugin v0.8R7 for PRoCon v1.X.
Function: offers the option for the losing team to surrender; ends the current game round, forfeits the game to the winning team and starts the next round.

Original author: "PapaCharlie9"
Original code: https://forum.myrcon.com/showthread.php?4533-Insane-Limits-V0-8-R5-Vote-to-nuke-camping-base-raping-team-or-!surrender-%28CQ-Rush%29&p=51515&viewfull=1#post51515
Fork version: 1.0.0
Fork author: Filippos D. Soulakis ("txapollo243")
Fork author contact e-mail: txapollo243@gmail.com
Fork author website: http://reddit.com/user/txapollo342
*/

/// Configurable variables

double percent = 30; // percentage of minimum number of players per total number of players in the __losing team__ that have to vote
double timeout = 3.0; // number of minutes before the vote expires
double timeToVoteMotion = 3.0; // time period since the start of the round (in minutes) within which voting isn't allowed
int minPlayers = 16; // minimum number of players for vote activation
double minTicketPercent = 20; // minimum percentage of tickets remaining
double minTicketGap = 80; // minimum ticket gap between winning and losing teams

// Output messages (take care to modify the replacements appropriately in string.Format() functions)

string voteFailRoundNearingEnd = "You can't surrender with < 20% tickets remaining.";
string voteFailTooSoon = "You can't surrender in the first 3 minutes of a round.";
string voteFailSmallTicketGap = "You must be losing by over 80 tickets to surrender..";
string voteFailLowVoterTurnout = "There must be at least 16 total players to surrender.";
string alreadyVoted = "You've already participated in this surrender vote.";
string votedFor = "You've placed a vote for your team to surrender!";
string voteFailTimeout = "Surrender vote has failed. ({0}% / {1}% votes)";
string votedForVoteStatus = "{0} more votes in {1} minutes needed to pass.";
string consoleVotedFor = "^b[VoteNext]^n {0} voted to end the round.";
string consoleTimerStarted = "^b[VoteNext]^n vote timer started.";
string consoleTimeout = "^b[VoteNext]^n vote timeout expired.";
string consoleLoserVotes = "^b[VoteNext]^n loser votes = {0} of {1}.";
string consoleNeededVotes = "^b[VoteNext]^n needed votes = {0}.";
string roundEnds = "{0} wins due to the opposing team's surrender!";

/// End of configurable variables' section

String kNext = "votenext";
String kVoteTime = "votenext_time";
String kNeeded = "votenext_needed";

int level = 2;

try {
	level = Convert.ToInt32(plugin.getPluginVarValue("debug_level"));
} catch (Exception e) {}

String msg = "empty";

Action<String> ChatPlayer = delegate(String name) {
	// closure bound to String msg
	plugin.ServerCommand("admin.say", msg, "player", name);
	plugin.PRoConChat("ADMIN to " + name + " > *** " + msg);
};


// Parse the command

Match nextMatch = Regex.Match(player.LastChat, @"^\s*[@!/](?:surrender)", RegexOptions.IgnoreCase);

// Bail out if not a proper vote

if (!nextMatch.Success) return false;

// Bail out if round about to end

if (server.RemainTicketsPercent(1) < minTicketPercent || server.RemainTicketsPercent(2) < minTicketPercent) {
	msg = voteFailRoundNearingEnd;
	ChatPlayer(player.Name);
	return false;
}

// Bail out if not enough time has passed 

if (server.TimeRound < timeToVoteMotion) {
	msg = voteFailTooSoon;
	ChatPlayer(player.Name);
	return false;
}
// Bail out if ticket ratio isn't large enough

double t1 = server.RemainTickets(1);
double t2 = server.RemainTickets(2);
if (Math.Abs(t1 - t2) < minTicketGap) {
	msg = voteFailSmallTicketGap;
	ChatPlayer(player.Name);
	return false;
}

/* Determine losing team by tickets */

int losing = (t1 < t2) ? 1 : 2;

/* Bail out if not enough players to enable vote */

if (server.PlayerCount < minPlayers) {
	msg = voteFailLowVoterTurnout;
	ChatPlayer(player.Name);
	return false;
}

/* Count the vote in the voter's dictionary */
/* Votes are kept with the voter */
/* If the voter leaves, his votes are not counted */

if (!player.RoundData.issetBool(kNext)) {
	player.RoundData.setBool(kNext, true);
} else {
	msg = alreadyVoted;
	ChatPlayer(player.Name);
	return false;
}

if (level >= 2) plugin.ConsoleWrite(string.Format(consoleVotedFor, player.FullName));

msg = votedFor;
ChatPlayer(player.Name);

/* Tally the votes */

int votes = 0;
List<PlayerInfoInterface> losers = (losing == 1) ? team1.players : team2.players;
List<PlayerInfoInterface> winners = (losing == 1) ? team2.players : team1.players;

/* Bail out if too much time has past */

bool firstTime = false;

if (!server.RoundData.issetObject(kVoteTime)) {
	server.RoundData.setObject(kVoteTime, DateTime.Now);
	if (level >= 2) plugin.ConsoleWrite(consoleTimerStarted);
	firstTime = true;
}
DateTime started = (DateTime)server.RoundData.getObject(kVoteTime);
TimeSpan since = DateTime.Now.Subtract(started);

int needed = Convert.ToInt32(Math.Ceiling((double) losers.Count * (percent/100.0)));
int remain = needed - votes;

if (since.TotalMinutes > timeout) {
	msg = string.Format(voteFailTimeout, Convert.ToInt32(Math.Ceiling((votes/needed)*100.0)), percent);
	ChatPlayer(player.Name);
	if (level >= 2) plugin.ConsoleWrite(consoleTimeout);
	foreach (PlayerInfoInterface can in losers) {
		// Erase the vote
		if (can.RoundData.issetBool(kNext)) can.RoundData.unsetBool(kNext);
	}
	foreach (PlayerInfoInterface can in winners) {
		// Erase the vote
		if (can.RoundData.issetBool(kNext)) can.RoundData.unsetBool(kNext);
	}
	server.RoundData.unsetObject(kVoteTime);

	return false;
}

/* Otherwise tally */

foreach(PlayerInfoInterface p in losers) {
    if (p.RoundData.issetBool(kNext)) votes++;
}
if (level >= 3) plugin.ConsoleWrite(string.Format(consoleLoserVotes, votes, losers.Count));

if (server.RoundData.issetInt(kNeeded)) needed = Math.Min(needed, server.RoundData.getInt(kNeeded));
server.RoundData.setInt(kNeeded, needed);

if (level >= 3) plugin.ConsoleWrite(string.Format(consoleNeededVotes, needed));

String voters = (losing == 1) ? "US" : "RU";
String otherVoters = (losing == 1) ? "RU" : "US";

if (remain > 0) {
    if (firstTime) {
		msg = string.Format(votedForVoteStatus, remain, Convert.ToInt32(Math.Ceiling(timeout - since.TotalMinutes)));
	}
    ChatPlayer(player.Name);
	if (level >= 2) plugin.ConsoleWrite("^b[VoteNext]^n " + msg);
	return false;
}

/* End the round */

String wteam = (losing == 1) ? "RU" : "US";

msg = string.Format(roundEnds, wteam);
plugin.SendGlobalMessage(msg);
plugin.ServerCommand("admin.yell", msg, "10");
if (level >= 2) plugin.ConsoleWrite("^b[VoteNext]^n " + msg);

String wid = (losing == 1) ? "2" : "1";

ThreadStart roundEnder = delegate {
    Thread.Sleep(10*1000);
    plugin.ServerCommand("mapList.endRound", wid);
};

Thread enderThread = new Thread(roundEnder);
enderThread.Start();
Thread.Sleep(10);

return false;
