namespace BlazorApp1.Infrastructure.ComponentParts;

/// <summary>
///     <pre>
/// 同じ非同期メソッドが連続で呼び出されて並走する、ということを防止するためのガードクラス。
/// 
///     0秒   1秒   2秒   3秒   4秒   5秒   6秒
///     +---------+
///     |    A    |
///     +---------+
///           +---------+
///           |    B    |
///           +---------+
///                 +---------+
///                 |    C    |
///                 +---------+
///     
///     を、
///     
///     0秒   1秒   2秒   3秒   4秒   5秒   6秒
///     +---------+ +---------+ +---------+
///     |    A    | |    B    | |    C    |
///     +---------+ +---------+ +---------+
///           
///     にする感じです。
///     </pre>
/// </summary>
internal class MuzReentranceGuard
{


    // ========================================
    // 内部データメンバー
    // ========================================


    /// <summary>
    /// 実行中か。
    /// </summary>
    private bool _inProgress;

    /// <summary>
    /// 後でもう１回呼び出す必要があるか。
    /// </summary>
    private bool _isPending;


    // ========================================
    // 窓口メソッド
    // ========================================


    internal async Task ScreeningAsync(
        Func<Task> passedAsync,
        Func<Task> rejectAsync)
    {
        if (!this._inProgress)
        {
            this._inProgress = true;
            try
            {
                await passedAsync();
            }
            finally
            {
                this._inProgress = false;
            }

            if (this._isPending)
            {
                this._isPending = false;
                await rejectAsync();
            }
        }
        else
        {
            this._isPending = true;
        }
    }
}
