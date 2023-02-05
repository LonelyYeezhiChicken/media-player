namespace Media_Player.Download.Models
{
    public class VideoInfoDto
    {
        /// <summary>
        /// 標題
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string? Author { get; set; }
        /// <summary>
        /// 時間
        /// </summary>
        public TimeSpan? Duration { get; set; }
    }
}
