namespace HouseRenting.Models.Agents
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Agent;

    public class BecomeAgentFormModel
    {
        [Required]
        [StringLength(MaxPhoneLength, MinimumLength = MinPhoneLength)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
