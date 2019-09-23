using System.Collections.Generic;
using System.Collections.ObjectModel;
using JobDescriptionTagger.Database;

namespace JobDescriptionTagger.Models
{
    public class TagsUsersModel
    {
        public ICollection<TagUsersModel> TagData { get; set; }

        public TagsUsersModel()
        {
        }

        public TagsUsersModel(IEnumerable<Tag> value)
        {
            TagData = new Collection<TagUsersModel>();

            foreach (var tag in value)
            {
                TagData.Add(new TagUsersModel(tag));
            }
        }
    }
}
