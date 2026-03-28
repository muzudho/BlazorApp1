using BlazorApp1;
using BlazorApp1.Components;
using BlazorApp1.Infrastructure.Configuration;
using BlazorApp1.Infrastructure.Logging;
using Microsoft.Extensions.Options;

try
{
    // ホストビルドするぜ（＾～＾）！
    // ［ホスト］ってのは［汎用ホスト］のことで、いろいろ［サービス］っていう便利機能を付け加えることができるフレームワークみたいなもんだぜ（＾～＾）
    // それを［ビルド］するぜ（＾▽＾）
    await MuzInfrastructureHelper.BuildHostAsync(
        commandLineArgs: args,
        onHostEnabled: async (app) =>
        {
            // ここからビルドされた［汎用ホスト］（app）が使えるぜ（＾▽＾）！

            // ［アプリケーション設定ファイル］を動作確認してみようぜ（＾～＾）
            var appSettings = app.Services.GetRequiredService<IOptions<MuzAppSettings>>().Value;
            Console.WriteLine($"AppName: {appSettings.AppName}");

            // ［ロガー］を動作確認してみようぜ（＾～＾）
            var logger = app.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("ログを書き込むぜ～（＾～＾）！");

            // ［ロガー別のログ］を動作確認してみようぜ（＾～＾）
            var loggingSvc = app.Services.GetRequiredService<IMuzLoggingService>();
            loggingSvc.Others.LogInformation("その他のログだぜ（＾～＾）");
            loggingSvc.Verbose.LogInformation("大量のログだぜ（＾～＾）");


            // ［ウェブアプリケーションの設定］


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        });
}
catch (Exception ex)
{
    Console.WriteLine($"アプリが死んだ... ログも取れない、むずでょ泣く。{ex}");
}
finally
{
    Console.WriteLine("アプリが終了するぜ（＾～＾）！");
    await MuzInfrastructureHelper.Cleanup();
}

// Program.cs を最後まで実行しても、必ずしもアプリケーションが終了するわけじゃないぜ（＾～＾）！
// ［汎用ホスト］が動いている限りは、アプリケーションは終了しないぜ（＾～＾）！
