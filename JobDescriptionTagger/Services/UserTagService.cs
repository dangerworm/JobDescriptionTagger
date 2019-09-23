using System.Linq;
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

        public ServiceResult<TagsUsersModel> GetCommonTags(bool includeIgnored)
        {
            var usefulTags = _dataModel.Tags.ToArray();
            if (!includeIgnored)
            {
                usefulTags = usefulTags.Where(x => !x.Ignore).ToArray();
            }

            if (!usefulTags.Any())
            {
                return new ServiceResult<TagsUsersModel>
                {
                    ResultMessage = "No records returned.",
                    Value = new TagsUsersModel()
                };
            }

            var model = new TagsUsersModel(usefulTags.Where(x => x.Users.Count > 1));
            return new ServiceResult<TagsUsersModel>
            {
                ResultMessage = "Records retrieved successfully.",
                Value = model
            };
        }

        public ServiceResult SaveTags(UserTagModel model)
        {
            var user = 
                _dataModel.Users.FirstOrDefault(x => x.Username.Equals(model.Username)) ??
                _dataModel.Users.Add(new User {Username = model.Username});

            var newTags = model.Tags.Select(x => x.TagName);
            var existingTags = _dataModel.Tags.Where(x => newTags.Contains(x.TagName));

            foreach (var tagModel in model.Tags)
            {
                var existingTag = existingTags.FirstOrDefault(x => x.TagName.Equals(tagModel.TagName));
                if (existingTag != null)
                {
                    user.Tags.Add(existingTag);
                    continue;
                }

                user.Tags.Add(new Tag
                {
                    TagName = tagModel.TagName.ToLower(),
                    WindowSize = tagModel.WindowSize,
                    Ignore = tagModel.Ignore
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
