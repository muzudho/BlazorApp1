namespace BlazorApp1.Models;

/// <summary>
/// 代入の右辺値（Right-hand side value）。
/// </summary>
internal class MuzRValue<T>
{
    internal MuzRValue(T? value)
    {
        this.Value = value;
    }

    internal T? Value { get; init; }
}
