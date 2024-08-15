using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace ThirdParty
{
    public class IpLookUpService
    {
        public async UniTask<LookUpData> LookUp()
        {
            using var request = UnityWebRequest.Get("http://ip-api.com/json/");

            request.useHttpContinue = true;

            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success) return null;

            var textData = request.downloadHandler.text;

            var lookUpData = JsonUtility.FromJson<LookUpData>(textData);

            return lookUpData;
        }
    }
}