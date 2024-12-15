using System.Collections.Immutable;
using Org.BouncyCastle.Utilities;

namespace MainFunction.StatBlocks.DndClasses.GeneralClassMethods;

public class StatblockProfenciesClass
{
	/*stat block skills class handles proficiencies and proficiency bonus for a stat block
	 it takes an argument of background, class, race and level
	 it handles saving throws, skills, tools, weapons and armour proficiencies and languages */
	public Dictionary<string, object> ProfenciesMethod(string background, List<string> dndclass, string race, int level)
	{
		Dictionary<string, object> Proficiencies = new();
		return Proficiencies;
	}

	private Dictionary<string, int> SkillsGeneratorMethod(string background, List<string> dndclass, string race,
		int level)
	{
		ImmutableArray<string> Skills =
		[
			"acrobatics", "animal handling", "arcana", "athletics", "deception", "history", "insight", "intimidation",
			"investigation", "medicine", "nature", "perception", "performance", "persuasion", "religion",
			"sleight of hand", "stealth", "survival"
		];
		
		
	}
}