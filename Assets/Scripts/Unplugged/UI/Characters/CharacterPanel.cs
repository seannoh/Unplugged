using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : BasePanel
{

    private Image leftImage;
    private Image midImage;
    private Image rightImage;

    void Start()
    {
        leftImage = transform.Find("Left").GetComponentInChildren<Image>();
        midImage = transform.Find("Mid").GetComponentInChildren<Image>();
        rightImage = transform.Find("Right").GetComponentInChildren<Image>();
    }

    void Update()
    {

    }

    public void UpdateCharacter(Dictionary<CharacterPosition, string> characters)
    {
        foreach (KeyValuePair<CharacterPosition, string> character in characters)
        {
            switch (character.Key)
            {
                case CharacterPosition.left:
                    if (character.Value == "")
                    {
                        HideCharacter(leftImage);
                        break;
                    }
                    ShowCharacter(leftImage, character.Value);
                    break;
                case CharacterPosition.mid:
                    if (character.Value == "")
                    {
                        HideCharacter(midImage);
                        break;
                    }
                    ShowCharacter(midImage, character.Value);
                    break;
                case CharacterPosition.right:
                    if (character.Value == "")
                    {
                        HideCharacter(rightImage);
                        break;
                    }
                    ShowCharacter(rightImage, character.Value);
                    break;
            }
        }
    }

    private void HideCharacter(Image image)
    {
        if (image == null)
        {
            print("image is null");
            return;
        }
        print("hide character" + image.name);
        image.sprite = null;
        image.color = new Color(0, 0, 0, 0);
    }

    private void ShowCharacter(Image image, string characterName)
    {
        print("show character" + characterName);
        image.sprite = ResMgr.Instance.Load<Sprite>("Characters/" + characterName);
        StartCoroutine(FadeIn(image));
        image.preserveAspect = true;
    }

    private IEnumerator FadeIn(Image image)
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            image.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }
}