using Media_Player.Download.Repository;
using Media_Player.Download.Service;

namespace Media_Player.Download.Tests
{
    [TestFixture]
    internal class YoutubeServiceTests
    {
        [Test]
        public void Download_Test_下載()
        {
            IYoutubeService youtubeService = new YoutubeService(new YoutubeRepoistory());

            youtubeService.DownloadAsync(@"https://youtu.be/NYgcBxfRWQA").Wait();
        }

        [Test]
        public void GetVideoInfo_Test_取得資訊()
        {
            IYoutubeService youtubeService = new YoutubeService(new YoutubeRepoistory());

            youtubeService.DownloadAsync(@"https://youtu.be/XzFUbGQrOhM").Wait();
            var info = youtubeService.GetVideoInfo();
            Console.WriteLine(info);
        }
    }
}
