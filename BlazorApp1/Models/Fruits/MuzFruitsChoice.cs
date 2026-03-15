namespace BlazorApp1.Models;

/// <summary>
///     <pre>
/// ［Bad Know-how/Good wrapper > Collection］　果物の選択。
///     </pre>
/// </summary>
public record MuzFruitsChoice
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
    public MuzFruitsChoice(
        Func<bool> getAlternativeWhenNotSet,
        Func<bool> getAlternativeWhenWhitespace,
        Func<bool> getAlternativeWhenParseError,
        MuzRValue<string>? hasAppleStr = null,
        MuzRValue<string>? hasBananaStr = null,
        MuzRValue<string>? hasCherryStr = null)
    {
        this.HasApple = _Parse(hasAppleStr);
        this.HasBanana = _Parse(hasBananaStr);
        this.HasCherry = _Parse(hasCherryStr);

        return;

        // ［ローカル関数］

        bool _Parse(MuzRValue<string>? rval)
        {
            if (rval == null) return getAlternativeWhenNotSet();
            if (string.IsNullOrWhiteSpace(rval.Value)) return getAlternativeWhenWhitespace();
            if (!bool.TryParse(rval.Value, out bool result)) return getAlternativeWhenParseError();
            return result;
        }
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
