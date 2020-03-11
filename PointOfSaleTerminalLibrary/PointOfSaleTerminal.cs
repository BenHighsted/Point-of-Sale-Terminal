using System;

namespace PointOfSaleTerminalLibrary
{
	public class PointOfSaleTerminal
	{
		public int[] numberOfProducts = new int[4];
		public decimal[] valueOfProducts = new decimal[4];

		public const int aDiscountQuantity = 3;
		public const int cDiscountQuantity = 5;

		public const decimal aDiscountAmount = 0.75M;
		public const decimal cDiscountAmount = 1.00M;

		public void SetPricing(decimal A, decimal B, decimal C, decimal D)
		{
			valueOfProducts[0] = A;
			valueOfProducts[1] = B;
			valueOfProducts[2] = C;
			valueOfProducts[3] = D;
		}

		public void ScanProduct(String itemScanned)
		{
			if (itemScanned.Equals("A"))
				numberOfProducts[0]++;
			else if (itemScanned.Equals("B"))
				numberOfProducts[1]++;
			else if (itemScanned.Equals("C"))
				numberOfProducts[2]++;
			else if (itemScanned.Equals("D"))
				numberOfProducts[3]++;
			else
				Console.WriteLine(itemScanned + " is an invalid input so will not be counted towards your total.");
		}

		public decimal CalculateTotal()
		{
			decimal total = 0.0M;
			Boolean discounts = true;

			for (int i = 0; i < numberOfProducts.Length; i++)
			{
				total += valueOfProducts[i] * numberOfProducts[i];
			}
			while (discounts) 
			{
				if (numberOfProducts[0] >= aDiscountQuantity)
				{
					total -= aDiscountAmount;
					numberOfProducts[0] -= aDiscountQuantity;
				}
				else if (numberOfProducts[2] >= cDiscountQuantity)
				{
					total -= cDiscountAmount;
					numberOfProducts[2] -= cDiscountQuantity;
				}
				else
					discounts = false;
			}
			return total;
		}

	}
	public class App
	{

		public decimal returnValue = 0; //Used for unit testing

		public void ScanItems(String input)
		{
			String[] inputs = input.Split(',');

			PointOfSaleTerminal terminal = new PointOfSaleTerminal();
			terminal.SetPricing(1.25M, 4.25M, 1.00M, 0.75M);
			foreach (string v in inputs)
			{
				terminal.ScanProduct(v);
			}
			decimal result = terminal.CalculateTotal();

			returnValue = result;

			//Console.WriteLine(input + " totals to: $" + result);
		}

		public decimal ReturnResult()
        {
			return returnValue;
        }
	}
}