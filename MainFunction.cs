//using dbStuff;
using System.Data;
using MainFunction.Database;
using MainFunction.MathsFunctions;
using MainFunction.StatBlocks.DndClasses.GeneralClassMethods;

//this namespace is used to display information
namespace MainFunction {
	class Program
	{
		static void Main()
		{
			AbilityScoreClass Testing = new AbilityScoreClass();
			
			List<int> inputList = [8, 10];
			List<string> Classinput = ["bard", "rouge"];

			Dictionary<String, object> TestingDic = Testing.StatBlockGeneratorAbilityScoresModifiers(inputList, "HalfOrc", Classinput);

			foreach (var VARIABLE in TestingDic)
			{
				Console.WriteLine(VARIABLE);
			}
		}
	}
}