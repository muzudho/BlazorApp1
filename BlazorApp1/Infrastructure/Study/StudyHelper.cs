namespace BlazorApp1.Infrastructure.Study;

public static class StudyHelper
{
    /// <summary>
    /// デッドロックが発生する可能性があり、バッドだが、練習のために使用するタイマー。
    /// </summary>
    public static void BadSleep(
        int seconds)
    {
        Thread.Sleep(seconds * 1000);   // ここで指定秒かかる処理をしてみる。デッドロックが発生する可能性があり、良くないが、簡単にコードを書けるので使う。
    }


    /// <summary>
    /// デッドロックが発生する可能性があり、バッドだが、練習のために使用するタイマー。
    /// </summary>
    public static void BadTimer(
        int seconds,
        Action onTicked)
    {
        for (int i=0; i<seconds; i++)
        {
            Thread.Sleep(1000);   // ここで何か１秒かかる処理をしてみる。デッドロックが発生する可能性があり、良くないが、簡単にコードを書けるので使う。
            onTicked();
        }
    }


    /// <summary>
    /// デッドロックが発生する可能性があり、バッドだが、練習のために使用するタイマー。
    /// </summary>
    public static async Task TimerAsync(
        int seconds,
        Func<Task> onTicked)
    {
        for (int i = 0; i < seconds; i++)
        {
            await Task.Delay(1000);   // ここで何か１秒かかる処理をしてみる。デッドロックが発生する可能性があり、良くないが、簡単にコードを書けるので使う。
            await onTicked();
        }
    }
}
