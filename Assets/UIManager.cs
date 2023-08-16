using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform rectTransform;
    // Start is called before the first frame update

    public void animateup()
    {
        rectTransform.transform.localPosition = new Vector3(-210.73f, -669.3f, 0f);
        rectTransform.DOAnchorPos(new Vector2(-210.73f, 700f), 1f, false).SetEase(Ease.InBounce);
        
    }

    public void animatedown()
    {
        rectTransform.transform.localPosition = new Vector3(-210.73f, 700f, 0f);
        rectTransform.DOAnchorPos(new Vector2(-210.73f, 669f), 1f, false).SetEase(Ease.InBounce);
        
    }
    void Start()
    {
        InvokeRepeating("animateup",1.0f,1.0f);
        InvokeRepeating("animatedown",1.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
