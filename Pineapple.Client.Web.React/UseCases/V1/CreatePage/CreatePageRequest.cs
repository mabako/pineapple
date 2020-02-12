using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Pineapple.Client.Web.React.UseCases.V1.CreatePage
{
    /// <summary>
    /// Request to create a page.
    /// </summary>
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public sealed class CreatePageRequest
    {
        /// <summary>
        /// The initial content of the new page.
        /// </summary>
        [Required]
        [UsedImplicitly(ImplicitUseKindFlags.Assign)]
        [SuppressMessage("ReSharper", "SA1623", Justification = "API documentation")]
        public string Content { get; set; } = string.Empty;
    }
}
