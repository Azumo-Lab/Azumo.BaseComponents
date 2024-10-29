namespace Azumo.BaseComponents.PipelineModules
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPipelineBuilder<T> where T : IPipelineResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IPipeline<T> BuildPipeline();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        IPipelineBuilder<T> AddProcess(IPipelineProcess<T> process);
    }
}