namespace Pineapple.Application.Boundaries.CreatePage
{
    public interface IOutputPort : IOutputPortStandard<CreatePageOutput>
    {
        /// <summary>
        /// The parent space for the created page does not exist.
        /// </summary>
        /// <param name="message">custom message</param>
        void SpaceNotFound(string message);

        /// <summary>
        /// The page you tried to create already exists.
        /// </summary>
        /// <param name="message">custom message</param>
        void PageAlreadyExists(string message);

        /// <summary>
        /// The page you tried to create cannot be created.
        /// </summary>
        /// <param name="message">custom message</param>
        void UnableToCreatePage(string message);
    }
}
