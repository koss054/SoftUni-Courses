using System.ComponentModel.DataAnnotations;

using static TaskBoardApp.Data.Constants.DataConstants.Task;

namespace TaskBoardApp.Data.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TaskTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(TaskDescriptionMaxLength)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        public Board Board { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
