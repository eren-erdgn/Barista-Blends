using System;
using EventSystem;
using TMPro;
using UnityEngine;

namespace Order
{
    public class OrderUI : MonoBehaviour
    {
        [SerializeField] private CarManager carManager;
        [SerializeField] private TextMeshProUGUI orderText;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI scoreText;

        private void OnEnable()
        {
            Events.OnOrderChange.AddListener(UpdateOrderText);
            Events.OnTimerChange.AddListener(UpdateTimerText);
            Events.OnScoreChange.AddListener(UpdateScoreText);
        }

        private void OnDisable()
        {
            Events.OnOrderChange.RemoveListener(UpdateOrderText);
            Events.OnTimerChange.RemoveListener(UpdateTimerText);
            Events.OnScoreChange.RemoveListener(UpdateScoreText);
        }


        private void UpdateScoreText(int score)
        {
            scoreText.text = "Score: \n" + score;
        }

        private void UpdateOrderText(string order)
        {
            orderText.text = "Order: \n" + order;
        }

        private void UpdateTimerText(float timer)
        {
            timerText.text = "Timer: \n" + Mathf.FloorToInt(timer);
        }
    }
}
