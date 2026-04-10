using System;
using UnityEngine;

namespace com.ktgame.facebook.core
{
	[Serializable]
	public class FbLoginResult : Result
	{
		[SerializeField] private string userId;
		[SerializeField] private string accessToken;

		public string UserId => userId;
		public string AccessToken => accessToken;

		public FbLoginResult(string userId, string accessToken, bool cancelled, string error, string rawResult) : base(cancelled, error, rawResult)
		{
			this.userId = userId;
			this.accessToken = accessToken;
		}
	}
}
