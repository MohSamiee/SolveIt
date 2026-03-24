namespace SolveIt.Domain.Entities.Locations;
public class State : BaseEntity
{
	#region Properties
	public string Title { get; set; }
	public long? ParentId { get; set; }
	#endregion Properties

	#region Relations
	public State? Parent { get; set; }
	public ICollection<State>? Children { get; set; } = new List<State>();


	public ICollection<User>? UserCities { get; set; } = new List<User>();
	public ICollection<User>? UserCountries { get; set; } = new List<User>();

	#endregion Relations
}
