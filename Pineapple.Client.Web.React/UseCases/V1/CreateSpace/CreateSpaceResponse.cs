namespace Pineapple.Client.Web.React.UseCases.V1.CreateSpace
{
    /// <summary>
    /// Response to the successful creation of a space.
    /// </summary>
    public class CreateSpaceResponse
    {
        public CreateSpaceResponse(string spaceName)
        {
            SpaceName = spaceName;
        }

        public string SpaceName { get; }
    }
}
