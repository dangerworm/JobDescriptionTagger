using System.Collections.Generic;
using System.Linq;
using JobDescriptionTagger.Database;

namespace JobDescriptionTagger.Models
{
    public class TagsUsersModel
    {
        public IEnumerable<TagUsersModel> TagData { get; set; }

        public TagsUsersModel()
        {
        }

        public TagsUsersModel(IEnumerable<Tag> value)
        {
            TagData = value.Select(x => new TagUsersModel(x));
        }
    }
}
