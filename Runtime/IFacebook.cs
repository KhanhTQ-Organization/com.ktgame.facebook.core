using System;

namespace com.ktgame.facebook.core
{
	public interface IFacebook
	{
		bool IsInitialized { get; }
        
		bool IsLoggedIn { get; }
        
		void Initialize(Action onInitComplete = null, Action<bool> onHideUnity = null, string authResponse = null);

		void LogInWithPublishPermissions(Action<FbLoginResult> callback);

		void LogInWithReadPermissions(Action<FbLoginResult> callback);

		void LogOut();
	}
}
