using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class CharacterMoods : MonoBehaviour
{
    public CharacterName Name;
    public Sprite Neutral;
    public Sprite Flirty;
    public Sprite Angry;
    public Sprite Shy;

    public Sprite GetMoodSprite(CharacterMood mood)
    {
        switch (mood)
        {
            case CharacterMood.Neutral:
                return Neutral;
            case CharacterMood.Flirty:
                return Flirty ?? Neutral;
            case CharacterMood.Angry:
                return Angry ?? Neutral;
            case CharacterMood.Shy:
                return Shy ?? Neutral;
            default:
                Debug.Log($"No se encontro el sprite para el pj: {Name}, mood : {mood}");
                return Neutral;

        }
    }
}
