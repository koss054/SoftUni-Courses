using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

using SoftJail.Common;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportDepartmentWithCellsDto
    {
        [Required]
        [MinLength(GlobalConstants.DepartmentNameMinLength)]
        [MaxLength(GlobalConstants.DepartmentNameMaxLength)]
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Cells))]
        public ImportDepartmentCellsDto[] Cells { get; set; }
    }
}
