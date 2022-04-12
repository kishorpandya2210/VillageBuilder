using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameFunc
{
    
    public static void CollectorSetup(Collector c, string index)
    {
        Debug.Log(DateTime.Now.ToString("HH:mm:ss dd MMMM, yyyy"));
        c.StartTime = PlayerPrefs.GetString(index);

        DateTime curr = DateTime.Now;
        DateTime old = new DateTime(long.Parse(c.StartTime));
        TimeSpan diff = curr - old;
        Debug.Log(curr - old);

        float amount = (float)(diff.TotalSeconds / c.Rate);
        c.Amount.Curr += Mathf.RoundToInt(amount * c.RateAmount);
        c.CurrTime = diff.Seconds;
    }

    public static Color UpdateCollection(bool collecting)
    {
        return collecting ? Color.white : Color.red;
    }

    public static void ChangeMenu(GameObject[] gos, int index)
    {
        for(int i = 0; i < gos.Length; i++)
        {
            gos[i].SetActive(i == index ? true : false);
        }
    }
    
}
