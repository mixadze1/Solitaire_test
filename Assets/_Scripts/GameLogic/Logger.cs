using UnityEngine;

public static class Logger
{
    public static void Log(string message)
    {
#if UNITY_EDITOR
          Debug.Log(message);
#endif
    }

    public static void Log(string message,  Color color, bool isLogDevice = false)
    {
#if UNITY_EDITOR
        if (!isLogDevice)
        {
            string colorHex = ColorUtility.ToHtmlStringRGB(color);
            Debug.Log($"<color=#{colorHex}> {message}</color>"); 
        }
#endif
        if (isLogDevice)
        {
            string colorHex = ColorUtility.ToHtmlStringRGB(color);
            Debug.Log($"<color=#{colorHex}> {message}</color>");
        }
    }
}