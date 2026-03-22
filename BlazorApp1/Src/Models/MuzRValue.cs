namespace BlazorApp1.Models;

/// <summary>
///     <pre>
/// ［Bad Know-how/Good wrapper > Collection］　果物の選択。
///
///     - 代入の右辺値（Right-hand side value）。
///     </pre>
/// </summary>
public class MuzRValue<T>
{
    public MuzRValue(T? value)
    {
        this.Value = value;
    }


    public T? Value { get; init; }
}
