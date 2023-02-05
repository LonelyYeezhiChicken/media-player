using Media_Player.Download.Repository;
using Media_Player.Download.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Media_Player.Download.Config
{
    public static class MediaDownloadDI
    {
        public static void AddMediaDownload(this IServiceCollection services)
        {
            services.AddScoped<IYoutubeRepoistory, YoutubeRepoistory>();
            services.AddScoped<IYoutubeService, YoutubeService>();

            services.AddSingleton<IMediaDownloadProvider, MediaDownloadProvider>();
        }
    }
}
