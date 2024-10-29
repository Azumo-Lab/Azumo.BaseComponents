using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Azumo.BaseComponents.PipelineModules
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Pipeline<T> : IPipeline<T> where T : IPipelineResult
    {
        private readonly PipelineDelegate<T> _PipelineDelegate;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_PipelineDelegate"></param>
        public Pipeline(PipelineDelegate<T> _PipelineDelegate)
        {
            this._PipelineDelegate = _PipelineDelegate;
        }

        public Task ExecuteAsync(T input)
        {
            return _PipelineDelegate.Invoke(input);
        }
    }
}
