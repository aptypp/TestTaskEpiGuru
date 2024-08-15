using Cysharp.Threading.Tasks;
using ThirdParty;
using UnityEngine;

namespace Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        private IpLookUpService _lookUpService;

        private void Start()
        {
            var oneSignal = new OneSignalService("635c5f12-bb1c-4e8a-92a5-65636c604328");
            oneSignal.Initialize();

            _lookUpService = new IpLookUpService();

            _lookUpService
                .LookUp()
                .ContinueWith(HandleLookUpData)
                .Forget();
        }

        private void HandleLookUpData(
            LookUpData data)
        {
            if (data.country.Equals("Ukraine"))
            {
                StartGame();
                return;
            }

            ShowWikipedia();
        }

        private void ShowWikipedia()
        {
            var webview = new WebViewService();
            webview.Show("https://www.wikipedia.org/");
        }

        private void StartGame()
        {
        }
    }
}