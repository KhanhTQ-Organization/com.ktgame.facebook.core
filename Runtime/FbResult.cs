using System;
using System.Collections;
using com.ktgame.json.mini;

namespace com.ktgame.facebook.core
{
	public abstract class FbResult
	{
		public FbResultState State { get; private set; }

		public bool IsSucceeded => State == FbResultState.Success;

		public bool IsFailed => !IsSucceeded;

		public string RawResult { get; }

		public string Error { get; internal set; }

		public FbResult(IResult graphResult)
		{
			State = GetResultState(graphResult);
			if (State == FbResultState.ApiError)
			{
				Error = graphResult.Error;
			}

			RawResult = graphResult.RawResult;
			if (State == FbResultState.Success)
			{
				try
				{
					var json = Json.Deserialize(RawResult) as IDictionary;
					OnDataReady(json);
				}
				catch (Exception ex)
				{
					Error = ex.Message;
					State = FbResultState.ParsingFailed;
				}
			}
		}

		protected abstract void OnDataReady(IDictionary json);

		private FbResultState GetResultState(IResult graphResult)
		{
			if (graphResult == null) return FbResultState.NullResult;
			if (graphResult.Cancelled) return FbResultState.UserCanceled;
			if (!string.IsNullOrEmpty(graphResult.Error)) return FbResultState.ApiError;
			if (string.IsNullOrEmpty(graphResult.RawResult)) return FbResultState.EmptyRawResult;
			return FbResultState.Success;
		}
	}
}