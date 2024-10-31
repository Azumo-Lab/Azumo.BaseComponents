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
using System.Threading.Tasks;

namespace Azumo.BaseComponents.PipelineModules
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Pipeline<T> : IPipeline<T>
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
