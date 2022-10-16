using System.ComponentModel.DataAnnotations;

using static TaskBoardApp.Data.Constants.DataConstants.Task;


namespace TaskBoardApp.Models.Tasks
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(TaskTitleMaxLength, MinimumLength = TaskTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(TaskDescriptionMaxLength, MinimumLength = TaskDescriptionMinLength)]
        public string Description { get; set; }

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public virtual IEnumerable<TaskBoardModel> Boards { get; set; }
    }
}
