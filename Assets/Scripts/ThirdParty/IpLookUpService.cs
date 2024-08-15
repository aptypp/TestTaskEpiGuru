using System;
using UnityEngine;
using UnityEngine.Networking;

namespace ThirdParty
{
    public class IpLookUpService
    {
        public void LookUp(
            Action<LookUpData> onSuccess,
            Action onFailed)
        {
            var request = UnityWebRequest.Get("http://ip-api.com/json/");

            request.useHttpContinue = true;

            request.SendWebRequest()
                .completed += _ =>
            {
                if (request.result != UnityWebRequest.Result.Success)
                {
                    onFailed();
                    return;
                }

                var textData = request.downloadHandler.text;

                var lookUpData = JsonUtility.FromJson<LookUpData>(textData);

                onSuccess(lookUpData);

                request.Dispose();
            };
        }
    }
}