using System.Collections.Immutable;

namespace MainFunction.StatBlocks.DndClasses.GeneralClassMethods;

public class StatblockProfenciesClass
{
	/*stat block skills class handles proficiencies and proficiency bonus for a stat block
	 it takes an argument of background, class, race and level
	 it handles saving throws, skills, tools, weapons and armour proficiencies and languages */
	public Dictionary<string, object> ProfenciesMethod(string background, List<string> dndclass, string race, List<int> level)
	{
		Dictionary<string, object> Proficiencies = new()
		{
			{"skills", SkillsGeneratorMethod(background, dndclass, race, level) }
		};
		return Proficiencies;
	}

	private Dictionary<string, int> SkillsGeneratorMethod(string background, List<string> dndclass, string race,
		List<int> level)
	{
		ImmutableArray<string> PossibleSkills =
		[
			"acrobatics", "animal handling", "arcana", "athletics", "deception", "history", "insight", "intimidation",
			"investigation", "medicine", "nature", "perception", "performance", "persuasion", "religion",
			"sleight of hand", "stealth", "survival"
		];
		
		List<string> Skills = new();
		
		int TotalLevel = 0;

		foreach (int LevelNumbers in level)
		{
			TotalLevel += LevelNumbers;
		}
		ImmutableArray<int> ProfBonusArray = [2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6];

		int ProfBonus = ProfBonusArray[TotalLevel];
		
		Dictionary<string, int> StatblockSkillsDictionary = new();
		
		List<string> BackGroundSkillList = BackGroundSkills(background);

		foreach (string BackGroundSkillAdd in BackGroundSkillList)
		{
			Skills.Add(BackGroundSkillAdd);
		}
		
		List<string> SubraceSkillsList = SubraceSkills(race, Skills);
		
		foreach (string SubraceSkillAdd in SubraceSkillsList)
		{
			Skills.Add(SubraceSkillAdd);
		}
		
		return StatblockSkillsDictionary;
		}

	private List<string> SubraceSkills(string race, List<string> ListSkills)
	{
		List<string> SubraceSkills = new();
		ImmutableArray<string> Skills =
		[
			"acrobatics", "animal handling", "arcana", "athletics", "deception", "history", "insight", "intimidation",
			"investigation", "medicine", "nature", "perception", "performance", "persuasion", "religion",
			"sleight of hand", "stealth", "survival"
		];

		switch (race.ToLower())
		{
			case "variant human":
				foreach (string SkillsStrings in Skills)
				{
					Console.WriteLine(SkillsStrings);
				}		
				
				for (int VariantHumanSkillsCounter = 0; VariantHumanSkillsCounter < 2; VariantHumanSkillsCounter++)
				{
					Console.WriteLine("enter in a skills");
					string? UserRaceSkillsinput = Console.ReadLine();

					if (Skills.Contains(UserRaceSkillsinput?.ToLower() ?? string.Empty))
					{
						if (ListSkills.Contains(UserRaceSkillsinput!.ToLower()))
						{
							VariantHumanSkillsCounter--;
							Console.WriteLine("You already have that skill, enter another skill");
						}

						else
						{
							SubraceSkills.Add(UserRaceSkillsinput.ToLower());
						}
					}
				}
				break;
			
			case "half elf":
				foreach (string SkillsStrings in Skills)
				{
					Console.WriteLine(SkillsStrings);
				}		
				
				for (int HalfElfSkillsCounter = 0; HalfElfSkillsCounter < 2; HalfElfSkillsCounter++)
				{
					Console.WriteLine("enter in a skills");
					string? UserRaceSkillsinput = Console.ReadLine();

					if (Skills.Contains(UserRaceSkillsinput.ToLower()))
					{
						if (ListSkills.Contains(UserRaceSkillsinput!.ToLower()))
						{
							HalfElfSkillsCounter--;
							Console.WriteLine("You already have that skill, enter another skill");
						}

						else
						{
							SubraceSkills.Add(UserRaceSkillsinput.ToLower());
						}
					}
				}
				break;
			
			case "half orc":
				if (!ListSkills.Contains("intimidation"))
				{
					SubraceSkills.Add("intimidation");
				}
				break;
			
			case "elf":
				if (!ListSkills.Contains("perception"))
				{
					SubraceSkills.Add("perception");
				}
				break;
		}

		return SubraceSkills;
	}

	private List<string> BackGroundSkills(string background)
	{
		List<string> BackGroundSkills = new();

		switch (background.ToLower())
		{
			case "acolyte":
				BackGroundSkills.Add("insight");
				BackGroundSkills.Add("religion");
				break;
			
			case "charlatan":
				BackGroundSkills.Add("deception");
				BackGroundSkills.Add("sleight of hand");
				break;
			
			case "criminal":
				BackGroundSkills.Add("deception");
				BackGroundSkills.Add("stealth");
				break;
			
			case "entertainer":
				BackGroundSkills.Add("acrobatics");
				BackGroundSkills.Add("performance");
				break;
			
			case "folk hero":
				BackGroundSkills.Add("animal handling");
				BackGroundSkills.Add("survival");
				break;
			
			case "guild artisan":
				BackGroundSkills.Add("insight");
				BackGroundSkills.Add("persuasion");
				break;
			
			case "hermit":
				BackGroundSkills.Add("medicine");
				BackGroundSkills.Add("religion");
				break;
			
			case "noble":
				BackGroundSkills.Add("history");
				BackGroundSkills.Add("persuasion");
				break;
			
			case "outlander":
				BackGroundSkills.Add("athletics");
				BackGroundSkills.Add("survival");
				break;
			
			case "sage":
				BackGroundSkills.Add("arcana");
				BackGroundSkills.Add("history");
				break;
			
			case "sailor":
				BackGroundSkills.Add("athletics");
				BackGroundSkills.Add("perception");
				break;
			
			case "soldier":
				BackGroundSkills.Add("athletics");
				BackGroundSkills.Add("intimidation");
				break;
			
			case "urchin":
				BackGroundSkills.Add("sleight of hand");
				BackGroundSkills.Add("stealth");
				break;
		}

		return BackGroundSkills;
	}

	private List<string> ClassSkills(List<string> classes, List<string> ListSkills)
	{
		ImmutableArray<string> Skills =
		[
			"acrobatics", "animal handling", "arcana", "athletics", "deception", "history", "insight", "intimidation",
			"investigation", "medicine", "nature", "perception", "performance", "persuasion", "religion",
			"sleight of hand", "stealth", "survival"
		];

		List<string> ClassSkillsList = new();

		switch (classes[0].ToLower())
		{
			case "barbarian":
				ImmutableArray<string> BarbarianSkills =
				[
					"animal handling", "athletics", "intimidation", "nature", "perception", "survival"
				];

				foreach (string BarbarianSkillsPrint in BarbarianSkills)
				{
					Console.WriteLine(BarbarianSkillsPrint);
				}

				for (int BarbarianskillsCounter = 0; BarbarianskillsCounter < 4; BarbarianskillsCounter++)
				{
					string BarbarianSkillsUserInput = Console.ReadLine() ?? string.Empty;

					if (Skills.Contains(BarbarianSkillsUserInput?.ToLower() ?? string.Empty))
					{
						if (ListSkills.Contains(BarbarianSkillsUserInput.ToLower()))
						{
							BarbarianskillsCounter--;
							Console.WriteLine("You already have that skill, enter another skill");
						}

						else
						{
							ClassSkillsList.Add(BarbarianSkillsUserInput.ToLower());
						}
					}
				}

				break;

			case "bard":
				ImmutableArray<string> BardSkills =
				[
					"acrobatics", "animal handling", "arcana", "athletics", "deception", "history", "insight",
					"intimidation",
					"investigation", "medicine", "nature", "perception", "performance", "persuasion", "religion",
					"sleight of hand", "stealth", "survival"
				];

				foreach (string BardSkillsPrint in BardSkills)
				{
					Console.WriteLine(BardSkillsPrint);
				}

				for (int BardnskillsCounter = 0; BardnskillsCounter < 3; BardnskillsCounter++)
				{

					string BarbarianSkillsUserInput = Console.ReadLine() ?? string.Empty;

					if (BardSkills.Contains(BarbarianSkillsUserInput.ToLower()))
					{
						ClassSkillsList.Add(BarbarianSkillsUserInput);
					}
				}

				break;

			case "cleric":
				ImmutableArray<string> ClericSkills =
				[
					"history", "insight", "medicine", "persuasion", "religion"
				];

				foreach (string ClericSkillsPrint in ClericSkills)
				{
					Console.WriteLine(ClericSkillsPrint);
				}

				for (int ClericSkillsCounter = 0; ClericSkillsCounter < 2; ClericSkillsCounter++)
				{

					string ClericSkillsUserInput = Console.ReadLine() ?? string.Empty;

					if (ClericSkills.Contains(ClericSkillsUserInput.ToLower()))
					{
						ClassSkillsList.Add(ClericSkillsUserInput);
					}
				}

				break;

			case "druid":
				ImmutableArray<string> DruidSkills =
				[
					"arcana", "animal handling", "insight", "medicine", "nature", "perception", "religion", "survival"
				];

				foreach (string DruidSkillsPrint in DruidSkills)
				{
					Console.WriteLine(DruidSkillsPrint);
				}

				for (int DruidskillsCounter = 0; DruidskillsCounter < 2; DruidskillsCounter++)
				{

					string DruidSkillsUserInput = Console.ReadLine() ?? string.Empty;

					if (DruidSkills.Contains(DruidSkillsUserInput.ToLower()))
					{
						ClassSkillsList.Add(DruidSkillsUserInput);
					}
				}

				break;

			case "fighter":
				ImmutableArray<string> FighterSkills =
				[
					"acrobatics", "animal handling", "athletics", "history", "insight", "intimidation", "perception",
					"survival"
				];

				foreach (string FighterSkillsPrint in FighterSkills)
				{
					Console.WriteLine(FighterSkillsPrint);
				}

				for (int FighterskillsCounter = 0; FighterskillsCounter < 2; FighterskillsCounter++)
				{

					string FighterSkillsUserInput = Console.ReadLine() ?? string.Empty;

					if (FighterSkills.Contains(FighterSkillsUserInput.ToLower()))
					{
						ClassSkillsList.Add(FighterSkillsUserInput);
					}
				}

				break;

			case "monk":
				ImmutableArray<string> MonkSkills =
				[
					"acrobatics", "athletics", "history", "insight", "religion", "stealth"
				];

				foreach (string MonkSkillsPrint in MonkSkills)
				{
					Console.WriteLine(MonkSkillsPrint);
				}

				for (int MonkskillsCounter = 0; MonkskillsCounter < 4; MonkskillsCounter++)
				{

					string MonkSkillsUserInput = Console.ReadLine() ?? string.Empty;

					if (MonkSkills.Contains(MonkSkillsUserInput.ToLower()))
					{
						ClassSkillsList.Add(MonkSkillsUserInput);
					}
				}

				break;

			case "paladin":
				ImmutableArray<string> PaladinSkills =
				[
					"athletics", "insight", "intimidation", "medicine", "persuasion", "religion"
				];

				foreach (string PaladinSkillsPrint in PaladinSkills)
				{
					Console.WriteLine(PaladinSkillsPrint);
				}

				for (int PaladinskillsCounter = 0; PaladinskillsCounter < 2; PaladinskillsCounter++)
				{

					string PaladinSkillsUserInput = Console.ReadLine() ?? string.Empty;

					if (PaladinSkills.Contains(PaladinSkillsUserInput.ToLower()))
					{
						ClassSkillsList.Add(PaladinSkillsUserInput);
					}
				}

				break;

			case "ranger":
				ImmutableArray<string> RangerSkills =
				[
					"animal handling", "athletics", "insight", "investigation", "nature", "perception", "stealth",
					"survival"
				];

				foreach (string RangerSkillsPrint in RangerSkills)
				{
					Console.WriteLine(RangerSkillsPrint);
				}

				for (int RangerskillsCounter = 0; RangerskillsCounter < 3; RangerskillsCounter++)
				{

					string RangerSkillsUserInput = Console.ReadLine() ?? string.Empty;

					if (RangerSkills.Contains(RangerSkillsUserInput.ToLower()))
					{
						ClassSkillsList.Add(RangerSkillsUserInput);
					}
				}

				break;

			case "rogue":
				ImmutableArray<string> RogueSkills =
				[
					"acrobatics", "athletics", "deception", "insight", "intimidation", "investigation", "perception",
					"performance", "persuasion", "sleight of hand", "stealth"
				];

				foreach (string RogueSkillsPrint in RogueSkills)
				{
					Console.WriteLine(RogueSkillsPrint);
				}

				for (int RogueskillsCounter = 0; RogueskillsCounter < 4; RogueskillsCounter++)
				{

					string BarbarianSkillsUserInput = Console.ReadLine() ?? string.Empty;

					if (RogueSkills.Contains(BarbarianSkillsUserInput.ToLower()))
					{
						ClassSkillsList.Add(BarbarianSkillsUserInput);
					}
				}

				break;

			case "sorcerer":
				ImmutableArray<string> SorcererSkills =
				[
					"arcana", "deception", "insight", "intimidation", "persuasion", "religion"
				];

				foreach (string SorcererSkillsPrint in SorcererSkills)
				{
					Console.WriteLine(SorcererSkillsPrint);
				}

				for (int SorcererskillsCounter = 0; SorcererskillsCounter < 2; SorcererskillsCounter++)
				{

					string SorcererSkillsUserInput = Console.ReadLine() ?? string.Empty;

					if (SorcererSkills.Contains(SorcererSkillsUserInput.ToLower()))
					{
						ClassSkillsList.Add(SorcererSkillsUserInput);
					}
				}

				break;

			case "warlock":
				ImmutableArray<string> WarlockSkills =
				[
					"arcana", "deception", "history", "intimidation", "investigation", "nature", "religion"
				];

				foreach (string WarlockSkillsPrint in WarlockSkills)
				{
					Console.WriteLine(WarlockSkillsPrint);
				}

				for (int WarlockskillsCounter = 0; WarlockskillsCounter < 2; WarlockskillsCounter++)
				{

					string WarlockSkillsUserInput = Console.ReadLine() ?? string.Empty;

					if (WarlockSkills.Contains(WarlockSkillsUserInput.ToLower()))
					{
						ClassSkillsList.Add(WarlockSkillsUserInput);
					}
				}

				break;

			case "wizard":
				ImmutableArray<string> WizardSkills =
				[
					"arcana", "history", "insight", "investigation", "medicine", "religion"
				];

				foreach (string WizardSkillsPrint in WizardSkills)
				{
					Console.WriteLine(WizardSkillsPrint);
				}

				for (int WizardskillsCounter = 0; WizardskillsCounter < 2; WizardskillsCounter++)
				{

					string WizardSkillsUserInput = Console.ReadLine() ?? string.Empty;

					if (WizardSkills.Contains(WizardSkillsUserInput.ToLower()))
					{
						ClassSkillsList.Add(WizardSkillsUserInput);
					}
				}

				break;
		}

		for (int ClassesCounter = 1; ClassesCounter < classes.Count; ClassesCounter++)
		{
			switch (classes[ClassesCounter].ToLower())
			{
				case "barbarian":
					ImmutableArray<string> BarbarianSkills =
					[
						"animal handling", "athletics", "intimidation", "nature", "perception", "survival"
					];

					foreach (string BarbarianSkillsPrint in BarbarianSkills)
					{
						Console.WriteLine(BarbarianSkillsPrint);
					}

					for (int BarbarianskillsCounter = 0; BarbarianskillsCounter < 2; BarbarianskillsCounter++)
					{

						string BarbarianSkillsUserInput = Console.ReadLine() ?? string.Empty;

						if (BarbarianSkills.Contains(BarbarianSkillsUserInput.ToLower()))
						{
							ClassSkillsList.Add(BarbarianSkillsUserInput);
						}
					}

					break;

				case "bard":
					ImmutableArray<string> BardSkills =
					[
						"acrobatics", "animal handling", "arcana", "athletics", "deception", "history", "insight",
						"intimidation",
						"investigation", "medicine", "nature", "perception", "performance", "persuasion", "religion",
						"sleight of hand", "stealth", "survival"
					];

					foreach (string BardSkillsPrint in BardSkills)
					{
						Console.WriteLine(BardSkillsPrint);
					}

					for (int BardnskillsCounter = 0; BardnskillsCounter < 2; BardnskillsCounter++)
					{

						string BarbarianSkillsUserInput = Console.ReadLine() ?? string.Empty;

						if (BardSkills.Contains(BarbarianSkillsUserInput.ToLower()))
						{
							ClassSkillsList.Add(BarbarianSkillsUserInput);
						}
					}

					break;

				case "cleric":
					ImmutableArray<string> ClericSkills =
					[
						"history", "insight", "medicine", "persuasion", "religion"
					];

					foreach (string ClericSkillsPrint in ClericSkills)
					{
						Console.WriteLine(ClericSkillsPrint);
					}

					for (int ClericSkillsCounter = 0; ClericSkillsCounter < 2; ClericSkillsCounter++)
					{

						string ClericSkillsUserInput = Console.ReadLine() ?? string.Empty;

						if (ClericSkills.Contains(ClericSkillsUserInput.ToLower()))
						{
							ClassSkillsList.Add(ClericSkillsUserInput);
						}
					}

					break;

				case "druid":
					ImmutableArray<string> DruidSkills =
					[
						"arcana", "animal handling", "insight", "medicine", "nature", "perception", "religion",
						"survival"
					];

					foreach (string DruidSkillsPrint in DruidSkills)
					{
						Console.WriteLine(DruidSkillsPrint);
					}

					for (int DruidskillsCounter = 0; DruidskillsCounter < 2; DruidskillsCounter++)
					{

						string DruidSkillsUserInput = Console.ReadLine() ?? string.Empty;

						if (DruidSkills.Contains(DruidSkillsUserInput.ToLower()))
						{
							ClassSkillsList.Add(DruidSkillsUserInput);
						}
					}

					break;

				case "fighter":
					ImmutableArray<string> FighterSkills =
					[
						"acrobatics", "animal handling", "athletics", "history", "insight", "intimidation",
						"perception", "survival"
					];

					foreach (string FighterSkillsPrint in FighterSkills)
					{
						Console.WriteLine(FighterSkillsPrint);
					}

					for (int FighterskillsCounter = 0; FighterskillsCounter < 2; FighterskillsCounter++)
					{

						string FighterSkillsUserInput = Console.ReadLine() ?? string.Empty;

						if (FighterSkills.Contains(FighterSkillsUserInput.ToLower()))
						{
							ClassSkillsList.Add(FighterSkillsUserInput);
						}
					}

					break;

				case "monk":
					ImmutableArray<string> MonkSkills =
					[
						"acrobatics", "athletics", "history", "insight", "religion", "stealth"
					];

					foreach (string MonkSkillsPrint in MonkSkills)
					{
						Console.WriteLine(MonkSkillsPrint);
					}

					for (int MonkskillsCounter = 0; MonkskillsCounter < 2; MonkskillsCounter++)
					{

						string MonkSkillsUserInput = Console.ReadLine() ?? string.Empty;

						if (MonkSkills.Contains(MonkSkillsUserInput.ToLower()))
						{
							ClassSkillsList.Add(MonkSkillsUserInput);
						}
					}

					break;

				case "paladin":
					ImmutableArray<string> PaladinSkills =
					[
						"athletics", "insight", "intimidation", "medicine", "persuasion", "religion"
					];

					foreach (string PaladinSkillsPrint in PaladinSkills)
					{
						Console.WriteLine(PaladinSkillsPrint);
					}

					for (int PaladinskillsCounter = 0; PaladinskillsCounter < 2; PaladinskillsCounter++)
					{

						string PaladinSkillsUserInput = Console.ReadLine() ?? string.Empty;

						if (PaladinSkills.Contains(PaladinSkillsUserInput.ToLower()))
						{
							ClassSkillsList.Add(PaladinSkillsUserInput);
						}
					}

					break;

				case "ranger":
					ImmutableArray<string> RangerSkills =
					[
						"animal handling", "athletics", "insight", "investigation", "nature", "perception", "stealth",
						"survival"
					];

					foreach (string RangerSkillsPrint in RangerSkills)
					{
						Console.WriteLine(RangerSkillsPrint);
					}

					for (int RangerskillsCounter = 0; RangerskillsCounter < 2; RangerskillsCounter++)
					{

						string RangerSkillsUserInput = Console.ReadLine() ?? string.Empty;

						if (RangerSkills.Contains(RangerSkillsUserInput.ToLower()))
						{
							ClassSkillsList.Add(RangerSkillsUserInput);
						}
					}

					break;

				case "rogue":
					ImmutableArray<string> RogueSkills =
					[
						"acrobatics", "athletics", "deception", "insight", "intimidation", "investigation",
						"perception", "performance", "persuasion", "sleight of hand", "stealth"
					];

					foreach (string RogueSkillsPrint in RogueSkills)
					{
						Console.WriteLine(RogueSkillsPrint);
					}

					for (int RogueskillsCounter = 0; RogueskillsCounter < 2; RogueskillsCounter++)
					{

						string BarbarianSkillsUserInput = Console.ReadLine() ?? string.Empty;

						if (RogueSkills.Contains(BarbarianSkillsUserInput.ToLower()))
						{
							ClassSkillsList.Add(BarbarianSkillsUserInput);
						}
					}

					break;

				case "sorcerer":
					ImmutableArray<string> SorcererSkills =
					[
						"arcana", "deception", "insight", "intimidation", "persuasion", "religion"
					];

					foreach (string SorcererSkillsPrint in SorcererSkills)
					{
						Console.WriteLine(SorcererSkillsPrint);
					}

					for (int SorcererskillsCounter = 0; SorcererskillsCounter < 2; SorcererskillsCounter++)
					{

						string SorcererSkillsUserInput = Console.ReadLine() ?? string.Empty;

						if (SorcererSkills.Contains(SorcererSkillsUserInput.ToLower()))
						{
							ClassSkillsList.Add(SorcererSkillsUserInput);
						}
					}

					break;

				case "warlock":
					ImmutableArray<string> WarlockSkills =
					[
						"arcana", "deception", "history", "intimidation", "investigation", "nature", "religion"
					];

					foreach (string WarlockSkillsPrint in WarlockSkills)
					{
						Console.WriteLine(WarlockSkillsPrint);
					}

					for (int WarlockskillsCounter = 0; WarlockskillsCounter < 2; WarlockskillsCounter++)
					{

						string WarlockSkillsUserInput = Console.ReadLine() ?? string.Empty;

						if (WarlockSkills.Contains(WarlockSkillsUserInput.ToLower()))
						{
							ClassSkillsList.Add(WarlockSkillsUserInput);
						}
					}

					break;

				case "wizard":
					ImmutableArray<string> WizardSkills =
					[
						"arcana", "history", "insight", "investigation", "medicine", "religion"
					];

					foreach (string WizardSkillsPrint in WizardSkills)
					{
						Console.WriteLine(WizardSkillsPrint);
					}

					for (int WizardskillsCounter = 0; WizardskillsCounter < 2; WizardskillsCounter++)
					{

						string WizardSkillsUserInput = Console.ReadLine() ?? string.Empty;

						if (WizardSkills.Contains(WizardSkillsUserInput.ToLower()))
						{
							ClassSkillsList.Add(WizardSkillsUserInput);
						}
					}
					break;
			}
		}
		return ClassSkillsList; 
	}
}