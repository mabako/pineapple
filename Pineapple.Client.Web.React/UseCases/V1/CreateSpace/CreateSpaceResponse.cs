using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Pineapple.Client.Web.React.UseCases.V1.CreateSpace
{
    /// <summary>
    /// Response to the successful creation of a space.
    /// </summary>
    public sealed class CreateSpaceResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSpaceResponse"/> class.
        /// </summary>
        /// <param name="spaceName">Name of the newly created space.</param>
        public CreateSpaceResponse(string spaceName)
        {
            SpaceName = spaceName;
        }

        /// <summary>
        /// The name of the newly created space.
        /// </summary>
        [Required]
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        [SuppressMessage("ReSharper", "SA1623", Justification = "API documentation")]
        public string SpaceName { get; }
    }
}
