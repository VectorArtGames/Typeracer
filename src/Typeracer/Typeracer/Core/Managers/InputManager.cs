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
			// Get Quote from Data
			var data = QuoteData.Quote;

			// Protection agaisnt out of range
			if (data.Length <= QuoteData.CurrentIndex) return;
			// Get character in data[index]
			var inp = data[QuoteData.CurrentIndex];

			// Check if 'inp' matches key character
			if (e.KeyChar != inp) return;

			// Increment Index by 1
			QuoteData.CurrentIndex++;

			// Refresh Render
			MainRender.Render();
		}

		private static void CallKeyPress(ConsoleKeyInfo key) =>
			KeyPressed?.Invoke(null, key);
	}
}
