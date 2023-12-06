using Kafka.Common.Model;
using System.Collections.Immutable;
using System.Reflection;

namespace Kafka.Common.Protocol
{
    public static class ApiErrors
    {
        private static readonly ImmutableSortedDictionary<short, ApiError> ERRORS = Init();

        /// <summary>
        /// Returns a known <see cref="ApiError"/> instance.
        /// If the code is now known by the client, then it is translated into <see cref="ErrorCode.UNKNOWN_ERROR_CODE"/> with the translated code in the message.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static ApiError Translate(short errorCode)
        {
            if (ERRORS.TryGetValue(errorCode, out var error))
                return error;
            else
                return new(short.MinValue, "UNKNOWN_ERROR_CODE", false, $"Unknown error code returned from server ({errorCode}).");
        }

        private static ImmutableSortedDictionary<short, ApiError> Init()
        {
            var errorsBuilder = ImmutableSortedDictionary.CreateBuilder<short, ApiError>();
            var errorFields = typeof(ApiError)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(t => t.FieldType.Equals(typeof(ApiError)))
            ;
            foreach (var errorField in errorFields)
            {
                var instance = errorField.GetValue(null);
                if (instance is ApiError error)
                    errorsBuilder.Add(error.Code, error);
            }
            return errorsBuilder.ToImmutable();
        }
    }
}
