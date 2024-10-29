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
    /// <param name="input"></param>
    /// <returns></returns>
    public delegate Task PipelineDelegate<T>(T input) where T : IPipelineResult;
}
