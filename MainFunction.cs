//using dbStuff;
using System.Data;
using MainFunction.Database;
using MainFunction.MathsFunctions;
using MainFunction.StatBlocks.DndClasses.GeneralClassMethods;

//this namespace is used to display information
namespace MainFunction;

class Program
{
	static void Main()
	{
		StatblockProfenciesClass Testing = new();

		List<string> Classes = ["bard"];

		List<int> levels = [3];

		Dictionary<string, int> OutPut = Testing.SkillsGeneratorMethod("acolyte ", Classes, "half orc", levels, false);

		foreach (KeyValuePair<string, int> Skill in OutPut)
		{
			Console.WriteLine(Skill);
		}
	}
}