using UnityEngine;

namespace OutOfTheBreach
{
    public static class RandomLibrary
    {
        //**Add Random algo*/
        //rate: Array of probability (%), total£ºtotal probability (100%)
        // Debug.Log(rand(new int[] { 10, 5, 15, 20, 30, 5, 5,10 }, 100));
        // 10%: 0, 5%: 1, 15%: 2...
        public static int randAdd(int[] rate, int total)
        {
            int r  = Random.Range(1, total + 1);
            int t = 0;
            for (int i = 0; i < rate.Length; i++)
            {
                t += rate[i];
                if (r < t)
                {
                    return i;
                }
            }
            return 0;
        }

        /**Sub Random algo*/
        //rate: Array of probability (%), total£ºtotal probability (100%)
        // Debug.Log(randRate(new int[] { 10, 5, 15, 20, 30, 5, 5,10 }, 100));
        // 10%: 0, 5%: 1, 15%: 2...
        public static int randSub(int[] rate, int total)
        {
            int rand = Random.Range(0, total + 1);
            for (int i = 0; i < rate.Length; i++)
            {
                rand -= rate[i];
                if (rand <= 0)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
