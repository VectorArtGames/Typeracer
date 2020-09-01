using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typeracer.Core.Countdown;
using Typeracer.Core.Data;
using Typeracer.Core.Extensions;
using Typeracer.Core.Managers;
using static System.Console;

namespace Typeracer.Core.Render
{
	public struct MainRender
	{
		public static void Initialize()
		{
			CursorVisible = false;
			StartTimer.Run(5, () =>
			{
				InputManager.KeyPressed += InputManager.InputManagerOnKeyPressed;
				InputManager.Start();
				Render();
			});
		}

		// Key pressed Handler
		public static void Render()
		{
			var quote = QuoteData.Quote;
			var written = QuoteData.Written;


			for (var i = 0; i < quote.Length; i++)
			{
				lock (Out)
				{
					ForegroundColor = written.Length > i  && quote[i] == written[i] ? ConsoleColor.Green : ConsoleColor.Red;
					CursorTop = 0;
					CursorLeft = i;
					Write(quote[i]);
					ResetColor();
				}
			}



			var indexNot = written.IndexOfMatching(quote);

			lock (Out)
            {
				ResetColor();
				CursorTop = 2;
				CursorLeft = 0;
				Write(new string(' ', BufferWidth));
				ResetColor();
			}
			for (var i = 0; i < written.Length; i++)
            {
				lock (Out)
				{
					if (i >= BufferWidth) return;

					var matches = indexNot < 0 || indexNot > i;
					BackgroundColor =  matches ? ConsoleColor.Green : ConsoleColor.Red;
					ForegroundColor = matches ? ConsoleColor.Black : ConsoleColor.White;
					CursorTop = 2;
					CursorLeft = i;
					Write(written[i]);
					ResetColor();
				}
			}
		}
	}
}
