

namespace VandecoStore.Core
{
    public abstract class EntityValidation : Entity
    {
        private const string DEFAULT_ERROR_MESSAGE = "The Field {0} Must Be Provided !";

        protected void FailIfNull(object? value, string propertyName)
        {
            AssertionConcern.AssertArgumentNotNull(value, string.Format(DEFAULT_ERROR_MESSAGE, propertyName));
        }

        protected void FailIfNullOrEmpty(string? value, string propertyName)
        {
            AssertionConcern.AssertArgumentNotEmpty(value, string.Format(DEFAULT_ERROR_MESSAGE, propertyName));
        }

        protected void FailIfNullOrEmpty<T>(IEnumerable<T>? value, string propertyName)
        {
            var isNullOrEmpty = value is null || !value.Any();
            AssertionConcern.AssertStateTrue(isNullOrEmpty, string.Format(DEFAULT_ERROR_MESSAGE, propertyName));
        }
    }
}
