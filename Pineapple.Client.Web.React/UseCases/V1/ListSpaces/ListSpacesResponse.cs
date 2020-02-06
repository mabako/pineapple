using System.Collections.Generic;

namespace Pineapple.Client.Web.React.UseCases.V1.ListSpaces
{
    /// <summary>
    /// Response containing all space names.
    /// </summary>
    public sealed class ListSpacesResponse
    {
        public ListSpacesResponse(IReadOnlyList<string> spaces)
        {
            Spaces = spaces;
        }

        public IReadOnlyList<string> Spaces { get; }
    }
}
