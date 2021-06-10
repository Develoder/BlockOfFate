using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

// Статичный класс дополнительных функций
public static class Utilits 
{
    #region Целочисленное деление

    /// <summary>
    /// Делит число и выводит целую часть
    /// </summary>
    /// <param name="a">Делимое</param>
    /// <param name="b">Делитель</param>
    /// <returns>Целая часть</returns>
    public static int div(int a, int b)
    {
        return (a - a % b) / b;
    }

    /// <summary>
    /// Делит число и выводит целую часть
    /// </summary>
    /// <param name="a">Делимое</param>
    /// <param name="b">Делитель</param>
    /// <returns>Целая часть</returns>
    public static float div(float a, float b)
    {
        return (a - a % b) / b;
    }

    /// <summary>
    /// Делит число и выводит целую часть
    /// </summary>
    /// <param name="a">Делимое</param>
    /// <param name="b">Делитель</param>
    /// <returns>Целая часть</returns>
    public static double div(double a, double b)
    {
        return (a - a % b) / b;
    }
    #endregion

    /// <summary>
    /// Возведение в степень
    /// </summary>
    /// <param name="x"> Число </param>
    /// <param name="n"> Степень </param>
    /// <returns> Число в степени </returns>
    public static double Power(double x, int n)
    {
        double result = 1d;
        while (n > 0)
        {
            if ((n & 1) == 0)
            {
                x *= x;
                n >>= 1;
            }
            else
            {
                result *= x;
                --n;
            }
        }

        return result;
    }

    /// <summary>
    /// Умножение строки
    /// </summary>
    /// <param name="source"> Строка </param>
    /// <param name="repeat"> На сколько умножить </param>
    /// <returns> Умноженная строка </returns>
    public static string MultiplyString(string source, int repeat)
    {
        string multStr = "";
        for (int i = 0; i < repeat; i++)
        {
            multStr += source;
        }

        return multStr;
    }
    
    /// <summary>
    /// Проверка на подписку обработчика
    /// </summary>
    /// <param name="event">Собитие</param>
    /// <param name="eventHandler">Метод</param>
    /// <returns></returns>
    public static bool IsSubscribed(this Delegate @event, Delegate eventHandler)
    {
        return @event.GetInvocationList().Contains(eventHandler);
    }


    /// <summary>
    /// Находит случайный элемент по заданным шансам
    /// </summary>
    /// <param name="probs">Массив вероятностей выпадений элементов</param>
    /// <returns>Возвращает индекс числа</returns>
    public static int Choose(float[] probs)
    {
        float total = probs.Sum(); // Находит сумму всех шансов (не бойтесь это Linq)

        float randomPoint = UnityEngine.Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
                return i;
            
            randomPoint -= probs[i];
        }
        return probs.Length - 1;
    }
    
    /// <summary>
    /// Проверка случая  
    /// </summary>
    /// <param name="prob">Текущий шанс</param>
    /// <param name="maxPercent">100% шанс</param>
    /// <returns>Выпал ли</returns>
    public static bool Choose(float prob, float maxPercent)
    {
        float randomPoint = UnityEngine.Random.value * maxPercent;
        
        return randomPoint < prob;
    }
}
