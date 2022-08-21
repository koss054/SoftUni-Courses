using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

using SoftJail.Common;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportDepartmentCellsDto
    {
        [Required]
        [Range(GlobalConstants.CellNumberMinValue,
               GlobalConstants.CellNumberMaxValue)]
        [JsonProperty(nameof(CellNumber))]
        public int CellNumber { get; set; }

        [Required]
        [JsonProperty(nameof(HasWindow))]
        public bool HasWindow { get; set; }
    }
}
