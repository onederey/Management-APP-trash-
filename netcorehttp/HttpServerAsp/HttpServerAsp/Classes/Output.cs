using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpServerAsp.Classes
{
	public class Output
	{
		public decimal SumResult { get; set; }
		public int MulResult { get; set; }
		public decimal[] SortedInputs { get; set; }

		public bool IsEqual(Output equal)
		{
			if (SortedInputs?.Length != equal.SortedInputs?.Length)
				return false;

			for (int i = 0; i < SortedInputs.Length; i++)
				if (SortedInputs[i] != equal.SortedInputs?[i])
					return false;

			if (SumResult != equal.SumResult || MulResult != equal.MulResult)
				return false;

			return true;
		}
	}
}
