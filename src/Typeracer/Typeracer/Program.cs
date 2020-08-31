using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Typeracer.Core.Render;

namespace Typeracer
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Task.Run(MainRender.Initialize);
			Thread.Sleep(-1);
		}
	}
}
