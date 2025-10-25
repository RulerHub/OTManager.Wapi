namespace OTManager.Api.Account.Records
{
    public class SessionResponse<T>
    {
        public bool IsSuccess { get; init; }
        public string? Message { get; init; }
        public T? Data { get; private init; }
        public SessionInfo? Session { get; init; }
        public string? CorrelationId { get; init; }

        public static SessionResponse<T> Success(T data, SessionInfo session, string? cid = null)
            => new() { IsSuccess = true, Data = data, Session = session, CorrelationId = cid };

        public static SessionResponse<T> Failure(string message, SessionInfo? session, string? cid = null)
            => new() { IsSuccess = false, Message = message, Session = session, CorrelationId = cid };
    }
}
