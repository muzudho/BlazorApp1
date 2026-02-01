namespace BlazorApp1.Models;

/// <summary>
/// タスクの進捗
/// </summary>
public record TaskProgress : ITaskProgress
{


    // ========================================
    // プロパティ
    // ========================================


    /// <summary>
    /// 申請中か
    /// </summary>
    public bool IsApplying => this._isAppliying;
    private bool _isAppliying;

    /// <summary>
    /// 受理したか
    /// </summary>
    public bool IsAccepted => this._isAccepted;
    private bool _isAccepted;

    /// <summary>
    /// 実行中か
    /// </summary>
    public bool IsUnderExecution => this._isUnderExecution;
    private bool _isUnderExecution;

    /// <summary>
    /// 完了か
    /// </summary>
    public bool IsCompleted => this._isCompleted;
    private bool _isCompleted;


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
        this._isAppliying = false;
        this._isUnderExecution = true;
    }


    /// <summary>
    /// 完了します
    /// </summary>
    public void Complete()
    {
        this._isUnderExecution = false;
        this._isCompleted = true;
    }
}
