using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using JobDescriptionTagger.Database;
using JobDescriptionTagger.Models;

namespace JobDescriptionTagger.Services
{
    public class UserTagService
    {
        private readonly DataModel _dataModel;

        public UserTagService()
        {
            _dataModel = new DataModel();
        }

        public ServiceResult SaveTags(UserTagModel model)
        {
            IEnumerable<string> newTags;

            var user = _dataModel.Users.FirstOrDefault(x => x.Username.Equals(model.Username));
            if (user == null)
            {
                user = _dataModel.Users.Add(new User {Username = model.Username});
                newTags = model.Tags;
            }
            else
            {
                var tags = user.Tags.Select(x => x.TagName);
                newTags = model.Tags.Where(x => !tags.Contains(x));
            }

            foreach (var tag in newTags)
            {
                user.Tags.Add(new Tag
                {
                    TagName = tag
                });
            }

            return new ServiceResult
            {
                DataModelResultValue = _dataModel.SaveChanges(),
                ResultMessage = "Records created successfully."
            };
        }
    }
}
