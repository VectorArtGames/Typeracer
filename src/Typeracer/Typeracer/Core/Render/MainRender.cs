using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typeracer.Core.Countdown;
using Typeracer.Core.Data;
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
			var index = QuoteData.CurrentIndex;
			for (var i = 0; i < quote.Length; i++)
			{
				lock (Out)
				{
					ForegroundColor = index > i ? ConsoleColor.Green : ConsoleColor.Red;
					CursorTop = 0;
					CursorLeft = i;
					Write(quote[i]);
				}
			}
		}
	}
}
