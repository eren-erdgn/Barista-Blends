using UnityEngine;

namespace EventSystem
{
    public static class Events
    {
        public static readonly EventActions <string> OnOrderChange = new EventActions<string>();
        public static readonly EventActions <float> OnTimerChange = new EventActions<float>();
        public static readonly EventActions <int> OnScoreChange = new EventActions<int>();
        
    }
}