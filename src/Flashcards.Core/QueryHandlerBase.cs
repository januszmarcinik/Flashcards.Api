namespace Flashcards.Core
{
    public abstract class QueryHandlerBase<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        public abstract Result<TResult> Handle(TQuery query);

        protected Result<TResult> Ok(TResult value)
        {
            return Result.Ok(value);
        }

        protected Result<TResult> Fail(string message)
        {
            return Result.Fail<TResult>(message);
        }
    }
}
