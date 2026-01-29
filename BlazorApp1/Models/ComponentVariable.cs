namespace BlazorApp1.Models;

using System.Threading.Tasks;

public class ComponentVariable<S, R>
{


    // ========================================
    // プロパティ
    // ========================================


    public S? Source { get; set; }

    public S? LastSource => this._lastSource;
    protected S? _lastSource;

    public R? Result { get; set; }

    public R? LastResult => this._lastResult;
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
    /// <param name="onProcessed"></param>
    public void ApplyChangedSource(
        Func<S?> copySource,
        Func<S?, R?> convertToResult,
        Action<S?, S?>? onProcessed = null)
    {
        var oldValue = this._lastSource;
        var newValue = copySource();

        // a != b
        if (!EqualityComparer<S?>.Default.Equals(this._lastSource, newValue))
        {
            this._lastSource = newValue;
            this.SetResultFromSource(
                source: newValue,
                convertToResult: convertToResult);
        }

        onProcessed?.Invoke(oldValue, newValue);
    }


    /// <summary>
    ///     <pre>
    /// 非同期版
    ///     </pre>
    /// </summary>
    /// <param name="copySource"></param>
    /// <param name="convertToResult"></param>
    /// <param name="onProcessed"></param>
    /// <param name="onUnchanged"></param>
    public async Task ApplyChangedSource(
        Func<S?> copySource,
        Func<S?, Task<R?>> convertToResult,
        Func<S?, S?, Task>? onProcessed = null)
    {
        var oldValue = this._lastSource;
        var newValue = copySource();

        // a != b
        if (!EqualityComparer<S?>.Default.Equals(this._lastSource, newValue))
        {
            this._lastSource = newValue;
            await this.SetResultFromSource(
                source: newValue,
                convertToResult: convertToResult);
        }

        if (onProcessed != null)
        {
            await onProcessed(oldValue, newValue);
        }
    }


    public virtual void SetResultFromSource(
        S? source,
        Func<S?, R?> convertToResult)
    {
        this.Result = convertToResult(source);
    }


    public virtual async Task SetResultFromSource(
        S? source,
        Func<S?, Task<R?>> convertToResult)
    {
        this.Result = await convertToResult(source);
    }


    // ［リザルト変更時］


    /// <summary>
    ///     <pre>
    /// 同期版
    ///     </pre>
    /// </summary>
    /// <param name="copyResult"></param>
    /// <param name="onProcessed"></param>
    public void ApplyChangedResult(
        Func<R?> copyResult,
        Action<R?, R?>? onProcessed = null)
    {
        var oldResult = this._lastResult;
        var newResult = copyResult();

        // a != b
        if (!EqualityComparer<R?>.Default.Equals(this._lastResult, newResult))
        {
            this._lastResult = newResult;
            this.SetResult(
                copyResult: copyResult);
        }

        onProcessed?.Invoke(oldResult, newResult);
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
        Func<Task<R?>> copyResult,
        Func<R?, R?, Task>? onChanged = null,
        Func<Task>? onUnchanged = null)
    {
        var oldResult = this._lastResult;
        var newResult = await copyResult();

        // a != b
        if (!EqualityComparer<R?>.Default.Equals(this._lastResult, newResult))
        {
            this._lastResult = newResult;
            await this.SetResult(
                copyResult: copyResult);
        }

        if (onChanged != null)
        {
            await onChanged(oldResult, newResult);
        }
    }


    public virtual void SetResult(
        Func<R?> copyResult)
    {
        this.Result = copyResult();
    }


    public virtual async Task SetResult(
        Func<Task<R?>> copyResult)
    {
        this.Result = await copyResult();
    }
}
