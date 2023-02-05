using Media_Player.Download.Models;
using Media_Player.Download.Repository;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Media_Player.Download.Service
{
    public interface IYoutubeService
    {
        /// <summary>
        /// 下載
        /// </summary>
        /// <param name="url">網址</param>
        Task DownloadAsync(string url);
        /// <summary>
        /// 取得檔案資訊
        /// </summary>
        VideoInfoDto GetVideoInfo();
    }

    public class YoutubeService : IYoutubeService
    {
        public string? Title { get; private set; }
        public string? Author { get; private set; }
        public TimeSpan? Duration { get; private set; }

        private readonly IYoutubeRepoistory youtubeRepo;

        public YoutubeService(IYoutubeRepoistory youtubeRepo)
        {
            this.youtubeRepo = youtubeRepo;
        }

        /// <summary>
        /// 設定下載資訊
        /// </summary>
        /// <param name="youtube"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task GetSetInfoAsync(YoutubeClient youtube, string url)
        {
            var video = await youtube.Videos.GetAsync(url);

            Title = video.Title;
            Author = video.Author.ChannelTitle;
            Duration = video.Duration;
        }

        /// <summary>
        /// 下載
        /// </summary>
        /// <param name="url">網址</param>
        public async Task DownloadAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            try
            {
                var youtube = new YoutubeClient();

                await GetSetInfoAsync(youtube, url);

                StreamManifest streamManifest = await youtube.Videos.Streams.GetManifestAsync(url);

                IStreamInfo streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

                string guid = Guid.NewGuid().ToString().Replace("-", "");

                await youtubeRepo.SaveAsync(youtube, streamInfo, guid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 取得檔案資訊
        /// </summary>
        public VideoInfoDto GetVideoInfo()
        {
            return new()
            {
                Title = Title,
                Author = Author,
                Duration = Duration,
            };
        }
    }
}
