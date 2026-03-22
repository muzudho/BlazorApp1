namespace BlazorApp1.Components.Pages.Contents;

using BlazorApp1.Models;

public partial class LifeCycleExamplePage
{


    // ========================================
    // 窓口プロパティ
    // ========================================


    private string Message1 { get; set; } = string.Empty;
    private string Message2 { get; set; } = string.Empty;
    private string Message3 { get; set; } = string.Empty;
    private string Message4 { get; set; } = string.Empty;
    private string Message5 { get; set; } = string.Empty;
    private string Message6 { get; set; } = string.Empty;


    // ========================================
    // 内部プロパティ
    // ========================================


    // ［ライフサイクル・メソッドのフロー］


    private bool HasParametersSetAsync { get; set; }

    /// <summary>
    /// パラメーターを使った初期化完了時。
    /// </summary>
    private bool IsReady { get; set; }


    // ［その他］


    private string PrePhaseStart { get; set; } = string.Empty;
    private string PrePhaseEnd { get; set; } = string.Empty;
    private int NumberOfAfterRender { get; set; }
    private int NumberOfAfterRenderAsync { get; set; }
}
