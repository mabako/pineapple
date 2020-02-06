using System.ComponentModel.DataAnnotations;

namespace Pineapple.Client.Web.React.UseCases.V1.CreateSpace
{
    /// <summary>
    /// Response to the successful creation of a space.
    /// </summary>
    public sealed class CreateSpaceResponse
    {
        public CreateSpaceResponse(string spaceName)
        {
            SpaceName = spaceName;
        }

        [Required]
        public string SpaceName { get; }
    }
}
