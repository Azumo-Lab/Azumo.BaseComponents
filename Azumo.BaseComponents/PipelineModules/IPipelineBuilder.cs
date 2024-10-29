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