namespace JobDescriptionTagger.Database
{
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Inference
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InferenceId { get; set; }

        public int? SourceTagId { get; set; }

        public int? TargetTagId { get; set; }

        public virtual Tag SourceTag { get; set; }

        public virtual Tag TargetTag { get; set; }
    }
}
