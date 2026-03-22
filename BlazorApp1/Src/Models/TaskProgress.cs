namespace BlazorApp1.Models;
/// <summary>
///     <pre>
/// タスクの進捗
///     </pre>
/// </summary>
public record TaskProgress : ITaskProgress
{


    // ========================================
    // プロパティ
    // ========================================


    /// <summary>
    /// 申請されているか
    /// </summary>
    private bool _isAppliying;

    /// <summary>
    /// 受理されたか
    /// </summary>
    private bool _isAccepted;

    /// <summary>
    /// 執行中か
    /// </summary>
    private bool _isItBeingExecuted;

    /// <summary>
    ///     <pre>
    /// 受理可能か
    /// 
    ///     - 受理されておらず、かつ、申請されているか
    ///     </pre>
    /// </summary>
    public bool IsAcceptable => !this._isAccepted && this._isAppliying;

    /// <summary>
    ///     <pre>
    /// 執行可能か
    /// 
    ///     - 執行中でなく、かつ、受理されているか
    ///     </pre>
    /// </summary>
    public bool IsExecutable => !this._isItBeingExecuted && this._isAccepted;


    // ========================================
    // 公開メソッド
    // ========================================


    /// <summary>
    /// 申請します
    /// </summary>
    public void Apply()
    {
        this._isAppliying = true;
    }


    /// <summary>
    /// 受理します
    /// </summary>
    public void Accept()
    {
        this._isAppliying = false;
        this._isAccepted = true;
    }


    /// <summary>
    /// 執行します
    /// </summary>
    public void Execute()
    {
        this._isAccepted = false;
        this._isItBeingExecuted = true;
    }


    /// <summary>
    /// 完了します
    /// </summary>
    public void Complete()
    {
        this._isItBeingExecuted = false;
    }
}
