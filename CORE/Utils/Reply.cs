namespace CORE.Utils
{
    public class Reply
    {
        public bool IsSuccess { get; }
        public IEnumerable<string>? Errors { get; }

        public Reply(bool isSuccess, IEnumerable<string>? errors = null)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public static Reply Success() => new(true);
        public static Reply Fail() => new(false);
        public static Reply Fail(string error) => new(false, [error]);
        public static Reply Fail(IEnumerable<string> errors) => new(false, errors);
    }
}
