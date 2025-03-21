using System.Collections.Immutable;

namespace MainFunction.StatBlocks.DndClasses.GeneralClassMethods;

public class StatblockProficienciesClass
{
	/*stat block skills class handles proficiencies and proficiency bonus for a stat block
	 it takes an argument of background, class, race and level
	 it handles saving throws, skills, tools, weapons and armour proficiencies and languages
	 and is spilt across StatBlockskillsClass and  StatBlockskillsClass1*/
	public Dictionary<string, object> ProficienciesMethod(string background, List<string> dndClass, string race, string subrace, List<int> level, Feats feats )
	{
		StatblockProficienciesClass1 OtherHalfStatBlock = new(background, dndClass, race, level, feats, subrace);
		
		Dictionary<string, object> Proficiencies = new()
		{
			{"skills", SkillsGeneratorMethod(background, dndClass, subrace, level, 0, race) },
			{"saving throws", SavingThrowsGenerator(dndClass, level)},
			{"tools", OtherHalfStatBlock.ToolsProficienciesPublic},
			{"languages", OtherHalfStatBlock.LanguagePublic},
			{"weapon proficiencies", OtherHalfStatBlock.WeaponProficienciesPublic},
			{"armour proficiencies", OtherHalfStatBlock.ArmourProficienciesPublic}
		};
		return Proficiencies;
	}

	private Dictionary<string, int> SkillsGeneratorMethod(string background, List<string> dndClass, string subrace,
		List<int> level, int feat, string race)
	{
		List<string> Skills = new();
		
		int TotalLevel = 0;

		foreach (int LevelNumbers in level)
		{
			TotalLevel += LevelNumbers;
		}
		ImmutableArray<int> ProfBonusArray = [2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6];

		int ProfBonus = ProfBonusArray[TotalLevel];
		
		Dictionary<string, int> StatblockSkillsDictionary = new();
		
		HashSet<string> BackGroundSkillList = BackGroundSkills(background);

		foreach (string BackGroundSkillAdd in BackGroundSkillList)
		{
			Skills.Add(BackGroundSkillAdd);
		}
		
		HashSet<string> SubraceSkillsList = SubraceSkills(subrace, Skills);
		
		foreach (string SubraceSkillAdd in SubraceSkillsList)
		{
			Skills.Add(SubraceSkillAdd);
		}

		foreach (string ClassSkillsString in  ClassSkills(dndClass,  Skills))
		{
			Skills.Add(ClassSkillsString);
		}
		
		/*here we check if the character has the feat skilled, which grants the user 3 skills
		 we then ask the user to input those three skills, and check they haven't already got those skills*/
		if (feat != 0)
		{
			ImmutableArray<string> SkilledSkills =
			[
				"acrobatics", "animal handling", "arcana", "athletics", "deception", "history", "insight",
				"intimidation", "investigation", "medicine", "nature", "perception", "performance", "persuasion", 
				"religion", "sleight of hand", "stealth", "survival"
			];
			
			Console.WriteLine("here are your possible ability scores");

			foreach (string SkilledSkillsPrintString in  SkilledSkills)
			{
				Console.WriteLine(SkilledSkillsPrintString);
			}

			for (int SkilledSkillIndex = 0; SkilledSkillIndex < feat; SkilledSkillIndex++)
			{
				Console.WriteLine("enter a skill\n");
				string? SkilledSkillInput = Console.ReadLine()?.ToLower();

				if (SkilledSkillInput != null && SkilledSkills.Contains(SkilledSkillInput))
				{
					if (!Skills.Contains(SkilledSkillInput))
					{
						Console.WriteLine("your input has been recorded");
						Skills.Add(SkilledSkillInput);
					}

					else
					{
						Console.WriteLine("you already have that skill");

						SkilledSkillIndex--;
					}
				}

				else
				{
					Console.WriteLine("that isn't a skill");

					SkilledSkillIndex--;
				}
			}
		}

		foreach (string SkillsToStatblockDictionary in Skills)
		{
			StatblockSkillsDictionary.Add(SkillsToStatblockDictionary, ProfBonus);
		}
		
		Skills.Sort();

		/*here we are adding expertise to skills*/
		foreach (string DndClassCounter in dndClass)
		{
			if (DndClassCounter == "rogue")
			{
				foreach (string SkillsCounter in Skills)
				{
					Console.WriteLine(SkillsCounter);
				}

				Console.WriteLine("enter two ability scores that you want expertise in");

				for (int RogueExpertiseRepeats = 0; RogueExpertiseRepeats < 2; RogueExpertiseRepeats++)
				{
					string? RogueExpertiseUserInput = Console.ReadLine()?.ToLower();

					if (RogueExpertiseUserInput != null && Skills.Contains(RogueExpertiseUserInput))
					{
						StatblockSkillsDictionary[RogueExpertiseUserInput] *= 2;
						Skills.Remove(RogueExpertiseUserInput);
					}
				}
				
				if (level[dndClass.IndexOf(DndClassCounter)] >= 10)
				{
					Console.WriteLine("enter two ability scores that you want expertise in");

					for (int RogueExpertiseRepeats = 0; RogueExpertiseRepeats < 2; RogueExpertiseRepeats++)
					{
						string? RogueExpertiseUserInput = Console.ReadLine()?.ToLower();

						if (RogueExpertiseUserInput != null && Skills.Contains(RogueExpertiseUserInput))
						{
							StatblockSkillsDictionary[RogueExpertiseUserInput] *= 2;
							Skills.Remove(RogueExpertiseUserInput);
						}
					}
				}
			}
			
			if (DndClassCounter == "bard")
			{
				foreach (string SkillsCounter in Skills)
				{
					Console.WriteLine(SkillsCounter);
				}

				if (level[dndClass.IndexOf(DndClassCounter)] >= 3)
				{
					Console.WriteLine("enter two ability scores that you want expertise in");

					for (int BardExpertiseRepeats = 0; BardExpertiseRepeats < 2; BardExpertiseRepeats++)
					{
						string? BardExpertiseUserInput = Console.ReadLine()?.ToLower();

						if (BardExpertiseUserInput != null && Skills.Contains(BardExpertiseUserInput))
						{
							StatblockSkillsDictionary[BardExpertiseUserInput] *= 2;
							Skills.Remove(BardExpertiseUserInput);
						}

						else
						{
							Console.WriteLine("you already have that proficiency");
						}
					}
				}
				
				if (level[dndClass.IndexOf(DndClassCounter)] >= 10)
				{
					Console.WriteLine("enter two ability scores that you want expertise in");

					for (int BardExpertiseRepeats = 0; BardExpertiseRepeats < 2; BardExpertiseRepeats++)
					{
						string? BardExpertiseUserInput = Console.ReadLine()?.ToLower();

						if (BardExpertiseUserInput != null && Skills.Contains(BardExpertiseUserInput))
						{
							StatblockSkillsDictionary[BardExpertiseUserInput] *= 2;
							Skills.Remove(BardExpertiseUserInput);
						}

						else
						{
							Console.WriteLine("you already have that proficiency");
						}
					}
				}
			}
		}

		if (race != "elf") return StatblockSkillsDictionary;
		if (!Skills.Contains("perception"))
		{
			Skills.Add("perception");
		}

		return StatblockSkillsDictionary;
		}

	private HashSet<string> SubraceSkills(string subrace, List<string> listSkills)
	{
		HashSet<string> SubraceSkills = new();
		ImmutableArray<string> Skills =
		[
			"acrobatics", "animal handling", "arcana", "athletics", "deception", "history", "insight", "intimidation",
			"investigation", "medicine", "nature", "perception", "performance", "persuasion", "religion",
			"sleight of hand", "stealth", "survival"
		];

		/*as certain races get different skills */
		switch (subrace.ToLower())
		{
			case "variant human":
				foreach (string SkillsStrings in Skills)
				{
					Console.WriteLine(SkillsStrings);
				}		
				
				for (int VariantHumanSkillsCounter = 0; VariantHumanSkillsCounter < 2; VariantHumanSkillsCounter++)
				{
					Console.WriteLine("enter in a skills\n");
					string? UserRaceSkillsinput = Console.ReadLine();

					if (Skills.Contains(UserRaceSkillsinput?.ToLower() ?? string.Empty))
					{
						if (UserRaceSkillsinput != null && listSkills.Contains(UserRaceSkillsinput.ToLower()))
						{
							VariantHumanSkillsCounter--;
							Console.WriteLine("You already have that skill, enter another skill\n");
						}

						else
						{
							if (UserRaceSkillsinput != null) SubraceSkills.Add(UserRaceSkillsinput.ToLower());
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
					Console.WriteLine("enter in a skills\n");
					string? UserRaceSkillsinput = Console.ReadLine();

					if (UserRaceSkillsinput != null && Skills.Contains(UserRaceSkillsinput.ToLower()))
					{
						if (listSkills.Contains(UserRaceSkillsinput.ToLower()))
						{
							HalfElfSkillsCounter--;
							Console.WriteLine("You already have that skill, enter another skill\n");
						}

						else
						{
							SubraceSkills.Add(UserRaceSkillsinput.ToLower());
						}
					}
				}
				break;
			
			case "half orc":
				if (!listSkills.Contains("intimidation"))
				{
					SubraceSkills.Add("intimidation");
				}
				break;
			
		}

		

		return SubraceSkills;
	}

	private HashSet<string> BackGroundSkills(string background)
	{
		HashSet<string> BackGroundSkills = new();

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

	private HashSet<string> ClassSkills(List<string> classes, List<string> listSkills)
	{
		HashSet<string> ClassSkillsList = new();
		Console.WriteLine("here are you possible abilities\n");

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

				foreach (string ClassSkillsReturnString in ClassSkillsReturn(4, BarbarianSkills, listSkills ))
				{
					listSkills.Add(ClassSkillsReturnString);
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

				foreach (string ClassSkillsReturnString in ClassSkillsReturn(3,BardSkills, listSkills ))
				{
					listSkills.Add(ClassSkillsReturnString);
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

				foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, ClericSkills, listSkills ))
				{
					listSkills.Add(ClassSkillsReturnString);
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

				foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, DruidSkills, listSkills ))
				{
					listSkills.Add(ClassSkillsReturnString);
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

				foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, FighterSkills, listSkills ))
				{
					listSkills.Add(ClassSkillsReturnString);
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

				foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, MonkSkills, listSkills ))
				{
					listSkills.Add(ClassSkillsReturnString);
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

				foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, PaladinSkills, listSkills ))
				{
					listSkills.Add(ClassSkillsReturnString);
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

				foreach (string ClassSkillsReturnString in ClassSkillsReturn(3, RangerSkills, listSkills ))
				{
					listSkills.Add(ClassSkillsReturnString);
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

				foreach (string ClassSkillsReturnString in ClassSkillsReturn(4, RogueSkills, listSkills ))
				{
					listSkills.Add(ClassSkillsReturnString);
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

				foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, SorcererSkills, listSkills ))
				{
					listSkills.Add(ClassSkillsReturnString);
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

				foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, WarlockSkills, listSkills ))
				{
					listSkills.Add(ClassSkillsReturnString);
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

				foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, WizardSkills, listSkills ))
				{
					listSkills.Add(ClassSkillsReturnString);
				}

				break;
		}
		
		/*there is a for loop here as if a dnd character is multiclassed, it will only recieve two skills, instead of the normal amount*/

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

					foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, BarbarianSkills, listSkills ))
					{
						listSkills.Add(ClassSkillsReturnString);
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

					foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, BardSkills, listSkills ))
					{
						listSkills.Add(ClassSkillsReturnString);
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

					foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, ClericSkills, listSkills ))
					{
						listSkills.Add(ClassSkillsReturnString);
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

					foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, DruidSkills, listSkills ))
					{
						listSkills.Add(ClassSkillsReturnString);
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

					foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, FighterSkills, listSkills ))
					{
						listSkills.Add(ClassSkillsReturnString);
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

					foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, MonkSkills, listSkills ))
					{
						listSkills.Add(ClassSkillsReturnString);
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

					foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, PaladinSkills, listSkills ))
					{
						listSkills.Add(ClassSkillsReturnString);
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

					foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, RangerSkills, listSkills ))
					{
						listSkills.Add(ClassSkillsReturnString);
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

					foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, RogueSkills, listSkills ))
					{
						listSkills.Add(ClassSkillsReturnString);
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

					foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, SorcererSkills, listSkills ))
					{
						listSkills.Add(ClassSkillsReturnString);
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

					foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, WarlockSkills, listSkills ))
					{
						listSkills.Add(ClassSkillsReturnString);
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

					foreach (string ClassSkillsReturnString in ClassSkillsReturn(2, WizardSkills, listSkills ))
					{
						listSkills.Add(ClassSkillsReturnString);
					}
					break;
			}
		}
		return ClassSkillsList; 
	}

	private HashSet<string> ClassSkillsReturn(int numSkills, ImmutableArray<string> classSkills, List<string> currentSkills)
	{
		HashSet<string> ReturnSkills = new ();
		for (int SkillsCounter = 0; SkillsCounter < numSkills; SkillsCounter++)
		{
			Console.WriteLine("\nenter an ability score");
			string? SkillsUserInput = Console.ReadLine() ;

			if (SkillsUserInput != null && classSkills.Contains(SkillsUserInput.ToLower()))
			{
				if (currentSkills.Contains(SkillsUserInput.ToLower()) || ReturnSkills.Contains(SkillsUserInput.ToLower()))
				{
					SkillsCounter--;
					Console.WriteLine("You already have that skill, enter another skill\n");
				}

				else
				{
					Console.WriteLine("your skill has been added");
					ReturnSkills.Add(SkillsUserInput.ToLower());
				}
			}

			else
			{
				SkillsCounter--;
				Console.WriteLine("that isn't an ability score");
			}
		}

		return ReturnSkills;
	}

	private HashSet<string> SavingThrowsGenerator(List<string> classes, List<int> level)
	{
		HashSet<string> ReturnList = new();

		switch (classes[0].ToLower())
		{
			case "barbarian":
				ReturnList.Add("str");
				ReturnList.Add("con");
				break;
			
			case "bard":
				ReturnList.Add("dex");
				ReturnList.Add("chr");
				break;
			
			case "cleric":
				ReturnList.Add("wis");
				ReturnList.Add("chr");
				break;
			
			case "druid":
				ReturnList.Add("int");
				ReturnList.Add("wis");
				break;
			
			case "fighter":
				ReturnList.Add("str");
				ReturnList.Add("con");
				break;
			
			case "monk":
				ReturnList.Add("str");
				ReturnList.Add("dex");
				break;
			
			case "paladin":
				ReturnList.Add("wis");
				ReturnList.Add("chr");
				break;
			
			case "ranger":
				ReturnList.Add("str");
				ReturnList.Add("dex");
				break;
			
			case "rogue":
				ReturnList.Add("dex");
				ReturnList.Add("int");
				break;
			
			case "sorcerer":
				ReturnList.Add("con");
				ReturnList.Add("chr");
				break;
			
			case "warlock":
				ReturnList.Add("wis");
				ReturnList.Add("chr");
				break;
			
			case "wizard":
				ReturnList.Add("int");
				ReturnList.Add("wis");
				break;
		}

		for (int SavingThrowsGeneratorCounter = 0; SavingThrowsGeneratorCounter < classes.Count; SavingThrowsGeneratorCounter++)
		{
			switch (classes[SavingThrowsGeneratorCounter].ToLower())
			{
				case "monk":
					if (level[SavingThrowsGeneratorCounter] >= 14)
					{
						ReturnList.Add("con");
						ReturnList.Add("int");
						ReturnList.Add("wis");
						ReturnList.Add("chr");
					}
					break;
				
				case "rogue":
					if (level[SavingThrowsGeneratorCounter] >= 15)
					{
						ReturnList.Add("wis");
					}
					break;
				
			}
		}
		
		return ReturnList;
	}
}