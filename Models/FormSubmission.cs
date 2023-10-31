using System;
using System.ComponentModel.DataAnnotations;

namespace T4Challenge.Models
{
    // FormSubmission.cs
    public class FormSubmission
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SubmissionDate { get; set; }
    }

}
