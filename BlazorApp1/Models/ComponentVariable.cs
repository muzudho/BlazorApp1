namespace BlazorApp1.Models;

using System.Threading.Tasks;

public class ComponentVariable<S, R>
{


    // ========================================
    // プロパティ
    // ========================================


    public S? Source { get; set; }

    protected S? _lastSource;

    public R? Result { get; set; }

    protected R? _lastResult;


    // ========================================
    // 生成／破棄
    // ========================================


    public ComponentVariable(R? result)
    {
        this.Result = result;
    }


    // ========================================
    // 公開メソッド
    // ========================================


    // ［ソース変更時］


    /// <summary>
    ///     <pre>
    /// 同期版
    ///     </pre>
    /// </summary>
    /// <param name="copySource"></param>
    /// <param name="convertToResult"></param>
    /// <param name="onChanged"></param>
    /// <param name="onUnchanged"></param>
    public void ApplyChangedSource(
        Func<S?> copySource,
        Func<S?, R?> convertToResult,
        Action<S?>? onChanged,
        Action? onUnchanged)
    {
        var copiedSource = copySource();

        // a == b
        if (EqualityComparer<S?>.Default.Equals(this._lastSource, copiedSource))
        {
            onUnchanged?.Invoke();
            return;
        }

        // a != b
        this._lastSource = copiedSource;
        this.SetResultFromSource(
            source: copiedSource,
            convertToResult: convertToResult);

        onChanged?.Invoke(copySource());
    }


    /// <summary>
    ///     <pre>
    /// 非同期版
    ///     </pre>
    /// </summary>
    /// <param name="copySource"></param>
    /// <param name="convertToResult"></param>
    /// <param name="onChanged"></param>
    /// <param name="onUnchanged"></param>
    public async Task ApplyChangedSource(
        Func<S?> copySource,
        Func<S?, R?> convertToResult,
        Func<S?, Task>? onChanged,
        Func<Task>? onUnchanged)
    {
        var copiedSource = copySource();

        // a == b
        if (EqualityComparer<S?>.Default.Equals(this._lastSource, copiedSource))
        {
            onUnchanged?.Invoke();
            return;
        }

        // a != b
        this._lastSource = copiedSource;
        this.SetResultFromSource(
            source: copiedSource,
            convertToResult: convertToResult);

        if (onChanged != null)
        {
            await onChanged(copySource());
        }
    }


    public virtual void SetResultFromSource(
        S? source,
        Func<S?, R?> convertToResult)
    {
        this.Result = convertToResult(source);
    }


    // ［リザルト変更時］


    /// <summary>
    ///     <pre>
    /// 同期版
    ///     </pre>
    /// </summary>
    /// <param name="copyResult"></param>
    /// <param name="onChanged"></param>
    /// <param name="onUnchanged"></param>
    public void ApplyChangedResult(
        Func<R?> copyResult,
        Action<R?>? onChanged,
        Action? onUnchanged)
    {
        var copiedResult = copyResult();

        // a == b
        if (EqualityComparer<R?>.Default.Equals(this._lastResult, copiedResult))
        {
            onUnchanged?.Invoke();
            return;
        }

        // a != b
        this._lastResult = copiedResult;
        this.SetResult(
            copyResult: copyResult);

        onChanged?.Invoke(copyResult());
    }


    /// <summary>
    ///     <pre>
    /// 非同期版
    ///     </pre>
    /// </summary>
    /// <param name="copyResult"></param>
    /// <param name="onChanged"></param>
    /// <param name="onUnchanged"></param>
    public async Task ApplyChangedResult(
        Func<R?> copyResult,
        Func<R?, Task>? onChanged,
        Func<Task>? onUnchanged)
    {
        var copiedResult = copyResult();

        // a == b
        if (EqualityComparer<R?>.Default.Equals(this._lastResult, copiedResult))
        {
            onUnchanged?.Invoke();
            return;
        }

        // a != b
        this._lastResult = copiedResult;
        this.SetResult(
            copyResult: copyResult);

        if (onChanged != null)
        {
            await onChanged(copyResult());
        }
    }


    public virtual void SetResult(
        Func<R?> copyResult)
    {
        this.Result = copyResult();
    }
}
