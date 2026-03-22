namespace BlazorApp1.Infrastructure.ComponentParts;

/// <summary>
/// ［ライフサイクル・メソッドのフロー］を補うモデル。
/// </summary>
internal class MuzLifeCycleModel
{
    /// <summary>
    /// ［パラメーター］の加工完了後か。
    /// </summary>
    internal bool HasParametersSetAsync { get; set; }

    /// <summary>
    /// パラメーターを使った初期化完了後か。
    /// </summary>
    internal bool IsReady { get; set; }
}
