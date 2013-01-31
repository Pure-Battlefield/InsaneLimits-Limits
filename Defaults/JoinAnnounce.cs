// -----------------------------------------------------------------------
//
// KEY CONSTANTS
//
// -----------------------------------------------------------------------

int maxPopulationForPlayerJoinAnnouncements = 24;

// -----------------------------------------------------------------------
//
// END KEY CONSTANTS
//
// -----------------------------------------------------------------------

if ( plugin.isInList ( player.Name, "admins" ) )
{
        // this is an admin joining
        plugin.SendGlobalMessage(plugin.R("Admin %p_n% is joining the server."));
}
else        // it is a non-admin player joining
{        
        if( server.PlayerCount <= maxPopulationForPlayerJoinAnnouncements )
        {
                plugin.SendGlobalMessage(plugin.R("%p_n% is joining the server."));                
        }
}