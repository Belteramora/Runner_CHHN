using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordHelper : MonoBehaviour
{
    [SerializeField]
    private Button submitButton;

    [SerializeField]
    private TextMeshProUGUI upperText;

    [SerializeField]
    private string correctPassword;

    public void OnEditPassword(string password)
    {
        if (password == correctPassword)
        {
            if (LanguageChanger.currentLanguage == "ru")
                upperText.text = "Пароль верный";
            else if (LanguageChanger.currentLanguage == "en")
                upperText.text = "Correct password";

            submitButton.interactable = true;
        }
        else if(password != correctPassword) 
        {
			if (LanguageChanger.currentLanguage == "ru")
				upperText.text = "Пароль неверный";
			else if (LanguageChanger.currentLanguage == "en")
				upperText.text = "Uncorrect password";

            submitButton.interactable = false;
		}
         
    }
}
