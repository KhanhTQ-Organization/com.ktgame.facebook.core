namespace com.ktgame.facebook.core
{
	public interface IResult
	{
		public string Error { get; }

		public string RawResult { get; }

		public bool Cancelled { get; }
	}
}
