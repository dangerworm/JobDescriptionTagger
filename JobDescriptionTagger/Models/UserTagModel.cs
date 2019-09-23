using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace JobDescriptionTagger.Models
{
    public class UserTagModel
    {
        public string Username { get; set; }

        public string Description { get; set; }

        public IEnumerable<TagModel> Tags => GetUsefulTags();

        private IEnumerable<TagModel> GetUsefulTags()
        {
            //Remove useless punctuation
            var uselessPunctuation = new[] { '\\', '/', '|', '¦', '(', ')', '[', ']', '{', '}', '.', '?', '@'};
            var tagsString = uselessPunctuation.Aggregate(Description, (current, x) => current.Replace(x, ' '));

            var tags = tagsString
                .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new TagModel(x, 1))
                .ToArray();

            // Remove common words
            var commonWords = new[]
            {
                "ourselves", "hers", "between", "yourself", "but", "again", "there", "about", "once", "during", "out",
                "very", "having", "with", "they", "own", "an", "be", "some", "for", "do", "its", "yours", "such",
                "into", "of", "most", "itself", "other", "off", "is", "s", "am", "or", "who", "as", "from", "him",
                "each", "the", "themselves", "until", "below", "are", "we", "these", "your", "his", "through", "don",
                "nor", "me", "were", "her", "more", "himself", "this", "down", "should", "our", "their", "while",
                "above", "both", "up", "to", "ours", "had", "she", "all", "no", "when", "at", "any", "before", "them",
                "same", "and", "been", "have", "in", "will", "on", "does", "yourselves", "then", "that", "because",
                "what", "over", "why", "so", "can", "did", "not", "now", "under", "he", "you", "herself", "has", "just",
                "where", "too", "only", "myself", "which", "those", "i", "after", "few", "whom", "t", "being", "if",
                "theirs", "my", "against", "a", "by", "doing", "it", "how", "further", "was", "here", "than",

                "looking", "jobs", "http:", "https:", "etc"
            };

            tags = tags.Where(x => !commonWords.Contains(x.TagName)).ToArray();

            // Build TagModels
            var pairs = new Collection<TagModel>();
            var triplets = new Collection<TagModel>();

            var i = 0;
            for (; i < tags.Count() - 2; i++)
            {
                pairs.Add(new TagModel($"{tags[i].TagName} {tags[i + 1].TagName}", 2));
                triplets.Add(new TagModel($"{tags[i].TagName} {tags[i + 1].TagName} {tags[i + 2].TagName}", 3));
            }

            if (tags.Length > 1)
            {
                pairs.Add(new TagModel($"{tags[i].TagName} {tags[i + 1].TagName}", 2));
            }

            return tags.Union(pairs).Union(triplets);
        }
    }
}