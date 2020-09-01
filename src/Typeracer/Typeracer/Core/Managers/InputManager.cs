using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Typeracer.Core.Data;
using Typeracer.Core.Render;

namespace Typeracer.Core.Managers
{
	public struct InputManager
	{
		public static event EventHandler<ConsoleKeyInfo> KeyPressed;

		public static void Start()
		{
			new Thread(ScanInputs)
			{
				IsBackground = true,
			}.Start();
		}

		private static void ScanInputs()
		{
			while (true)
			{
				CallKeyPress(Console.ReadKey(true));
			}
		}

		public static void InputManagerOnKeyPressed(object sender, ConsoleKeyInfo e)
		{
			var data = QuoteData.Written;
            switch (e.Key)
            {
                case ConsoleKey.Backspace:
					if (data.Length <= 0) break;
                    QuoteData.Written = data.Remove(data.Length - 1);
                    break;
                default:
                    QuoteData.Written += e.KeyChar;
                    break;
            }

            // Refresh Render
            MainRender.Render();
		}

		private static void CallKeyPress(ConsoleKeyInfo key) =>
            KeyPressed?.Invoke(null, key);
	}
}
