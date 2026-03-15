namespace BlazorApp1.Src;

using BlazorApp1.Src.Infrastructure.Configuration;

/// <summary>
/// どんなコンソール・アプリを作るときでも、本題に入る前に似たようなコードを書くことになる……、そんな似たコード［ホストビルド］をまとめたヘルパークラスだぜ（＾～＾）！
/// </summary>
public class MuzInfrastructureHelper
{
    public static async Task BuildHostAsync(
        string[] commandLineArgs,
        Func</*IHost*/ WebApplication, Task> onHostEnabled)
    {
        //HostApplicationBuilder builder = Host.CreateApplicationBuilder(commandLineArgs);  // ビルダー作成（＾～＾）
        WebApplicationBuilder builder = WebApplication.CreateBuilder(commandLineArgs);  // ビルダー作成（＾～＾）


        await SetupBeforeBuildAsync(builder);    // ビルド前の処理（＾～＾）
        var host = builder.Build(); // ホストビルド（＾～＾）
        await onHostEnabled(host);  // ホストは有効になっているぜ（＾▽＾）！
    }


    /// <summary>
    /// ホストビルドする前にやることがあればここでやるぜ（＾～＾）！例えば、［サービス］を追加したりとか、そういうのだぜ（＾～＾）！
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    private static async Task SetupBeforeBuildAsync(WebApplicationBuilder builder)
    {
        // お前のアプリケーションに合わせて、［サービス］を追加していってくれだぜ（＾～＾）！
        Console.WriteLine("ホストビルドする前にやることがあればここでやるぜ（＾～＾）！例えば、［サービス］を追加したりとか、そういうのだぜ（＾～＾）！");

        MuzAppSettingsHelper.SetupBeforeHostBuild(builder);   // ［アプリケーション設定ファイル］を読み書きできるようにするための準備をするぜ（＾～＾）！

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
    }
}
