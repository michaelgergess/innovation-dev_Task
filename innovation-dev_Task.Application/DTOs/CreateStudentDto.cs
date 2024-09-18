using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace innovation_dev_Task.Application.DTOs
{
    public class CreateStudentDto
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains numbers or special characters.")]
        [Remote(action: "ValidateStudentName", controller: "Student", ErrorMessage = "Student name already exists.")]
        public string Name { get; set; }

        [Required]
        [AgeValidation]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(2, ErrorMessage = "Student can choose up to 2 subjects only.")]
        public List<int> SelectedSubjectIds { get; set; }
    }
}