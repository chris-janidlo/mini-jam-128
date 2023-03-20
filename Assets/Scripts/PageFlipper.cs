using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageFlipper : MonoBehaviour
{
    public List<GameObject> Pages;
    public TextMeshProUGUI NumberDisplay;

    public Button UpButton, DownButton;

    int currentPage;

    void Start()
    {
        UpButton.onClick.AddListener(() => onPageChange(1));
        DownButton.onClick.AddListener(() => onPageChange(-1));
    }

    void onPageChange(int sign)
    {
        Debug.Assert(sign == -1 || sign == 1);

        Pages[currentPage].SetActive(false);

        currentPage += sign;
        currentPage = Mathf.Clamp(currentPage, 0, Pages.Count - 1);

        Pages[currentPage].SetActive(true);

        NumberDisplay.text = (currentPage + 1).ToString();

        UpButton.interactable = currentPage != Pages.Count - 1;
        DownButton.interactable = currentPage != 0;
    }
}
