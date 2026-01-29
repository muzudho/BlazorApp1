namespace BlazorApp1.Models;

public class ComponentVariableWork<S, R> : ComponentVariable<S, R>
{


    // ========================================
    // プロパティ
    // ========================================


    public R? Work { get; set; }


    // ========================================
    // 生成／破棄
    // ========================================


    public ComponentVariableWork(R? result) : base(result)
    {
    }


    // ========================================
    // 公開メソッド
    // ========================================


    // ［ソース変更時］


    public override void SetResultFromSource(
        S? source,
        Func<S?, R?> convertToResult)
    {
        this.Work = convertToResult(source);        // コピー渡し
        this.Result = convertToResult(source);      // コピー渡し
    }


    // ［ワーク変更時］

    /// <summary>
    ///     <pre>
    /// 同期版
    ///     </pre>
    /// </summary>
    /// <param name="copyWork"></param>
    /// <param name="onChanged"></param>
    /// <param name="onUnchanged"></param>
    public void ApplyChangedWork(
        Func<R?> copyWork,
        Action<R?>? onChanged,
        Action? onUnchanged)
    {
        var copiedWork = copyWork();

        // a == b
        if (EqualityComparer<R?>.Default.Equals(this._lastResult, copiedWork))
        {
            onUnchanged?.Invoke();
            return;
        }

        // a != b
        this._lastResult = copiedWork;
        this.SetWork(
            copyWork: copyWork);

        onChanged?.Invoke(copyWork());
    }


    /// <summary>
    ///     <pre>
    /// 非同期版
    ///     </pre>
    /// </summary>
    /// <param name="copyWork"></param>
    /// <param name="onChanged"></param>
    /// <param name="onUnchanged"></param>
    public async Task ApplyChangedWork(
        Func<R?> copyWork,
        Func<R?, Task>? onChanged,
        Func<Task>? onUnchanged)
    {
        var copiedWork = copyWork();

        // a == b
        if (EqualityComparer<R?>.Default.Equals(this._lastResult, copiedWork))
        {
            onUnchanged?.Invoke();
            return;
        }

        // a != b
        this._lastResult = copiedWork;
        this.SetWork(
            copyWork: copyWork);

        if (onChanged != null)
        {
            await onChanged(copyWork());
        }
    }


    public virtual void SetWork(
        Func<R?> copyWork)
    {
        this.Work = copyWork();         // コピー渡し
        this.Result = copyWork();       // コピー渡し
    }


    // ［リザルト変更時］


    public override void SetResult(
        Func<R?> copyResult)
    {
        this.Work = copyResult();       // コピー渡し
        this.Result = copyResult();     // コピー渡し
    }
}
