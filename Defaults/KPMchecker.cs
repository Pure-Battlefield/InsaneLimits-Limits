/* VERSION 0.8/R1 */

string kKills = "kill rate kills"; // player.RoundData double
string kCount = "kill rate count"; // player.RoundData int
string kHalf = "kill rate half minute"; // plugin.RoundData int
string kLegit = "kill rate legit"; // player.RoundData int

// Keep track of full minutes
if (!plugin.RoundData.issetInt(kHalf)) plugin.RoundData.setInt(kHalf, 0);

int half = plugin.RoundData.getInt(kHalf);
bool isMinute = (half != 0 && (half % 2) == 0);
plugin.RoundData.setInt(kHalf, half+1);

// Set up for logging
string fancy_time = DateTime.Now.ToString("HH:mm:ss");
string fancy_date = DateTime.Now.ToString("yyyy-MM-dd");

List<PlayerInfoInterface> all = new List<PlayerInfoInterface>();
all.AddRange(team1.players);
all.AddRange(team2.players);
if (team3.players.Count > 0) all.AddRange(team3.players);
if (team4.players.Count > 0) all.AddRange(team4. players);

foreach (PlayerInfoInterface p in all) {
        // Initialize the kill count and counter for every player
        if (!p.RoundData.issetDouble(kKills)) {
                p.RoundData.setDouble(kKills, p.KillsRound);
                p.RoundData.setInt(kCount, 0);
                p.RoundData.setInt(kLegit, 0);
                continue;
        }
        bool sendChat = false;

        // Compare the kills over the last minute (2 intervals)
        double last = p.RoundData.getDouble(kKills);
        int count = p.RoundData.getInt(kCount);
        double kills = (p.KillsRound - last);
        if (isMinute && kills >= 20) {
                count = count + 1;
                p.RoundData.setInt(kCount, count);
                sendChat = true;
        }

        string kpm = (isMinute) ? (", KPM: " + kills.ToString("F0")) : " *";

        // Debugging, only the first 10 intervals of a count 1 suspect
        if (count > 0) {
                int legit = p.RoundData.getInt(kLegit);
                p.RoundData.setInt(kLegit, legit+1);

                if (count == 2 || (count == 1 && legit < 10)) {
                    plugin.Log("Logs/InsaneLimits_KPM3_DEBUG.log", "[ " + fancy_date + " ] [ " + fancy_time + " ] [Auto-Admin] DEBUG " + p.Name + ", Kills: " + p.KillsRound + ", last: " + last + ", Spree: " + limit.Spree(p.Name) + ", Deaths: " + p.DeathsRound + ", count: " + count + kpm);
                }
        }

        if (sendChat && count == 1) {
                string msg = "[Auto-Admin] Possible hacker/cheater detected, taking action shortly";
                plugin.ServerCommand("admin.yell", msg, "10");
                plugin.ServerCommand("admin.say", msg, "all");
                plugin.Log("Logs/InsaneLimits_KPM3.csv", fancy_date + "," + fancy_time + "," + p.Name + "," + plugin.R("%l_n%") + "," + p.PBGuid + "," + plugin.R("%server_port%") + "," + kills + ",#1");
        }

        if (sendChat && count == 2) {
                string msg = "[Auto-Admin] " + p.Name + " was kicked & banned";
                plugin.ServerCommand("admin.yell", msg, "10");
                plugin.ServerCommand("admin.say", msg, "all");
                plugin.Log("Logs/InsaneLimits_KPM3.csv", fancy_date + "," + fancy_time + "," + p.Name + "," + plugin.R("%l_n%") + "," + p.PBGuid + "," + plugin.R("%server_port%") + "," + kills + ",#2");
                plugin.EABanPlayerWithMessage(EABanType.Name, EABanDuration.Permanent, p.Name, 0, "[Auto-Admin] Hacking/Cheating - Extreme KPM");
        }

        if (isMinute) p.RoundData.setDouble(kKills, p.KillsRound); // IMPORTANT: this is your "reset" to 0
}
return false;