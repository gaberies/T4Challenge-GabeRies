using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace T4Challenge.Models
{
    public class FormSubmission
    {
        public int Id { get; set; }

        public DateTime SubmissionDate { get; set; }


        // Change DynamicFields to a List of DynamicField
        public List<DynamicField> DynamicFields { get; set; }
    }
}
