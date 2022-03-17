using System;
using UnityEngine;
using Proyecto26;

namespace Rocketseat.ExpertsClub
{
    public class FirebaseManager : MonoBehaviour
    {
        #region VARIABLES

        public static FirebaseManager Instance;

        [SerializeField] private TextAsset signinOrSignupJson;
        [SerializeField] private TextAsset resetPasswordJson;

        #endregion

        #region MONOBEHAVIOUR_METHODS

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        #region PUBLIC_METHODS

        public void Signin(string email, string password, Action<bool, string> callback = null)
        {
            string endpoint = $"{Constants.ENDPOINT_SIGNIN}{Constants.APIKEY_FIREBASE}";
            string payload = signinOrSignupJson.text;
            payload = payload.Replace("{email}", email);
            payload = payload.Replace("{password}", password);

            RestClient.Post(endpoint, payload)
                .Then(response =>
                {
                    callback?.Invoke(true, response.Text);
                })
                .Catch(error =>
                {
                    callback?.Invoke(false, error.Message);
                });
        }

        public void Signup(string email, string password, Action<bool, string> callback = null)
        {
            string endpoint = $"{Constants.ENDPOINT_SIGNUP}{Constants.APIKEY_FIREBASE}";
            string payload = signinOrSignupJson.text;
            payload = payload.Replace("{email}", email);
            payload = payload.Replace("{password}", password);

            RestClient.Post(endpoint, payload)
                .Then(response =>
                {
                    callback?.Invoke(true, response.Text);
                })
                .Catch(error =>
                {
                    callback?.Invoke(false, error.Message);
                });
        }

        public void ResetPassword(string email, Action<bool, string> callback = null)
        {
            string endpoint = $"{Constants.ENDPOINT_RESET_PASSWORD}{Constants.APIKEY_FIREBASE}";
            string payload = resetPasswordJson.text;
            payload = payload.Replace("{email}", email);

            RestClient.Post(endpoint, payload)
                .Then(response =>
                {
                    callback?.Invoke(true, response.Text);
                })
                .Catch(error =>
                {
                    callback?.Invoke(false, error.Message);
                });
        }

        #endregion
    }
}