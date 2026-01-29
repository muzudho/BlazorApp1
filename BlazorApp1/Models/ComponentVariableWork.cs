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
        this.Work = result;
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
        Action<R?, R?>? onChanged = null,
        Action? onUnchanged = null)
    {
        var oldValue = this._lastResult;
        var newValue = copyWork();

        // a != b
        if (!EqualityComparer<R?>.Default.Equals(this._lastResult, newValue))
        {
            this._lastResult = newValue;
            this.SetResult(
                copyResult: copyWork);
        }

        onChanged?.Invoke(oldValue, newValue);
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
        Func<Task<R?>> copyWork,
        Func<R?, R?, Task>? onChanged = null,
        Func<Task>? onUnchanged = null)
    {
        var oldValue = this._lastResult;
        var newValue = await copyWork();

        // a != b
        if (!EqualityComparer<R?>.Default.Equals(this._lastResult, newValue))
        {
            this._lastResult = newValue;
            await this.SetResult(
                copyResult: copyWork);
        }

        if (onChanged != null)
        {
            await onChanged(oldValue, newValue);
        }
    }


    public override void SetResult(
        Func<R?> copyResult)
    {
        this.Work = copyResult();         // コピー渡し
        this.Result = copyResult();       // コピー渡し
    }


    public override async Task SetResult(
        Func<Task<R?>> copyResult)
    {
        this.Work = await copyResult();         // コピー渡し
        this.Result = await copyResult();       // コピー渡し
    }
}
