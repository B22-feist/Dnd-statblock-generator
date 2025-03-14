//using dbStuff;
using System.Collections;
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
		StatblockProficienciesClass Testing = new();

		List<string> Classes = ["barbarian", "wizard"];

		List<int> Levels = [4,6];
		
		StatblockProficienciesClass TestingProficiencies = new();
		
		Feats Feats = new()
		{
			Linguist = false,
		};
		
		TestingProficiencies.ProficienciesMethod("sage", Classes, "elf", Levels, Feats);
		Console.WriteLine("testing");
	}
}