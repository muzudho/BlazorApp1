namespace BlazorApp1.Models.Fruits;

/// <summary>
///     <pre>
/// ［Bad Know-how/Good wrapper > Collection］　果物の選択。
///     </pre>
/// </summary>
public record MuzFruitsSelection
{


    // ========================================
    // 生成／破棄
    // ========================================


    /// <summary>
    /// 生成。
    /// </summary>
    /// <param name="hasApple">りんごを持っている。</param>
    /// <param name="hasBanana">バナナを持っている。</param>
    /// <param name="hasCherry">さくらんぼを持っている。</param>
    public MuzFruitsSelection(bool hasApple, bool hasBanana, bool hasCherry)
    {
        this.HasApple = hasApple;
        this.HasBanana = hasBanana;
        this.HasCherry = hasCherry;
    }


    // ========================================
    // 窓口プロパティ
    // ========================================


    /// <summary>
    /// りんごを持っている。
    /// </summary>
    bool HasApple { get; init; }

    /// <summary>
    /// バナナを持っている。
    /// </summary>
    bool HasBanana { get; init; }

    /// <summary>
    /// さくらんぼを持っている。
    /// </summary>
    bool HasCherry { get; init; }
}
