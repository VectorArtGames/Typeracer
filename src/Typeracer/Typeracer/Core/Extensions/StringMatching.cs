using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typeracer.Core.Extensions
{
	public static class StringMatching
	{
		public static int IndexOfMatching(this string left, string right)
		{
			var index = -1;
			for (var i = 0; i < left.Length; i++)
			{
				if (i > right.Length) break;

				// Check if left char matches right char
				var state = left[i] != right[i];

				if (state)
					return i;
			}

			return index;
		}
	}
}
