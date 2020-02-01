namespace Pineapple.Application.Boundaries
{
    /// <summary>
    /// Standard output port.
    /// </summary>
    /// <typeparam name="TOutput">type of the output message.</typeparam>
    public interface IOutputPortStandard<in TOutput>
        where TOutput : IUseCaseOutput
    {
        /// <summary>
        /// Writes a message to the standard output.
        /// </summary>
        /// <param name="output">output message</param>
        void Standard(TOutput output);
    }
}
