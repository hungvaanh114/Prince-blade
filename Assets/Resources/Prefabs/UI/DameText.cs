using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DameText : MonoBehaviour
{
    public Text damageText; // Tham chiếu đến UI Text
    public float moveSpeed = 0.01f; // Tốc độ di chuyển của số lượng sát thương
    public float fadeDuration = 1.0f; // Thời gian mờ dần

    private void Start()
    {
        StartCoroutine(FadeOutAndMoveUp());
    }

    private IEnumerator FadeOutAndMoveUp()
    {
        float elapsedTime = 0f;
        Color originalColor = damageText.color;
        Vector3 originalPosition = transform.position;

        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            damageText.color = Color.Lerp(originalColor, new Color(originalColor.r, originalColor.g, originalColor.b, 0), t);
            transform.position = Vector3.Lerp(originalPosition, originalPosition + Vector3.up * 1, t);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        damageText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        Destroy(gameObject); // Xóa đối tượng khi kết thúc hiệu ứng
    }

    public void SetDamage(float damageAmount)
    {
        damageText.text = "-"+damageAmount.ToString();
    }
}
