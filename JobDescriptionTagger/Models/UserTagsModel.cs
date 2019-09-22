using System;
using System.Collections.Generic;
using System.Linq;

namespace JobDescriptionTagger.Models
{
    public class UserTagModel
    {
        public string Username { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Tags => GetUsefulTags(Description);

        private IEnumerable<string> GetUsefulTags(string description)
        {
            //Remove useless punctuation
            var uselessPunctuation = new[] {'\\', '/', '|','¦','(',')','[',']','{','}'};
            var tagsString = uselessPunctuation.Aggregate(Description, (current, x) => current.Replace(x, ' '));

            var tags = tagsString.Split(new [] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            var pairs = new List<string>();
            var triplets = new List<string>();

            var i = 0;
            for (; i < tags.Length - 2; i++)
            {
                pairs.Add($"{tags[i]} {tags[i + 1]}");
                triplets.Add($"{tags[i]} {tags[i + 1]} {tags[i + 2]}");
            }

            if (tags.Length > 1)
            {
                pairs.Add($"{tags[i]} {tags[i + 1]}");
            }

            return tags.Union(pairs).Union(triplets);
        }
    }
}