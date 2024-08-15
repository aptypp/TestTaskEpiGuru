using OneSignalSDK;

namespace ThirdParty
{
    public class OneSignalService
    {
        private readonly string _appId;

        public OneSignalService(
            string appId)
        {
            _appId = appId;
        }

        public void Initialize() => OneSignal.Initialize(_appId);
    }
}