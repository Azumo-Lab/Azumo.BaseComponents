//-----------------------------------------------------------------------------------------------
//<Azumo.BaseComponents>
//Copyright (C) <2024>  <Azumi Lab>
//
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <https://www.gnu.org/licenses/>.
//-----------------------------------------------------------------------------------------------
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
