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
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
using System.Collections.Generic;
using System.IO;

namespace System
#pragma warning restore IDE0130 // 命名空间与文件夹结构不匹配
{
    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 如果一个对象为null，则抛出异常
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="paramName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ThrowIfNull(this object obj, string paramName)
        {
            if (obj == null)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// 如果一个字符串为null或者空，则抛出异常
        /// </summary>
        /// <param name="str"></param>
        /// <param name="paramName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ThrowIfNullOrEmpty(this string str, string paramName)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// 如果一个 <see cref="List{T}"/> 为null或者不包含任何元素，则抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="paramName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ThrowIfNullOrEmpty<T>(this List<T> list, string paramName)
        {
            if(list == null || list.Count == 0)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// 将一个字符串转换成FileInfo对象
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static FileInfo ToFileInfo(this string path)
        {
            return new FileInfo(path);
        }

        /// <summary>
        /// 将一个字符串路径转换为DirectoryInfo对象
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DirectoryInfo ToDirectoryInfo(this string path)
        {
            return new DirectoryInfo(path);
        }
    }
}
