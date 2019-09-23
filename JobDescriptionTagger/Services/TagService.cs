using System.Collections.Generic;
using System.Linq;
using JobDescriptionTagger.Database;
using JobDescriptionTagger.Models;

namespace JobDescriptionTagger.Services
{
    public class TagService
    {
        private readonly DataModel _dataModel;

        public TagService()
        {
            _dataModel = new DataModel();
        }

        public ServiceResult<TagsModel> GetTags(bool includeIgnored)
        {
            var usefulTags = _dataModel.Tags.ToArray();

            if (!includeIgnored)
            {
                usefulTags = usefulTags.Where(x => !x.Ignore).ToArray();
            }

            if (!usefulTags.Any())
            {
                return new ServiceResult<TagsModel>
                {
                    ResultMessage = "No records returned.",
                    Value = new TagsModel()
                };
            }

            var model = new TagsModel(usefulTags);
            return new ServiceResult<TagsModel>
            {
                ResultMessage = "Records retrieved successfully.",
                Value = model
            };
        }
    }
}