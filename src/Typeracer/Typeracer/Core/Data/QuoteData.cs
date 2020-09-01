using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typeracer.Core.Data
{
	public struct QuoteData
	{
		public static string Quote { get; } 
			= "Hello, my name is Rek'Sai";

		public static string Written { get; set; } 
			= string.Empty;

		public static int CurrentIndex;
	}
}
