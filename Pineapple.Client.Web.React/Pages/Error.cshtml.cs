using System.Diagnostics;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pineapple.Client.Web.React.Pages
{
    /// <summary>
    /// Model for the error page.
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class ErrorModel : PageModel
    {
        /// <summary>
        /// Gets the current requests id.
        /// </summary>
        public string? RequestId { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the request id should be shown.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        /// <summary>
        /// Sets up the error model per request.
        /// </summary>
        [UsedImplicitly]
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
