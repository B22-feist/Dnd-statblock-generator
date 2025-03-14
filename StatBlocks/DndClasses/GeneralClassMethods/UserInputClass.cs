namespace MainFunction.StatBlocks.DndClasses.GeneralClassMethods;

public class UserInputClass
{
	public required string Race { get; set; }

	public string? Subrace
	{
		get => throw new NotImplementedException();

		set => value ??= string.Empty;
	}

	public required List<string> Class { get; set; }
	
	public required string BackGround { get; set; }

	public static List<int> Level { get; set; }

	public required int TotalLevel
	{
		get => throw new NotImplementedException();
		init => value += Level.Sum();
	}
	
	public Feats? Feats { get; set; }
}