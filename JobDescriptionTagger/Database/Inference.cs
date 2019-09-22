namespace JobDescriptionTagger.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inference
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InferenceId { get; set; }

        public int? SourceTagId { get; set; }

        public int? TargetTagId { get; set; }

        public virtual Tag Tag { get; set; }

        public virtual Tag Tag1 { get; set; }
    }
}
