using System.ComponentModel.DataAnnotations.Schema;
using JobDescriptionTagger.Database;

namespace JobDescriptionTagger.Models
{
    [NotMapped]
    public class TagModel
    {
        public int TagId { get; set; }

        public string TagName { get; set; }

        public int WindowSize { get; set; }

        public bool Ignore { get; set; }

        public int TagCount { get; set; }

        public TagModel()
        {
        }

        public TagModel(Tag value)
        {
            TagId = value.TagId;
            TagName = value.TagName;
            WindowSize = value.WindowSize;
            Ignore = value.Ignore;
            TagCount = value.Users.Count;
        }

        public TagModel(string tagName, int windowSize)
        {
            TagName = tagName;
            WindowSize = windowSize;
            Ignore = windowSize > 1;
        }

        public TagModel(string tagName, int windowSize, int tagCount)
            : this(tagName, windowSize)
        {
            TagCount = tagCount;
        }
    }
}