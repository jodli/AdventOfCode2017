using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
	{
		var input = @"4	1	15	12	0	9	9	5	5	8	7	3	14	5	12	3";
		
		var memoryBanks = new List<int>();
		foreach (var bank in input.Split('\t'))
		{
			memoryBanks.Add(int.Parse(bank));
		}
		Console.WriteLine($"{string.Join(" | ", memoryBanks)}");
		
		var savedBlockage = new HashSet<string>();
		savedBlockage.Add(string.Join(" ", memoryBanks));
		var cycles = 0;

		while (true)
		{
			cycles++;
			
			var maxIndex = 0;
			var cycleMax = 0;
			for (var i = 0; i < memoryBanks.Count(); i++)
			{
				if (memoryBanks[i] > cycleMax)
				{
					cycleMax = memoryBanks[i];
					maxIndex = i;
				}
			}
			//Console.WriteLine($"The maximum for this cycle is {cycleMax} on bank {maxIndex}");
			
			memoryBanks[maxIndex] = 0;
			
			for (var i = 0; i < cycleMax; i++)
			{
				maxIndex = (maxIndex + 1) % memoryBanks.Count();
				memoryBanks[maxIndex]++;
				//Console.WriteLine($"Current bank {maxIndex} = {memoryBanks[maxIndex]}");
			}

			//Console.WriteLine($"{string.Join(" | ", memoryBanks)}");
			
			if (!savedBlockage.Add(string.Join(" ", memoryBanks)))
			{
				Console.WriteLine($"Blockage found.");
				break;
			}
		}
		Console.WriteLine($"{cycles} cycles until infinite loop.");
	}
}
