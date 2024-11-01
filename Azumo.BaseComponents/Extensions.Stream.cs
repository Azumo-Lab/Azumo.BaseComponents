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
using System.IO;
using System.Runtime.InteropServices;

namespace System
{
    public static partial class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        private const int INT_SIZE = sizeof(int);

        /// <summary>
        /// 
        /// </summary>
        private const int LONG_SIZE = sizeof(long);

        /// <summary>
        /// 
        /// </summary>
        private const int BOOL_SIZE = sizeof(bool);

        /// <summary>
        /// 
        /// </summary>
        private const int FLOAT_SIZE = sizeof(float);

        /// <summary>
        /// 
        /// </summary>
        private const int DOUBLE_SIZE = sizeof(double);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static int ReadInt(this Stream stream)
        {
            return BitConverter.ToInt32(ReadBytes(stream, INT_SIZE));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static long ReadLong(this Stream stream)
        {
            return BitConverter.ToInt64(ReadBytes(stream, sizeof(long)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static bool ReadBool(this Stream stream)
        {
            return BitConverter.ToBoolean(ReadBytes(stream, sizeof(bool)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static float ReadFloat(this Stream stream)
        {
            return BitConverter.ToSingle(ReadBytes(stream, sizeof(float)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static double ReadDouble(this Stream stream)
        {
            return BitConverter.ToDouble(ReadBytes(stream, sizeof(double)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        public static void WriteInt(this Stream stream, int value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, INT_SIZE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        public static void WriteLong(this Stream stream, long value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, LONG_SIZE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        public static void WriteBool(this Stream stream, bool value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, BOOL_SIZE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        public static void WriteFloat(this Stream stream, float value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, FLOAT_SIZE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        public static void WriteDouble(this Stream stream, double value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, DOUBLE_SIZE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        public static void WriteBytes(this Stream stream, byte[] buffer)
        {
            stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static byte[] ReadBytes(this Stream stream, int size)
        {
            byte[] buffer = new byte[size];
            int readSize = stream.Read(buffer, 0, size);
            return readSize != size ? throw new Exception("Failed to read bytes from stream") : buffer;
        }
    }
}
