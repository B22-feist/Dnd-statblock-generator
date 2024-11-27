//using dbStuff;

using System.Data;
using MainFunction.Database;
using MainFunction.MathsFunctions;

//this namespace is used to display information
namespace MainFunction {
	class Program
	{
		static void Main()
		{
			DiceRoller Testing = new();
			DbConnection MainFunctionTesting = new();

			DataTable SqlOutputs = MainFunctionTesting.Dboutput("dndspells");


			foreach ( DataRow X in SqlOutputs.Rows)
			{
				foreach (var Item in X.ItemArray)
				{
					Console.WriteLine(Item);
				}
			}
		}
	}
}