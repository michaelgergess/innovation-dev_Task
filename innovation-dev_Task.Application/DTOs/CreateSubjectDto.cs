using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace innovation_dev_Task.Application.DTOs
{
    public class CreateSubjectDto
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains numbers or special characters.")]
        [Remote(action: "ValidateSubjectName", controller: "Student", ErrorMessage = "Subject name already exists.")]
        public string Name { get; set; }
    }


}
