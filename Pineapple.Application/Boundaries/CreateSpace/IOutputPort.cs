namespace Pineapple.Application.Boundaries.CreateSpace
{
    /// <summary>
    /// All possible output messages when trying to create a space.
    /// </summary>
    public interface IOutputPort : IOutputPortStandard<CreateSpaceOutput>
    {
        /// <summary>
        /// The space you tried to create already exists.
        /// </summary>
        /// <param name="message">A message explaining the reason for this error.</param>
        void SpaceAlreadyExists(string message);

        /// <summary>
        /// The space you tried to create cannot be created.
        /// </summary>
        /// <param name="message">A message explaining the reason for this error.</param>
        void UnableToCreateSpace(string message);
    }
}
