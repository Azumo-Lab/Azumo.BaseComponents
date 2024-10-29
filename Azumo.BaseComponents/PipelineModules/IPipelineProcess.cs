using System.Threading.Tasks;

namespace Azumo.BaseComponents.PipelineModules
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPipelineProcess<T> where T : IPipelineResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task ExecuteAsync(T input, PipelineDelegate<T> Next);
    }
}
