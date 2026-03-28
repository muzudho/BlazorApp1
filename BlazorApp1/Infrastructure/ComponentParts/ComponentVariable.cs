namespace BlazorApp1.Infrastructure.ComponentParts;

using System.Threading.Tasks;

public class ComponentVariable<S, R>
{


    // ========================================
    // 生成／破棄
    // ========================================


    public ComponentVariable(R result)
    {
        this.Default = result;
        this.Result = result;
    }


    // ========================================
    // 窓口プロパティ
    // ========================================


    ///// <summary>
    ///// 未使用？
    ///// </summary>
    //public S Source { get; set; }

    /// <summary>
    ///     <pre>
    /// 前回の値
    /// 
    ///     - 初期値はヌルです
    ///     </pre>
    /// </summary>
    public S? LastSource => this._lastSource;
    protected S? _lastSource;

    public R Default { get; set; }

    public R Result { get; set; }

    /// <summary>
    ///     <pre>
    /// 前回の値
    /// 
    ///     - 初期値はヌルです
    ///     </pre>
    /// </summary>
    public R? LastResult => this._lastResult;
    protected R? _lastResult;


    // ========================================
    // 窓口メソッド
    // ========================================


    // ［ソース変更時］


    /// <summary>
    ///     <pre>
    /// 同期版
    ///     </pre>
    /// </summary>
    /// <param name="copySource"></param>
    /// <param name="convertToResult"></param>
    /// <param name="onReport"></param>
    public void ReviewSourceChanges(
        Func<S> copySource,
        Func<S, R> convertToResult,
        Action<S?, S>? onReport = null)
    {
        var oldValue = this._lastSource;
        var newValue = copySource();        // 値渡し

        // a != b
        if (!EqualityComparer<S>.Default.Equals(this._lastSource, newValue))
        {
            this._lastSource = copySource();    // 値渡し
            this.SetResultFromSource(
                source: newValue,
                convertToResult: convertToResult);
        }

        onReport?.Invoke(oldValue, newValue);
    }


    /// <summary>
    ///     <pre>
    /// 非同期版
    ///     </pre>
    /// </summary>
    /// <param name="copySource"></param>
    /// <param name="convertToResult"></param>
    /// <param name="onReport"></param>
    /// <param name="onUnchanged"></param>
    public async Task ReviewSourceChanges(
        Func<Task<S>> copySource,
        Func<S, Task<R>> convertToResult,
        Func<S?, S, Task>? onReport = null)
    {
        var oldValue = this._lastSource;
        var newValue = await copySource();      // 値渡し

        // a != b
        if (!EqualityComparer<S>.Default.Equals(this._lastSource, newValue))
        {
            this._lastSource = await copySource();      // 値渡し
            await this.SetResultFromSource(
                source: newValue,
                convertToResult: convertToResult);
        }

        if (onReport != null)
        {
            await onReport(oldValue, newValue);
        }
    }


    public virtual void SetResultFromSource(
        S source,
        Func<S, R> convertToResult)
    {
        this.Result = convertToResult(source);
    }


    public virtual async Task SetResultFromSource(
        S source,
        Func<S, Task<R>> convertToResult)
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
    /// <param name="onReport"></param>
    public void ReviewResultChanges(
        Func<R> copyResult,
        Action<R, R>? onReport = null)
    {
        var oldResult = this._lastResult;
        var newResult = copyResult();       // 値渡し

        // a != b
        if (!EqualityComparer<R>.Default.Equals(this._lastResult, newResult))
        {
            this._lastResult = copyResult();       // 値渡し
            this.Accept(
                copyResult: copyResult);
        }

        onReport?.Invoke(oldResult, newResult);
    }


    /// <summary>
    ///     <pre>
    /// 非同期版
    ///     </pre>
    /// </summary>
    /// <param name="copyResult"></param>
    /// <param name="onChanged"></param>
    /// <param name="onUnchanged"></param>
    public async Task ReviewResultChanges(
        Func<Task<R>> copyResult,
        Func<R, R, Task>? onChanged = null,
        Func<Task>? onUnchanged = null)
    {
        var oldResult = this._lastResult;
        var newResult = await copyResult();     // 値渡し

        // a != b
        if (!EqualityComparer<R>.Default.Equals(this._lastResult, newResult))
        {
            this._lastResult = await copyResult();     // 値渡し
            await this.Accept(
                copyResult: copyResult);
        }

        if (onChanged != null)
        {
            await onChanged(oldResult, newResult);
        }
    }


    /// <summary>
    ///     <pre>
    /// 値の確定。
    /// 
    ///     - 同期版。
    ///     </pre>
    /// </summary>
    /// <param name="copyResult"></param>
    public virtual void Accept(
        Func<R> copyResult)
    {
        this.Result = copyResult();
    }


    /// <summary>
    ///     <pre>
    /// 値の確定。
    /// 
    ///     - 非同期版。
    ///     </pre>
    /// </summary>
    /// <param name="copyResult"></param>
    /// <returns></returns>
    public virtual async Task Accept(
        Func<Task<R>> copyResult)
    {
        this.Result = await copyResult();
    }
}
