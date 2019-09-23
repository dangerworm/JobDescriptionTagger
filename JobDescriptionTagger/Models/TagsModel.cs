using System.Collections.Generic;
using System.Linq;
using JobDescriptionTagger.Database;

namespace JobDescriptionTagger.Models
{
    public class TagsModel
    {
        private readonly IEnumerable<TagModel> _tags;

        public IEnumerable<TagModel> Tags => _tags.Where(x => x.WindowSize == 1);

        public IEnumerable<TagModel> Pairs => _tags.Where(x => x.WindowSize == 2);

        public IEnumerable<TagModel> Triplets => _tags.Where(x => x.WindowSize == 3);

        public TagsModel()
        {
            _tags = Enumerable.Empty<TagModel>();
        }

        public TagsModel(IEnumerable<Tag> tags)
        {
            _tags = tags.Select(x => new TagModel(x));
        }
    }
}