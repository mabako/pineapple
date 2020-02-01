using System.ComponentModel.DataAnnotations;

namespace Pineapple.React.UseCases.V1.CreateSpace
{
    /// <summary>
    /// Request to create a space.
    /// </summary>
    public sealed class CreateSpaceRequest
    {
        /// <summary>
        /// Name of the space.
        /// </summary>
        [Required]
        public string SpaceName { get; set; }
    }
}
