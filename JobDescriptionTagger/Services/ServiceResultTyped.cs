namespace JobDescriptionTagger.Services
{
    public class ServiceResult<T> : ServiceResult
    {
        public T Value { get; set; }

        public ServiceResult()
        {

        }

        public ServiceResult(T value)
        {
            Value = value;
        }
    }
}