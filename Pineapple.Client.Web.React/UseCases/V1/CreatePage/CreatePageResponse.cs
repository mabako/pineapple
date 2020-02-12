using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Pineapple.Client.Web.React.UseCases.V1.CreatePage
{
    /// <summary>
    /// Response to a successful creation of a page.
    /// </summary>
    public sealed class CreatePageResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePageResponse"/> class.
        /// </summary>
        /// <param name="spaceName">Name of the space the new page is located in.</param>
        /// <param name="pageName">Name of the newly created page.</param>
        public CreatePageResponse(string spaceName, string pageName)
        {
            SpaceName = spaceName;
            PageName = pageName;
        }

        /// <summary>
        /// The name of the space the new page is located in.
        /// </summary>
        [Required]
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        [SuppressMessage("ReSharper", "SA1623", Justification = "API documentation")]
        public string SpaceName { get; }

        /// <summary>
        /// The name of the newly created page.
        /// </summary>
        [Required]
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        [SuppressMessage("ReSharper", "SA1623", Justification = "API documentation")]
        public string PageName { get; }
    }
}
