using System;
using System.ComponentModel.DataAnnotations;

namespace T4Challenge.Models
{
    public class DynamicField
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string FieldName { get; set; }

        [Required]
        public string FieldValue { get; set; }

        // Foreign key to FormSubmission
        public int FormSubmissionId { get; set; }
        public FormSubmission FormSubmission { get; set; }
    }
}
