
using System.ComponentModel.DataAnnotations;

namespace SolveIt.Domain.Enums;
public enum UserMedalEnum
{
	[Display(Name = "NoMedal", ResourceType = typeof(PropertyDictionary))] None = 0,
	[Display(Name = "BronzeMedal", ResourceType = typeof(PropertyDictionary))] Bronze = 1,
	[Display(Name = "SilverMedal", ResourceType = typeof(PropertyDictionary))] Silver = 2,
	[Display(Name = "GoldMedal", ResourceType = typeof(PropertyDictionary))] Gold = 3
}