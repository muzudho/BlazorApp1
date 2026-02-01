namespace BlazorApp1.Models;

public static class FruitsTaskTicketsHelper
{
    public static int Size => (int)FruitsTaskTickets.Num;

    private static readonly FruitsTaskTickets[] mainArray =
        new []{
            FruitsTaskTickets.Apple,
            FruitsTaskTickets.Banana,
            FruitsTaskTickets.Cherry
        };


    public static void ForeachOfMain(
        Action<FruitsTaskTickets> onEach)
    {
        foreach(var item in mainArray)
        {
            onEach(item);
        }
    }


    public static async Task ForeachOfMain(
        Func<FruitsTaskTickets, Task> onEach)
    {
        foreach (var item in mainArray)
        {
            await onEach(item);
        }
    }
}


public static class FruitsTaskTicketsExtension
{
    public static int AsInt(this FruitsTaskTickets source)
    {
        return (int)source;
    }
}

public enum FruitsTaskTickets
{
    None,

    Apple,

    Banana,

    Cherry,

    /// <summary>
    /// None を含む要素数
    /// </summary>
    Num,
}
