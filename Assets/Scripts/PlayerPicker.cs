using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerPicker : MonoBehaviour
{
    private int selectedCharacterIndex;

    [SerializeField] private List<CharacterSelectableObject> characterList = new List<CharacterSelectableObject>();

    public Image characterSprite;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterDescription;

    private void Start()
    {
        UpdateCharacterSelectionUI();
    }

    public void LeftArrow()
    {
        selectedCharacterIndex--;
        if (selectedCharacterIndex < 0)
            selectedCharacterIndex = characterList.Count - 1;

        UpdateCharacterSelectionUI();
    }

    public void RightArrow()
    {
        selectedCharacterIndex++;
        if (selectedCharacterIndex == characterList.Count)
            selectedCharacterIndex = 0;

        UpdateCharacterSelectionUI();
    }

    private void UpdateCharacterSelectionUI()
    {
        characterSprite.sprite = characterList[selectedCharacterIndex].image;
        characterSprite.SetNativeSize();
        characterName.SetText(characterList[selectedCharacterIndex].characterName);
        characterDescription.SetText(characterList[selectedCharacterIndex].characterDescription);
    }

    [System.Serializable]
    public class CharacterSelectableObject
    {
        public Sprite image;
        public string characterName;
        public string characterDescription;
    }

    public void ConfirmarSeleccion()
    {
        PlayerPrefs.SetInt("Character", selectedCharacterIndex);
        PlayerPrefs.Save();
    }
   
}
