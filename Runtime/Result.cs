using System;
using UnityEngine;

namespace com.ktgame.facebook.core
{
	[Serializable]
	public class Result : IResult
	{
		[SerializeField] private string error;
		[SerializeField] private string rawResult;
		[SerializeField] private bool cancelled;

		public string Error => error;
		public string RawResult => rawResult;
		public bool Cancelled => cancelled;

		public Result(bool cancelled, string error, string rawResult)
		{
			this.cancelled = cancelled;
			this.error = error;
			this.rawResult = rawResult;
		}
	}
}