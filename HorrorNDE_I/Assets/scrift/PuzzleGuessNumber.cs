using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems; // ✅ thêm dòng này

public class PuzzleGuessNumber : MonoBehaviour
{
    public GameObject panel;
    public TMP_InputField inputField;
    public TMP_Text hintText;
    public Button submitButton;

    private int correctNumber;
void Start()
{
    correctNumber = 666; // ✅ Đặt số cố định
    submitButton.onClick.AddListener(CheckAnswer);
}

    public void ShowPanel()
    {
        panel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null); // ✅ bỏ focus input khi mở
    }

    public void CheckAnswer()
    {
        EventSystem.current.SetSelectedGameObject(null); // ✅ bỏ focus sau khi submit

        if (int.TryParse(inputField.text, out int guess))
        {
            if (guess == correctNumber)
            {
                hintText.text = "🎉 Đúng rồi!";
                Invoke(nameof(ClosePanel), 1f);
            }
            else if (guess < correctNumber)
            {
                hintText.text = "📉 Số cần tìm lớn hơn!";
            }
            else
            {
                hintText.text = "📈 Số cần tìm nhỏ hơn!";
            }
        }
        else
        {
            hintText.text = "⚠️ Nhập một số hợp lệ!";
        }
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}


