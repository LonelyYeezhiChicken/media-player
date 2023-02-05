using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Media_Player.Download.Repository
{
    public interface IYoutubeRepoistory
    {
        /// <summary>
        /// 儲存音樂
        /// </summary>
        /// <param name="youtube"></param>
        /// <param name="streamInfo"></param>
        /// <returns></returns>
        Task SaveAsync(YoutubeClient youtube, IStreamInfo streamInfo, string guid);
    }

    public class YoutubeRepoistory : IYoutubeRepoistory
    {
        /// <summary>
        /// 檢查目錄是否存在，不存在就建立
        /// </summary>
        /// <param name="path">目錄路徑</param>
        private static void CheckDirectory(string path)
        {
            bool dirExists = Directory.Exists(path);

            if (dirExists == false)
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// 儲存音樂
        /// </summary>
        /// <param name="youtube"></param>
        /// <param name="streamInfo"></param>
        /// <returns></returns>
        public async Task SaveAsync(YoutubeClient youtube, IStreamInfo streamInfo, string guid)
        {
            CheckDirectory(@"./AppData");

            await youtube.Videos.Streams.DownloadAsync(streamInfo,
                @$"./AppData/{guid}.{streamInfo.Container}");
        }
    }
}
