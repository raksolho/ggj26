using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocManager : MonoBehaviour
{

    string[] suportedLanguages = {"English", "Português"};
    public string currentLanguage;

    private void Awake(){
        
        LocalizationManager.Read();
        LocalizationManager.Language = suportedLanguages[PlayerPrefs.GetInt("language", 0)];
        currentLanguage = suportedLanguages[PlayerPrefs.GetInt("language", 0)];
    }

    public void NextLanguage(){
        if(PlayerPrefs.GetInt("language", 0)+1 < suportedLanguages.Length){
            LocalizationManager.Language = suportedLanguages[PlayerPrefs.GetInt("language", 0)+1];
            PlayerPrefs.SetInt("language", PlayerPrefs.GetInt("language", 0)+1);
        }
        else{
            LocalizationManager.Language = suportedLanguages[0];
            PlayerPrefs.SetInt("language", 0);
        }
        currentLanguage = suportedLanguages[PlayerPrefs.GetInt("language", 0)];

    }

    public void PreviousLanguage(){
        if(PlayerPrefs.GetInt("language", 0)-1 >= 0){
            LocalizationManager.Language = suportedLanguages[PlayerPrefs.GetInt("language", 0)-1];
            PlayerPrefs.SetInt("language", PlayerPrefs.GetInt("language", 0)-1);
        }
        else{
            LocalizationManager.Language = suportedLanguages[suportedLanguages.Length-1];
            PlayerPrefs.SetInt("language", suportedLanguages.Length-1);
        }
        currentLanguage = suportedLanguages[PlayerPrefs.GetInt("language", 0)];
    }
}