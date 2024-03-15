

using VandecoStore.Core;
using VandecoStore.Domain.Exceptions;

namespace VandecoStore.Domain
{
    public abstract class EntityValidation : Entity
    {
        private const string DEFAULT_ERROR_MESSAGE_NULL = "The Field {0} Must Be Provided !";
        private const string DEFAULT_ERROR_MESSAGE_LESS = "The Field {0} Must Be Greather Than {1} !";

        protected void FailIfNull(object? value, string propertyName)
        {
            AssertionConcern.AssertArgumentNotNull(value, string.Format(DEFAULT_ERROR_MESSAGE_NULL, propertyName));
        }

        protected void FailIfNullOrEmpty(string? value, string propertyName)
        {
            AssertionConcern.AssertArgumentNotEmpty(value, string.Format(DEFAULT_ERROR_MESSAGE_NULL, propertyName));
        }

        protected void FailIfNullOrEmpty<T>(IEnumerable<T>? value, string propertyName)
        {
            var isNullOrEmpty = value is null || !value.Any();
            AssertionConcern.AssertStateTrue(isNullOrEmpty, string.Format(DEFAULT_ERROR_MESSAGE_NULL, propertyName));
        }

        protected void FailIfLessThan(decimal value, decimal minValue, string propertyName)
        {
            AssertionConcern.AssertArgumentRange(value, minValue, decimal.MaxValue, string.Format(DEFAULT_ERROR_MESSAGE_LESS, propertyName, minValue - 0.01m));
        }

        protected void FailIfLessThan(int value, int minValue, string propertyName)
        {
            AssertionConcern.AssertArgumentRange(value, minValue, decimal.MaxValue, string.Format(DEFAULT_ERROR_MESSAGE_LESS, propertyName, minValue - 1));
        }
    }
}
