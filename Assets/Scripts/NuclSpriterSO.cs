using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuclSpriter", menuName = "Nucl Spriter")]
public class NuclSpriterSO : ScriptableObject
{
    public List<Sprite> UISprites;
    public List<Sprite> CombSprites;
    public List<Sprite> GeneratedSprites;
    
    public Sprite GetUISprite(NuclManager.NuclEnum index)
    {
        try
        {
            return UISprites[(int)index];
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    public Sprite GetCombSprite(NuclManager.NuclEnum index)
    {
        try
        {
            return CombSprites[(int)index];
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    public Sprite GetGeneratedSprite(NuclManager.NuclEnum index)
    {
        try
        {
            return GeneratedSprites[(int)index];
        }
        catch (System.Exception)
        {
            return null;
        }
    }
}
