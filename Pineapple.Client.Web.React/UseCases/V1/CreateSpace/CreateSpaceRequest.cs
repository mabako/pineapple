using System.ComponentModel.DataAnnotations;

namespace Pineapple.Client.Web.React.UseCases.V1.CreateSpace
{
    /// <summary>
    /// Request to create a space.
    /// </summary>
    public sealed class CreateSpaceRequest
    {
        /// <summary>
        /// Name of the space.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string? SpaceName { get; set; }
    }
}
