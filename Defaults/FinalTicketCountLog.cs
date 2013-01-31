/* Version: V0.8/R2 */

/* Track count of players by map/mode name */

bool logToFile = true; // Set to false to disable logging

String kMaxPlayers = "PCT_max"; // PCT = Player Count Tracker
String kMinPlayers = "PCT_min";
String kPlayers = "PCT_players";
String kTime = "PCT_time";
String kMapRound = "PCT_map_round";

if (!server.Data.issetInt(kPlayers)) {
        server.Data.setInt(kPlayers, 0);
}
if (!server.RoundData.issetInt(kMaxPlayers)) {
        server.RoundData.setInt(kMaxPlayers, 0);
}
if (!server.RoundData.issetInt(kMinPlayers)) {
        server.RoundData.setInt(kMinPlayers, 64);
}
if (!server.RoundData.issetObject(kTime)) {
        server.RoundData.setObject(kTime, DateTime.Now);
}
if (!server.RoundData.issetString(kMapRound)) {
        server.RoundData.setString(kMapRound, server.MapFileName + server.CurrentRound.ToString());
}

int level = 2;

try {
        level = Convert.ToInt32(plugin.getPluginVarValue("debug_level"));
} catch (Exception e) {}

/* Check for change */

int lastPlayers = server.Data.getInt(kPlayers);
int currentPlayers = server.PlayerCount;

        


/* Calculate net change */

int maxPlayers = server.RoundData.getInt(kMaxPlayers);
int minPlayers = server.RoundData.getInt(kMinPlayers);

int netChange = currentPlayers - lastPlayers;

if (maxPlayers < currentPlayers) {
        server.RoundData.setInt(kMaxPlayers, currentPlayers);
        maxPlayers = currentPlayers;
}
if (minPlayers > currentPlayers) {
        server.RoundData.setInt(kMinPlayers, currentPlayers);
        minPlayers = currentPlayers;
}
server.Data.setInt(kPlayers, currentPlayers);
server.RoundData.setObject(kTime, DateTime.Now);

/* Log changes */

/* BF3 friendly map names, including B2K */
Dictionary<String, String> maps = new Dictionary<String, String>();
maps.Add("MP_001", "Bazaar");
maps.Add("MP_003", "Teheran");
maps.Add("MP_007", "Caspian");
maps.Add("MP_011", "Seine");
maps.Add("MP_012", "Firestorm");
maps.Add("MP_013", "Damavand");
maps.Add("MP_017", "Canals");
maps.Add("MP_018", "Kharg");
maps.Add("MP_Subway", "Metro");
maps.Add("XP1_001", "Karkand");
maps.Add("XP1_002", "Oman");
maps.Add("XP1_003", "Sharqi");
maps.Add("XP1_004", "Wake");
maps.Add("XP2_Factory", "Factory");
maps.Add("XP2_Office", "Office");
maps.Add("XP2_Palace", "Palace");
maps.Add("XP2_Skybar", "Skybar");

/* BF3 friendly game modes, including B2K */
Dictionary<String, String> modes = new Dictionary<String, String>();    
modes.Add("ConquestLarge0", "CQ64");
modes.Add("ConquestSmall0", "CQ");
modes.Add("ConquestSmall1", "CQA");
modes.Add("RushLarge0", "Rush");
modes.Add("SquadRush0", "SQRush");
modes.Add("SquadDeathMatch0", "SQDM");
modes.Add("TeamDeathMatch0", "TDM");
modes.Add("Domination0", "CQD");
modes.Add("GunMaster0", "GM");
modes.Add("TeamDeathMatchC0", "TDMC");

String mapName = (maps.ContainsKey(server.MapFileName)) ? maps[server.MapFileName] : server.MapFileName;
String modeName = (modes.ContainsKey(server.Gamemode)) ? modes[server.Gamemode] : server.Gamemode;
String color = (netChange >= 0) ? "^2+" : "^8";
String time = DateTime.Now.ToString("HH:mm:ss");
String currMapRound = server.MapFileName + server.CurrentRound.ToString();

int adminCount = 0;
bool found = false;
List<PlayerInfoInterface> players = new List<PlayerInfoInterface>();
players.AddRange(team1.players);
players.AddRange(team2.players);
if (team3.players.Count > 0)
        players.AddRange(team3.players);
if (team4.players.Count > 0)
        players.AddRange(team4.players);
foreach (PlayerInfoInterface p in players) 
{
        if (plugin.isInList(p.Name, "admins")) 
        {
                adminCount = adminCount + 1;
        }
}

// Example console line:
// [PCT]: Metro/CQ64/1/2, T1:240/T2:181, 47/64, -3 net change. Round (min-max) 33-60

// Log to console if map/round changed, or if debugging and player count changed
if (!server.RoundData.getString(kMapRound).Equals(currMapRound) || (level >= 3 && lastPlayers != currentPlayers)) {
        plugin.ConsoleWrite("^b[PCT]^n: ^4" + mapName + "/" + modeName + "/" + (server.CurrentRound+1) + "/" + server.TotalRounds + "^0, " + "T1:" + team1.RemainTickets + "/" + "T2:" + team2.RemainTickets + ", " + currentPlayers + "/" + server.MaxPlayers + ", ^b" + color + netChange + "^0^n net change. Round (min-max) " + minPlayers + "-" + maxPlayers);
        server.RoundData.setString(kMapRound, currMapRound);
}

// Example log line:
// 23:11:54,Karkand,CQ64,1,2,240,181,21,32,1,18,30
if (logToFile) {
        String logName = plugin.R("Logs/%server_host%_%server_port%/FTC/") + DateTime.Now.ToString("yyyyMMdd") + "_ftc.csv";
        String log2Name = plugin.R("Logs/%server_host%_%server_port%/PCT/") + DateTime.Now.ToString("yyyyMMdd") + "_pct.csv";
        String line = time + "," + mapName + "," + modeName + "," + (server.CurrentRound+1) + "," + server.TotalRounds + "," + team1.RemainTickets + "," + team2.RemainTickets + "," + currentPlayers + "," + server.MaxPlayers + "," + netChange + "," + minPlayers + "," + maxPlayers + "," + adminCount;
        plugin.Log(logName, line);
        plugin.Log(log2Name, line);
}