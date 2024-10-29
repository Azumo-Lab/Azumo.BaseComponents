using System.Threading.Tasks;

namespace Azumo.BaseComponents.PipelineModules
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPipeline<T> where T : IPipelineResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task ExecuteAsync(T input);
    }
}
