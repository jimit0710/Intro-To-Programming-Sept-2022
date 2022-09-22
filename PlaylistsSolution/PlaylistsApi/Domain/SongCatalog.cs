namespace PlaylistsApi.Domain;

public class SongCatalog : IProvideTheSongCatalog
{
    public async Task<GetSongsResponse> GetAllSongsAsync()
    {
        return new GetSongsResponse();
    }
}