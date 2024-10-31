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
using System.Collections.Generic;
using System.Text;

#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace System
#pragma warning restore IDE0130 // 命名空间与文件夹结构不匹配
{
    /// <summary>
    /// 
    /// </summary>
    public class AzumoConsole
    {
        /// <summary>
        /// 
        /// </summary>
        public class ConsoleText
        {
            public string Text { get; set; } = string.Empty;
            public ConsoleColor? Color { get; set; } = null;
        }
        /// <summary>
        /// 
        /// </summary>
        static AzumoConsole()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string? ReadLine(string message)
        {
            Console.Write(message);
            string str = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consoleText"></param>
        public static void Write(ConsoleText[] consoleText)
        {
            bool isColor = false;
            foreach (ConsoleText item in consoleText)
            {
                if (item.Color == null)
                {
                    if (isColor)
                    {
                        Console.ResetColor();
                        isColor = false;
                    }
                }
                else
                {
                    Console.ForegroundColor = item.Color.Value;
                    isColor = true;
                }
                Console.Write(item.Text);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// 读取键盘按键
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ConsoleKeyInfo ReadKey(string message)
        {
            Console.Write(message);
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            Console.WriteLine();
            return consoleKeyInfo;
        }

        /// <summary>
        /// 菜单选择
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <param name="menuItem"></param>
        /// <returns></returns>
        public static T Menu<T>(string title, string text, List<T> menuItem)
        {
            Console.CursorVisible = false;
            int index = 0;
            int mouse = 5;

            if (!string.IsNullOrEmpty(title))
                Console.WriteLine(Space() + title);
            if (!string.IsNullOrEmpty(text))
                Console.WriteLine(Space() + text);

            // 显示菜单项目
            foreach (T item in menuItem)
                Console.WriteLine($"{Space()}[ ] {item?.ToString() ?? "NULL"}");

            // 设置光标原点
            int HZero = Console.CursorTop - menuItem.Count + index;
            int WZero = mouse + 1;
            Update();

            string Space()
            {
                string result = string.Empty;
                for (int i = 0; i < mouse; i++)
                    result += " ";
                return result;
            }

            void Clear()
            {
                // 清除上一个位置的图案
                Console.SetCursorPosition(WZero, HZero + index);
                Console.Write(" ");
            }

            void Update()
            {
                // 设置下一个位置的图案
                Console.SetCursorPosition(WZero, HZero + index);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(">");
                Console.ResetColor();
            }

            while (true)
            {
                var keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return menuItem[index];
                    case ConsoleKey.UpArrow:
                        Clear();
                        index--;
                        if (index < 0)
                            index = menuItem.Count - 1;
                        Update();
                        break;
                    case ConsoleKey.DownArrow:
                        Clear();
                        index++;
                        if (index >= menuItem.Count)
                            index = 0;
                        Update();
                        break;
                }
            }
        }
    }
}
