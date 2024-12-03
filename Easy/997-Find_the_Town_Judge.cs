/*
Time Complexity O(V)
Space Complexity O(V)
*/
public class Solution {
    public int FindJudge(int n, int[][] trust) {
        //Define an array with the number of people
        int[] countTrust = new int[n+1];

        foreach(int[] t in trust)
        {
            countTrust[t[0]]--;
            countTrust[t[1]]++;

        }

        for(int i=1;i<=n;i++)
        {
            if(countTrust[i] == n-1)
            {
                return i;
            }
        }
        return -1;
    }
}