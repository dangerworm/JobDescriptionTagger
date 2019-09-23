using System.Collections.Generic;
using System.Linq;
using JobDescriptionTagger.Database;

namespace JobDescriptionTagger.Models
{
    public class TagUsersModel
    {
        public TagModel Tag { get; set; }

        public IEnumerable<string> Usernames { get; set; }

        public TagUsersModel(Tag value)
        { 
            Tag = new TagModel(value);
            Usernames = value.Users.Select(x => x.Username);
        }
    }
}
