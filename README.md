# media-player
音樂播放


### 組件依賴
- YoutubeExplode

### 影音下載
- 註冊
```
 services.AddMediaDownload();
```

- 介面
```
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
```