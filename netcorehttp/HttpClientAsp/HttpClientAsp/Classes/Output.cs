using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientAsp.Classes
{
	public class Output
	{
		public decimal SumResult { get; set; }
		public int MulResult { get; set; }
		public decimal[] SortedInputs { get; set; }

		public bool IsEqual(Output equal)
		{
			return
				SumResult == equal.SumResult
				&& MulResult == equal.MulResult
				&& SortedInputs.Equals(equal.SortedInputs);
		}
	}
}
