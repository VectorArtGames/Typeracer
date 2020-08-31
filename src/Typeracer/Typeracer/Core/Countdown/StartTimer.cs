using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Typeracer.Core.Countdown
{
	public struct StartTimer
	{
		public static async void Run(int seconds, Action callback)
		{
			Clear();
			var time = seconds;
			while (time > 0)
			{
				CursorLeft = 0;
				CursorTop = 0;

				lock (Out)
				{
					CursorTop = WindowHeight / 2;
					WriteLine($"{{0,{WindowWidth / 2 + time.ToString().Length / 2}}}", time.ToString());
				}
				await Task.Delay(1000);
				time--;
			}
			Clear();

			callback?.Invoke();
		}
	}
}
