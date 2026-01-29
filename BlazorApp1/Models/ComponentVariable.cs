namespace BlazorApp1.Models;

using System.Threading.Tasks;

public class ComponentVariable<S, R>
{


    // ========================================
    // プロパティ
    // ========================================


    public S? Source { get; set; }

    private S? _lastSource;

    public R? Result { get; set; }

    private R? _lastResult;


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


    /// <summary>
    ///     <pre>
    /// 同期版
    ///     </pre>
    /// </summary>
    /// <param name="getCopiedSource"></param>
    /// <param name="convertToResult"></param>
    /// <param name="onChanged"></param>
    /// <param name="onUnchanged"></param>
    public void ApplyChangedSource(
        Func<S?> getCopiedSource,
        Func<S?, R?> convertToResult,
        Action<S?>? onChanged,
        Action? onUnchanged)
    {
        var copiedSource = getCopiedSource();

        // a == b
        if (EqualityComparer<S?>.Default.Equals(this._lastSource, copiedSource))
        {
            onUnchanged?.Invoke();
            return;
        }

        // a != b
        this._lastSource = copiedSource;
        this.SetResult(
            source: copiedSource,
            convertToResult: convertToResult);

        onUnchanged?.Invoke();
    }


    /// <summary>
    ///     <pre>
    /// 非同期版
    ///     </pre>
    /// </summary>
    /// <param name="getCopiedSource"></param>
    /// <param name="convertToResult"></param>
    /// <param name="onChanged"></param>
    /// <param name="onUnchanged"></param>
    public async Task ApplyChangedSource(
        Func<S?> getCopiedSource,
        Func<S?, R?> convertToResult,
        Func<S?, Task>? onChanged,
        Func<Task>? onUnchanged)
    {
        var copiedSource = getCopiedSource();

        // a == b
        if (EqualityComparer<S?>.Default.Equals(this._lastSource, copiedSource))
        {
            onUnchanged?.Invoke();
            return;
        }

        // a != b
        this._lastSource = copiedSource;
        this.SetResult(
            source: copiedSource,
            convertToResult: convertToResult);

        if (onUnchanged != null)
        {
            await onUnchanged();
        }
    }


    public void SetResult(
        S? source,
        Func<S?, R?> convertToResult)
    {
        this.Result = convertToResult(source);
    }
}
