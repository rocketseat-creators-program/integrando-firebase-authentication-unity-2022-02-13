using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Rocketseat.ExpertsClub
{
    public class AppManager : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField] private TMP_InputField emailInput;
        [SerializeField] private TMP_InputField passwordInput;
        [SerializeField] private Button signinButton;
        [SerializeField] private Button signupButton;
        [SerializeField] private Button resetPasswordButton;

        #endregion

        #region MONOBEHAVIOUR_METHODS

        private void Start()
        {
            signinButton.onClick.AddListener(OnButtonSigninClicked);
            signupButton.onClick.AddListener(OnButtonSignupClicked);
            resetPasswordButton.onClick.AddListener(OnButtonResetPasswordClicked);
        }

        #endregion

        #region PRIVATE_METHODS

        private void OnButtonSigninClicked() 
        {
            FirebaseManager.Instance.Signin(
                emailInput.text,
                passwordInput.text,
                (result, message) =>
                {
                    if (result)
                    {
                        Debug.Log($"Success signin: {message}");
                    }
                    else
                    {
                        Debug.Log($"Error signin: {message}");
                    }
                });
        }
        private void OnButtonSignupClicked() 
        {
            FirebaseManager.Instance.Signup(
                emailInput.text,
                passwordInput.text,
                (result, message) =>
                {
                    if (result)
                    {
                        Debug.Log($"Success signup: {message}");
                    }
                    else
                    {
                        Debug.Log($"Error signup: {message}");
                    }
                });
        }
        private void OnButtonResetPasswordClicked() 
        {
            FirebaseManager.Instance.ResetPassword(
                emailInput.text,
                (result, message) =>
                {
                    if (result)
                    {
                        Debug.Log($"Success reset password: {message}");
                    }
                    else
                    {
                        Debug.Log($"Error reset password: {message}");
                    }
                });
        }

        #endregion
    }
}