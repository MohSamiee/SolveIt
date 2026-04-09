public class Question : BaseEntity
{
	#region Properties

	public string Title { get; set; }

	public long UserId { get; set; }

	public string Content { get; set; }

	public bool IsChecked { get; set; }

	public int ViewCount { get; set; }

	public int Score { get; set; }
	#endregion Properties

	#region Relationships
	public User User { get; set; }
	#endregion Relationships
}
