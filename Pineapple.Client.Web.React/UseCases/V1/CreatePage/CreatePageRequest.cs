using System.ComponentModel.DataAnnotations;

namespace Pineapple.Client.Web.React.UseCases.V1.CreatePage
{
    /// <summary>
    /// Request to create a page.
    /// </summary>
    public sealed class CreatePageRequest
    {
        /// <summary>
        /// Content of the new page.
        /// </summary>
        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
