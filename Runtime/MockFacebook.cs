using System;

namespace com.ktgame.facebook.core
{
	public class MockFacebook : IFacebook
	{
		private readonly FbLoginResult _mockFbLoginResult;

		public bool IsInitialized { get; private set; }
		public bool IsLoggedIn { get; private set; }

		public MockFacebook(FbLoginResult mockFbLoginResult)
		{
			_mockFbLoginResult = mockFbLoginResult;
		}

		public void Initialize(Action onInitComplete = null, Action<bool> onHideUnity = null, string authResponse = null)
		{
			IsInitialized = true;
			onInitComplete?.Invoke();
		}

		public void LogInWithPublishPermissions(Action<FbLoginResult> callback)
		{
			IsLoggedIn = true;
			callback?.Invoke(_mockFbLoginResult);
		}

		public void LogInWithReadPermissions(Action<FbLoginResult> callback)
		{
			IsLoggedIn = true;
			callback?.Invoke(_mockFbLoginResult);
		}

		public void LogOut()
		{
			IsLoggedIn = false;
		}
	}
}