namespace Pineapple.Application.Boundaries.CreatePage
{
    /// <summary>
    /// All possible output messages when trying to create a page.
    /// </summary>
    public interface IOutputPort : IOutputPortStandard<CreatePageOutput>
    {
        /// <summary>
        /// The parent space for the created page does not exist.
        /// </summary>
        /// <param name="message">A message explaining the reason for this error.</param>
        void SpaceNotFound(string message);

        /// <summary>
        /// The page you tried to create already exists.
        /// </summary>
        /// <param name="message">A message explaining the reason for this error.</param>
        void PageAlreadyExists(string message);

        /// <summary>
        /// The page you tried to create cannot be created.
        /// </summary>
        /// <param name="message">A message explaining the reason for this error.</param>
        void UnableToCreatePage(string message);
    }
}
