using Media_Player.Download.Models;
using Media_Player.Download.Service;

namespace Media_Player.Download
{
    public interface IMediaDownloadProvider
    {
        /// <summary>
        /// 下載 youtube
        /// </summary>
        /// <param name="url">網址</param>
        Task YoutubeDownloadAsync(string url);

        /// <summary>
        /// 取得剛下載的音樂資訊
        /// </summary>
        /// <returns>VideoInfoDto 音樂資訊</returns>
        VideoInfoDto GetYoutubeVideoInfo();
    }

    public class MediaDownloadProvider : IMediaDownloadProvider
    {

        private readonly IYoutubeService _youtubeService;

        public MediaDownloadProvider(IYoutubeService youtubeService)
        {
            _youtubeService = youtubeService;
        }

        /// <summary>
        /// 下載 youtube
        /// </summary>
        /// <param name="url">網址</param>
        public async Task YoutubeDownloadAsync(string url)
        {
            await _youtubeService.DownloadAsync(url);
        }

        /// <summary>
        /// 取得剛下載的音樂資訊
        /// </summary>
        /// <returns>VideoInfoDto 音樂資訊</returns>
        public VideoInfoDto GetYoutubeVideoInfo()
        {
            return _youtubeService.GetVideoInfo();
        }
    }
}
