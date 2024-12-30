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

		List<string> Classes = ["barbarian"];

		List<int> levels = [4];

		HashSet<string> OutPut = Testing.ToolsProficienciesGenerator(Classes, "acolyte",  "elf", 0);

		foreach (string Skill in OutPut)
		{
			Console.WriteLine(Skill);
		}
	}
}