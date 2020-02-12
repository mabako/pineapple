namespace Pineapple.Application.Boundaries
{
    /// <summary>
    /// Standard output port to process successful messages.
    /// </summary>
    /// <typeparam name="TOutput">The type of the standard output message, usually if the use case was executed successfully.</typeparam>
    public interface IOutputPortStandard<in TOutput>
        where TOutput : IUseCaseOutput
    {
        /// <summary>
        /// Writes a message to the standard output.
        /// </summary>
        /// <param name="output">The message to write to the standard output.</param>
        void Standard(TOutput output);
    }
}
