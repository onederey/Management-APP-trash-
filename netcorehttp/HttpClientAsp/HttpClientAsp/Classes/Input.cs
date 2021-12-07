using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientAsp.Classes
{
	public class Input
	{
        public int K { get; set; }
        public decimal[] Sums { get; set; }
        public int[] Muls { get; set; }

        public Output Process()
        {
            Output output = new Output();
            output.SumResult = 0;
            output.SortedInputs = new decimal[this.Muls.Length + this.Sums.Length];
            int idx = 0;
            foreach (decimal i in this.Sums)
            {
                output.SortedInputs[idx] = i;
                idx++;
                output.SumResult += i;
            }
            output.SumResult *= this.K;
            output.MulResult = 1;
            foreach (int i in this.Muls)
            {
                output.SortedInputs[idx] = i;
                idx++;
                output.MulResult *= i;
            }
            Array.Sort(output.SortedInputs);
            return output;
        }
    }
}
