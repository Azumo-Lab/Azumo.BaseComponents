using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azumo.BaseComponents.PipelineModules
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PipelineBuilder<T> : IPipelineBuilder<T> where T : IPipelineResult
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<IPipelineProcess<T>> _PipelineProcesses = new List<IPipelineProcess<T>>();

        /// <summary>
        /// 
        /// </summary>
        private PipelineBuilder()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IPipelineBuilder<T> Create()
        {
            return new PipelineBuilder<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IPipelineBuilder<T> AddProcess(IPipelineProcess<T> process)
        {
            _PipelineProcesses.Add(process);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IPipeline<T> BuildPipeline()
        {
            try
            {
                if (_PipelineProcesses.Count == 0)
                    throw new TypeInitializationException("PipelineBuilder", new Exception("No processes added to the pipeline"));

                PipelineDelegate<T> pipelineDelegate = (input) => Task.CompletedTask;
                List<Func<PipelineDelegate<T>, PipelineDelegate<T>>> funcs = new List<Func<PipelineDelegate<T>, PipelineDelegate<T>>>();
                foreach (IPipelineProcess<T> item in _PipelineProcesses)
                    funcs.Add((next) => async (input) => 
                    { 
                        await item.ExecuteAsync(input, next); 
                    });
                foreach (Func<PipelineDelegate<T>, PipelineDelegate<T>> item in funcs.Reverse<Func<PipelineDelegate<T>, PipelineDelegate<T>>>())
                    pipelineDelegate = item(pipelineDelegate);

                return new Pipeline<T>(pipelineDelegate);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _PipelineProcesses.Clear();
            }
        }
    }
}
