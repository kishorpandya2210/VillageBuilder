using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Resources
{
    [SerializeField] public float curr;
    [SerializeField] public float max;
    [SerializeField] public Text resourceText;
    [SerializeField] public Image resourceImage;

    public Text ResourceText
    {
        get { return resourceText; }
        set { resourceText = value; }
    }

    public Image ResourceImage
    {
        get { return resourceImage; }
        set { resourceImage = value; }
    }

    public float Curr
    {
        get { return curr; }
        set
        {
            if(value > max)
                curr = max;
            else if(value <= 0)
            {
                curr = 0;
            }
            else
            {
                curr = value;
            }
            
        }
    }

    public float Max
    {
        get { return max; }
    }

    public void UpdateResource()
    {
        if(resourceText != null)
        {
            resourceText.text = ToString();
        }
        if(resourceImage != null)
        {
            resourceImage.fillAmount = Percent();
        }
    }

    public override string ToString()
    {
        return string.Format("{0} / {1}", curr, max);
    }

    public float Percent()
    {
        return (float)(curr / max);
    }
}
