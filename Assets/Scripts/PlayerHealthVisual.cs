using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthVisual : MonoBehaviour
{
    // Sprites for health
    [SerializeField]
    private Sprite[] healthImageArray = new Sprite[5];

    public Image containerPrefab;

    // Image size
    [SerializeField]
    private float imageSize = 25f;
    [SerializeField]
    private float imageDistance = 5f;
    [SerializeField]
    private int maxContainersInRow = 10;

    // Amount of helath fragments (gets calculated in Awake)
    private int healthFragments;

    // Start position
    private Image healthImage;

    private void Awake()
    {
        healthImage = GetComponent<Image>();
        healthFragments = healthImageArray.Length - 1;
        //Debug.Log("Anzahl Container-Fragmente: " + healthFragments);
    }

    private void Start()
    {
        //healthImage.sprite = healthImageArray[Random.Range(0, 6)];
        for (float i = 1; i >= 0;  i -= 1 / (float)healthFragments)
        {
            // Instantiate container image
            Image imageTmp = Instantiate(containerPrefab);
            // Make child of myself
            imageTmp.transform.SetParent(this.transform);
            // Set sprite
            imageTmp.sprite = healthImageArray[SetHealthContainer(i)];
            // Set size
            imageTmp.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imageSize);
            imageTmp.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, imageSize);
            // Set position
            imageTmp.GetComponent<RectTransform>().anchoredPosition = new Vector2(imageSize + (imageSize + imageDistance) * SetHealthContainer(i) * 2, -imageSize);
        }
    }

    private int SetHealthContainer (float containerHealth)
    {
        return (int)(containerHealth / (1 / (float)healthFragments));
    }
}
