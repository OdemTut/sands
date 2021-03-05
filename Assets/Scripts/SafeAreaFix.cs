using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaFix : MonoBehaviour
{
    //этот скрипт нужен для безопасной зоны
    private void Awake()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        SetArea(rectTransform);
        
    }
    void SetArea(RectTransform rectTransform)
    {

        Rect safeArea = Screen.safeArea;
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;
        //Vector2 t = anchorMin.x + anchorMin.y > (1 - anchorMax.x) + (1 - anchorMax.y) ? anchorMin : new Vector2((1 - anchorMax.x), (1 - anchorMax.y));
        //Vector2 need = anchorMin.x + anchorMin.y > anchorMax.x + anchorMax.y ? anchorMin : anchorMax;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;


        rectTransform.anchorMin = anchorMin;
        //rectTransform.anchorMax = new Vector2(1 - need.x, 1 - need.y);
        rectTransform.anchorMax = anchorMax;
    }
    /*void SetArea(RectTransform rectTransform)
    {
        
        Rect safeArea = Screen.safeArea;
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;
        Vector2 t = anchorMin.x + anchorMin.y > (1 - anchorMax.x) + (1 - anchorMax.y) ? anchorMin : new Vector2((1 - anchorMax.x), (1 - anchorMax.y));
        //Vector2 need = anchorMin.x + anchorMin.y > anchorMax.x + anchorMax.y ? anchorMin : anchorMax;

        t.x /= Screen.width;
        t.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        
        
        rectTransform.anchorMin = t;
        //rectTransform.anchorMax = new Vector2(1 - need.x, 1 - need.y);
        rectTransform.anchorMax = new Vector2(1 - t.x, 1 - t.y);
    }*/
}
