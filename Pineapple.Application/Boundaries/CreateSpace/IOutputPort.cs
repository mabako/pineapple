namespace Pineapple.Application.Boundaries.CreateSpace
{
    public interface IOutputPort : IOutputPortStandard<CreateSpaceOutput>
    {
        /// <summary>
        /// The space you tried to create already exists.
        /// </summary>
        /// <param name="message">custom message</param>
        void SpaceAlreadyExists(string message);

        /// <summary>
        /// The space you tried to create cannot be created.
        /// </summary>
        /// <param name="message">custom message</param>
        void UnableToCreateSpace(string message);
    }
}
