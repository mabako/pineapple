using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Pineapple.Client.Web.React.UseCases.V1.CreateSpace
{
    /// <summary>
    /// Request to create a space.
    /// </summary>
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public sealed class CreateSpaceRequest
    {
        /// <summary>
        /// The name of the new space.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [UsedImplicitly(ImplicitUseKindFlags.Assign)]
        [SuppressMessage("ReSharper", "SA1623", Justification = "API documentation")]
        public string? SpaceName { get; set; }
    }
}
