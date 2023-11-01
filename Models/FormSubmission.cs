using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace T4Challenge.Models
{
    public class FormSubmission
    {
        public int Id { get; set; }

        public DateTime SubmissionDate { get; set; }


        [JsonProperty("dynamicFields")]
        public List<DynamicField> DynamicFields { get; set; }
    }
}
