// Revision : 5
// action taken on damage modifiers
	Action<String> DamageModifierPlayer = delegate(String who) {
       // set action here default is 1 hour ban
        server.SendMail("anticheat@purebattlefield.org", "Player " + player.Name + " is banned for damage modifier", "PB Guid: " + player.PBGuid);
        String message = "Suspicious stats | Appeal: appeals@purebattlefield.org";
        plugin.EABanPlayerWithMessage(EABanType.EA_GUID, EABanDuration.Temporary, who, 60, message);
	};
// action taken for blackpoint violaters
	Action<String> BlackPointPlayer = delegate(String who) {
        // set action here default is 1 hour ban
        server.SendMail("anticheat@purebattlefield.org", "Player " + player.Name + " is banned for black points", "PB Guid: " + player.PBGuid);
        String message = "Suspicious stats | Appeal: appeals@purebattlefield.org";
        plugin.EABanPlayerWithMessage(EABanType.EA_GUID, EABanDuration.Temporary, who, 60, message);
	};
// how many black points are required for the action to be taken
    int TakeAction = 20; // recommended is 20 and above Minimum is 20
// how many black points are required for notification to trigger
    int NotifyMe = 5; // recommended above 5 and below TakeAction value
// here you can setup a notification
Action<String> NotifyMeAbout = delegate(String who) {
        // set notification here, such as email,sound notification, taskbar notification, logging etc ..
        // this is triggered for all players who have Black points above the NotifyMe value
        server.SendMail("anticheat@purebattlefield.org", "Player " + player.Name + " is suspicous", "PB Guid: " + player.PBGuid);
        plugin.Log("Cheat-o-meter.log", plugin.R("[%date% %time%] [%server_host%] [server.Name] [player.EAGuid] " + who)); // this will log player name only with his EA GUID, still require testing
	};
// options END
    
if (limit.Activations(player.Name) != 1) return false;
if ( (player.Time/60)/60 < 15) return false;

Dictionary<String,double> avg_HK = new Dictionary<String,double>();
// PDW
avg_HK["AS VAL"] = 14.83;
avg_HK["Weapons/XP2_MP5K/MP5K"] = 13.72;
avg_HK["MP7"] = 13.01;
avg_HK["Weapons/P90/P90"] = 13.05;
avg_HK["Weapons/MagpulPDR/MagpulPDR"] = 15.81;
avg_HK["PP-19"] = 11.51;
avg_HK["PP-2000"] = 15.45;
avg_HK["Weapons/UMP45/UMP45"] = 16.03;
// Engineer 
avg_HK["Weapons/A91/A91"] = 16.36;
avg_HK["Weapons/XP2_ACR/ACR"] = 13.62;
avg_HK["AKS-74u"] = 16.46;
avg_HK["Weapons/G36C/G36C"] = 16.38;
avg_HK["HK53"] = 16.58;
avg_HK["M4A1"] = 16;
avg_HK["Weapons/XP2_MTAR/MTAR"] = 16.96;
avg_HK["QBZ-95B"] = 16.22;
avg_HK["Weapons/SCAR-H/SCAR-H"] = 19.82;
avg_HK["SG 553 LB"] = 16.43;
// Assault
avg_HK["AEK-971"] = 16.52;
avg_HK["Weapons/AK74M/AK74"] = 16.44;
avg_HK["AN-94 Abakan"] = 16.04;
avg_HK["Steyr AUG"] = 16.63;
avg_HK["F2000"] = 17.00;
avg_HK["FAMAS"] = 16.8;
avg_HK["Weapons/G3A3/G3A3"] = 21.46;
avg_HK["Weapons/KH2002/KH2002"] = 16.61;
avg_HK["Weapons/XP1_L85A2/L85A2"] = 16.49;
avg_HK["M16A4"] = 15.98;
avg_HK["Weapons/M416/M416"] = 16.68;
avg_HK["SCAR-L"] = 16.53;
//Support
avg_HK["M27IAR"] = 16.32;
avg_HK["RPK-74M"] = 16.04;
avg_HK["Weapons/XP2_L86/L86"] = 16.25;
avg_HK["LSAT"] = 16.17;
avg_HK["M60"] = 19.98;
avg_HK["M240"] = 20.09;
avg_HK["M249"] = 16.16;
avg_HK["MG36"] = 16.44;
avg_HK["Pecheneg"] = 20.93;
avg_HK["QBB-95"] = 16.31;
avg_HK["Type88"] = 15.59;
// Recon
avg_HK["JNG90"] = 52.62;
avg_HK["L96"] = 50.54;
avg_HK["M39"] = 31.87;
avg_HK["M40A5"] = 52.13;
avg_HK["Model98B"] = 52.81;
avg_HK["M417"] = 32.76;
avg_HK["Mk11"] = 31.4;
avg_HK["QBU-88"] = 33.03;
avg_HK["SKS"] = 25.55;
avg_HK["SV98"] = 48.03;
avg_HK["SVD"] = 32.06;
// Pistols
avg_HK["Glock18"] = 18.43;
avg_HK["M1911"] = 25.02;
avg_HK["M9"] = 17.89;
avg_HK["M93R"] = 18.5;
avg_HK["Taurus .44"] = 38.66;
avg_HK["Weapons/MP412Rex/MP412REX"] = 35.13;
avg_HK["Weapons/MP443/MP443"] = 18.58;

Dictionary<String,double> norm_DPS = new Dictionary<String,double>();
// PDW
norm_DPS["AS VAL"] = 20;
norm_DPS["Weapons/XP2_MP5K/MP5K"] = 25;
norm_DPS["MP7"] = 20;
norm_DPS["Weapons/P90/P90"] = 20;
norm_DPS["Weapons/MagpulPDR/MagpulPDR"] = 25;
norm_DPS["PP-19"] = 16.7;
norm_DPS["PP-2000"] = 25;
norm_DPS["Weapons/UMP45/UMP45"] = 34;
// Engineer 
norm_DPS["Weapons/A91/A91"] = 25;
norm_DPS["Weapons/XP2_ACR/ACR"] = 20;
norm_DPS["AKS-74u"] = 25;
norm_DPS["Weapons/G36C/G36C"] = 25;
norm_DPS["HK53"] = 25;
norm_DPS["M4A1"] = 25;
norm_DPS["Weapons/XP2_MTAR/MTAR"] = 25;
norm_DPS["QBZ-95B"] = 25;
norm_DPS["Weapons/SCAR-H/SCAR-H"] = 30;
norm_DPS["SG 553 LB"] = 25;
// Assault
norm_DPS["AEK-971"] = 25;
norm_DPS["Weapons/AK74M/AK74"] = 25;
norm_DPS["AN-94 Abakan"] = 25;
norm_DPS["Steyr AUG"] = 25;
norm_DPS["F2000"] = 25;
norm_DPS["FAMAS"] = 25;
norm_DPS["Weapons/G3A3/G3A3"] = 34;
norm_DPS["Weapons/KH2002/KH2002"] = 25;
norm_DPS["Weapons/XP1_L85A2/L85A2"] = 25;
norm_DPS["M16A4"] = 25;
norm_DPS["Weapons/M416/M416"] = 25;
norm_DPS["SCAR-L"] = 25;
//Support
norm_DPS["M27IAR"] = 25;
norm_DPS["RPK-74M"] = 25;
norm_DPS["Weapons/XP2_L86/L86"] = 25;
norm_DPS["LSAT"] = 25;
norm_DPS["M60"] = 34;
norm_DPS["M240"] = 34;
norm_DPS["M249"] = 25;
norm_DPS["MG36"] = 25;
norm_DPS["Pecheneg"] = 34;
norm_DPS["QBB-95"] = 25;
norm_DPS["Type88"] = 25;
// Recon
norm_DPS["JNG90"] = 80;
norm_DPS["L96"] = 80;
norm_DPS["M39"] = 50;
norm_DPS["M40A5"] = 80;
norm_DPS["Model98B"] = 95;
norm_DPS["M417"] = 50;
norm_DPS["Mk11"] = 50;
norm_DPS["QBU-88"] = 50;
norm_DPS["SKS"] = 43;
norm_DPS["SV98"] = 80;
norm_DPS["SVD"] = 50;
// Pistols
norm_DPS["Glock18"] = 25;
norm_DPS["M1911"] = 34;
norm_DPS["M9"] = 25;
norm_DPS["M93R"] = 20;
norm_DPS["Taurus .44"] = 60;
norm_DPS["Weapons/MP412Rex/MP412REX"] = 50;
norm_DPS["Weapons/MP443/MP443"] = 25;


List<String> cheatometer = new List<String>();
BattlelogWeaponStatsInterface Get = null;
String DPSCOLOR = "^2";
String HSKCOLOR = "^2";
String KPMCOLOR = "^2";
String ACCCOLOR = "^2";
String BPCOLOR = "^2";
String BlackPointsCounter= player.Name + "_Weapon_BlackPoints";
String cheatedCounter= player.Name + "_Weapon_cheated";
String DPSmodifier = null;
int BlackPoints = 0;
int cheated = 0;
if (TakeAction < 20) TakeAction = 20;
if (NotifyMe >= TakeAction) NotifyMe = TakeAction-1;

foreach (String Gun in avg_HK.Keys) {
    Get = player.GetBattlelog(Gun);
	if (Get.Kills < 120) continue;
    Match m = Regex.Match(Gun, @"/([^/]+)$");
    String wn = Gun;
    if (m.Success) wn = m.Groups[1].Value;
    DPSCOLOR = "^2";
    HSKCOLOR = "^2";
    KPMCOLOR = "^2";
    ACCCOLOR = "^2";
    double HSmodifier = 1;
    if (avg_HK[Gun] > 25) HSmodifier = 1.2;
    double ShotsHit = Math.Round((Get.ShotsFired*(Get.Accuracy / 100)), 0);
    double DPS = Math.Round(((Get.Kills/ShotsHit)*100), 2);
    double HeadshotsRatio = Math.Round(((Get.Headshots/Get.Kills)*100), 2);
    double HSmodified = Math.Round(HeadshotsRatio * HSmodifier, 2);
    double MaxDPS = Math.Round((norm_DPS[Gun] * (1+(HSmodified/100))), 0);
    double KPM = Math.Round(Get.Kills/(Get.TimeEquipped/60), 1);
    double Accuracy = Math.Round(Get.Accuracy, 0);
    if (DPS > (MaxDPS * 1.3) && DPS <= (MaxDPS * 1.4)) {
        DPSCOLOR = "^3";
        server.Data.setInt(BlackPointsCounter, BlackPoints+1);
        if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
    }
    if (DPS  > (MaxDPS * 1.4) && DPS <= (MaxDPS * 1.8)) {
            DPSCOLOR = "^7";
            server.Data.setInt(BlackPointsCounter, BlackPoints+3);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
    }
    if (DPS > (MaxDPS * 1.8)) {
            DPSCOLOR = "^8";
            server.Data.setInt(cheatedCounter, 1);
    }
    if (avg_HK[Gun] <= 25) {
        if (DPS <= (MaxDPS * 1.3) && HeadshotsRatio < 40 && ( (KPM <= 3.5 && player.Rank <= 120) || (KPM <= 4 && player.Rank > 120) ) && Accuracy <= 35) continue;
        if (HeadshotsRatio >= 40 && HeadshotsRatio <= 45) {
            HSKCOLOR = "^3";
            server.Data.setInt(BlackPointsCounter, BlackPoints+2);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
        }
        if (HeadshotsRatio > 45 && HeadshotsRatio <=55) {
            HSKCOLOR = "^7";
            server.Data.setInt(BlackPointsCounter, BlackPoints+3);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
        }
        if (HeadshotsRatio > 55) {
            HSKCOLOR = "^8";
            server.Data.setInt(BlackPointsCounter, BlackPoints+5);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
        }
        if (Accuracy > 35 && Accuracy <= 40) {
            ACCCOLOR = "^3";
            server.Data.setInt(BlackPointsCounter, BlackPoints+1);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
        }
        if (Accuracy > 40 && Accuracy <= 50) {
            ACCCOLOR = "^7";
            server.Data.setInt(BlackPointsCounter, BlackPoints+2);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
        }
        if (Accuracy > 50) {
            ACCCOLOR = "^8";
            server.Data.setInt(BlackPointsCounter, BlackPoints+3);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
        }
    }
    if (avg_HK[Gun] > 25) {
        if (DPS <= (MaxDPS * 1.3) && HeadshotsRatio < 90 && ( (KPM <= 3.5 && player.Rank <= 120) || (KPM <= 4 && player.Rank > 120) ) && Accuracy <= 50) continue;
        if (HeadshotsRatio >= 90 && HeadshotsRatio <= 93) {
            HSKCOLOR = "^3";
            server.Data.setInt(BlackPointsCounter, BlackPoints+1);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
        }
        if (HeadshotsRatio > 93 && HeadshotsRatio <=96) {
            HSKCOLOR = "^7";
            server.Data.setInt(BlackPointsCounter, BlackPoints+2);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
        }
        if (HeadshotsRatio > 96) {
            HSKCOLOR = "^8";
            server.Data.setInt(BlackPointsCounter, BlackPoints+3);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
        }
        if (Accuracy > 50 && Accuracy <= 60) {
            ACCCOLOR = "^3";
            server.Data.setInt(BlackPointsCounter, BlackPoints+1);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
        }
        if (Accuracy > 60 && Accuracy <= 70) {
            ACCCOLOR = "^7";
            server.Data.setInt(BlackPointsCounter, BlackPoints+2);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
        }
        if (Accuracy > 70) {
            ACCCOLOR = "^8";
            server.Data.setInt(BlackPointsCounter, BlackPoints+3);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
        }
    }
    if (KPM > 3.5 && KPM <= 4.5) {
        KPMCOLOR = "^3";
        if (player.Rank <= 120) server.Data.setInt(BlackPointsCounter, BlackPoints+1);
		if (player.Rank > 120 && KPM > 4) server.Data.setInt(BlackPointsCounter, BlackPoints+1);
        if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
    }
    if (KPM > 4.5 && KPM <= 5.5) {
            KPMCOLOR = "^7";
            if (player.Rank <= 120) server.Data.setInt(BlackPointsCounter, BlackPoints+2);
			if (player.Rank > 120) server.Data.setInt(BlackPointsCounter, BlackPoints+1);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
    }
    if (KPM > 5.5) {
            KPMCOLOR = "^8";
            if (player.Rank <= 120) server.Data.setInt(BlackPointsCounter, BlackPoints+3);
			if (player.Rank > 120) server.Data.setInt(BlackPointsCounter, BlackPoints+2);
            if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);
    }
    cheatometer.Add("^b[" + wn+ "] " + DPSCOLOR + "DPS : " + DPS + "/" + norm_DPS[Gun] + "-" + MaxDPS + " ^0|" + HSKCOLOR + " Headshot/Kill : " + HeadshotsRatio + "% ^0|" + KPMCOLOR + " Kills/minute : " + KPM + " ^0|" + ACCCOLOR + " Accuracy : " + Accuracy + "% ^0| Kills : " + Get.Kills + "^0^n");
}

if (cheatometer.Count == 0) return false;

if (server.Data.issetInt(BlackPointsCounter)) BlackPoints = server.Data.getInt(BlackPointsCounter);

if (server.Data.issetInt(cheatedCounter)) cheated = server.Data.getInt(cheatedCounter);


plugin.PRoConChat("--------------------------------------------------" + player.Name + "--------------------------------------------------");
plugin.PRoConChat("^b^2Green = normal/fine ^0| ^3Yellow = above normal ^0| ^7Pink = highly suspicious ^0 | ^8Red = 99% cheat^n^0");
foreach (String metered in cheatometer) {
    plugin.PRoConChat(metered);
}

if (cheated == 1) {
    DamageModifierPlayer(player.Name);
    DPSmodifier = " ^8^b, player is damage modifier and is banned^0^n";
}

if (BlackPoints >= 1) {
    // add any action for notifying.
	plugin.ConsoleWrite("^3^b[Evaluating]^0^n " + player.Name + " has " + BlackPoints + " Black Points");
    if (BlackPoints > 5 && BlackPoints <= 10) BPCOLOR = "^3";
    if (BlackPoints > 10 && BlackPoints <= 15) BPCOLOR = "^7";
    if (BlackPoints > 15) BPCOLOR = "^8";
    if (BlackPoints >= TakeAction && cheated == 0) {
        BlackPointPlayer(player.Name);
    }
    if (BlackPoints <= 15 && cheated >= 0) plugin.PRoConChat(player.Name + " has " + BPCOLOR + BlackPoints + "^0^n black points" + DPSmodifier);
	if (BlackPoints > 15 && BlackPoints < TakeAction && cheated == 1) plugin.PRoConChat(player.Name + " has " + BPCOLOR + BlackPoints + "^0^n black points" + DPSmodifier);
    if (BlackPoints > 15 && BlackPoints < TakeAction && cheated == 0) plugin.PRoConChat(player.Name + " has " + BPCOLOR + BlackPoints + "^0^n black points, please investigate the player.");
	if (BlackPoints >= TakeAction && cheated == 1) plugin.PRoConChat(player.Name + " has " + BPCOLOR + BlackPoints + "^0^n black points" + DPSmodifier);
    if (BlackPoints >= TakeAction && cheated == 0) plugin.PRoConChat(player.Name + " has " + BPCOLOR + BlackPoints + " black points and is banned");
    plugin.SendTaskbarNotification("warning", "cheatmeter");
}
if (BlackPoints >= NotifyMe) {
	NotifyMeAbout(player.Name);
	plugin.Log("cheat-o-meter.log", "--------------------------------------------------" + player.Name + "--------------------------------------------------");
	foreach (String metered in cheatometer) {
        plugin.Log("cheat-o-meter.log", metered);
    }
}
return false;
