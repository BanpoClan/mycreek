using System.ComponentModel.DataAnnotations;

namespace MyCreek.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [MaxLength(32)]
        public string Theme { get; set; }
    }
}