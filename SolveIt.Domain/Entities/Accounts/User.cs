namespace SolveIt.Entities.Models.Users;
public class User : BaseEntity
{
	#region Properties
	public string? FirstName { get; set; }
	public string? LastName { get; set; }

	public string? Email { get; set; }
	public string? NormalizedEmail { get; set; } 
	public string? EmailActivationCode { get; set; }
	public DateTime? ExpireEmailActivationCode { get; set; }
	public bool IsEmailConfirmed { get; set; }

	public string HashedPassword { get; set; }


	public string? Mobile { get; set; }
	public string? MobileActivationCode { get; set; }
	public bool IsMobileConfirmed { get; set; }
	public DateTime? ExpireMobileActivationCode { get; set; }

	public string AvatarAddress { get; set; }

	public int AccessFailedCount { get; set; }
	public DateTime? LastLoginTime { get; set; }
	
	public bool IsBan { get; set; }
	public bool IsAdmin { get; set; }
	#endregion Properties

	#region Relation

	#endregion Relation
}