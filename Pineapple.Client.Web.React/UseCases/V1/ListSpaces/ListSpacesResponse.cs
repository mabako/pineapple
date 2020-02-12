using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Pineapple.Client.Web.React.UseCases.V1.ListSpaces
{
    /// <summary>
    /// Response containing all space names.
    /// </summary>
    public sealed class ListSpacesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListSpacesResponse"/> class.
        /// </summary>
        /// <param name="spaces">A collection of all space names that currently exist.</param>
        public ListSpacesResponse(IReadOnlyList<string> spaces)
        {
            Spaces = spaces;
        }

        /// <summary>
        /// Names of all currently existing spaces.
        /// </summary>
        [Required]
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        [SuppressMessage("ReSharper", "SA1623", Justification = "API documentation")]
        public IReadOnlyList<string> Spaces { get; }
    }
}
