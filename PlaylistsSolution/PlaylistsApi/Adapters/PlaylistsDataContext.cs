using Microsoft.EntityFrameworkCore;
using PlaylistsApi.Domain;

namespace PlaylistsApi.Adapters;

public class PlaylistsDataContext : DbContext
{
    public PlaylistsDataContext(DbContextOptions<PlaylistsDataContext> options) : base(options)
    {

    }
    public DbSet<SongEntity> Songs { get; set; }
}