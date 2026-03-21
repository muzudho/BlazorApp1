namespace BlazorApp1.Components.Pages.Contents;

using Microsoft.AspNetCore.Components;

public partial class LIfeCycleAppleExamplePage
{


    // ========================================
    // 窓口プロパティ
    // ========================================


    /// <summary>
    ///		<pre>
    ///	アップル
    ///	
    ///		- ［期待］bool 型
    ///		- ［ヌル／空文字列／パース失敗］時： "True"
    ///		</pre>
    /// </summary>
    [Parameter]
    [SupplyParameterFromQuery(Name = "Apple")]
    public string? Apple { get; set; }

    private string Message1 { get; set; } = string.Empty;
    private string Message2 { get; set; } = string.Empty;
    private string Message3 { get; set; } = string.Empty;
    private string Message4 { get; set; } = string.Empty;
    private string Message5 { get; set; } = string.Empty;
    private string Message6 { get; set; } = string.Empty;
}
