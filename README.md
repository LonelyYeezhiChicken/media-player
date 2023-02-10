# media-player
手機離線音樂播放器

### TODO
- [ ] 下載Youtube音樂
- [ ] 音樂清單
- [ ] 離線播放
- [ ] 鎖屏播放


### 環境依賴
.NET 6
NUnit
MAUI

### 組件依賴
- YoutubeExplode

### 影音下載
- 註冊
```csharp
 services.AddMediaDownload();
```

- 介面
```csharp
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

