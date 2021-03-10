namespace Interfaces
{
    /// <summary>
    /// An interface representing a behavior allowing for an injection 
    /// </summary>
    /// <typeparam name="T">T a class type being injected</typeparam>
    public interface IInjectifiable<T> where T : class
    {
        /// <summary>
        /// Method of injectifying relevant data
        /// </summary>
        /// <param name="injection"> The object requesting an injectification</param>
        void Inject(T injection);
    }
}