namespace Pineapple.Client.Web.React.UseCases.V1.CreatePage
{
    /// <summary>
    /// Response to a successful creation of a page.
    /// </summary>
    public sealed class CreatePageResponse
    {
        public CreatePageResponse(string spaceName, string pageName)
        {
            SpaceName = spaceName;
            PageName = pageName;
        }

        public string SpaceName { get; }
        public string PageName { get; }
    }
}
