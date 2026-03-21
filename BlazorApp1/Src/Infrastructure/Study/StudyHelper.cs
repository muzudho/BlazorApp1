namespace BlazorApp1.Src.Infrastructure.Study;

public static class StudyHelper
{
    /// <summary>
    /// デッドロックが発生する可能性があり、バッドだが、練習のために使用するタイマー。
    /// </summary>
    public static void BadTimer(
        int seconds,
        Action onTime)
    {
        Thread.Sleep(seconds * 1000);   // ここで何か時間のかかる処理をしてみる。デッドロックが発生する可能性があり、良くないが、簡単にコードを書けるので使う。
        onTime();
    }
}
