string fancy_time = DateTime.Now.ToString("HH:mm:ss");

string fancy_date = DateTime.Now.ToString("yyyy-MM-dd");

double avg_per = 5;

double p_ka = ( ( player.KillAssists / player.Kills ) * 100 ); 

double max_kpm = 3.5;

if ( ( p_ka <= avg_per ) && ( player.Kills >= 1000 ) )
        {        
                plugin.Log("Logs/InsaneLimits_PKA2.csv", plugin.R("" + fancy_date + "," + fancy_time + ",%p_n%,%l_n%,%p_pg%," + p_ka + ""));
        }

if ( player.Kpm >= max_kpm )
        {
                plugin.Log("Logs/InsaneLimits_BLKPM.csv", plugin.R("" + fancy_date + "," + fancy_time + ",%p_n%,%l_n%,%p_pg%," + player.Kpm + ""));
        }

return false;
