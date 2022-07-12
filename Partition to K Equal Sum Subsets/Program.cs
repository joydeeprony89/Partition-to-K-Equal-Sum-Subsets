using System;
using System.Linq;

namespace Partition_to_K_Equal_Sum_Subsets
{
  class Program
  {
    static void Main(string[] args)
    {
      var nums = new int[] { 5, 5, 5, 5, 4, 4, 4, 4, 3, 3, 3, 3 }; // 4, 3, 2, 3, 5, 2, 1
      int k = 4;
      Solution s = new Solution();
      var answer = s.CanPartitionKSubsets(nums, k);
      Console.WriteLine(answer);
    }
  }
  // Time -- O(k * 2^N) - 2^N for the decition tree, do we need to consider an item or not and we have to repeat this entire decision tree for k times
  // Space = O(N)
  public class Solution
  {
    public bool CanPartitionKSubsets(int[] nums, int k)
    {
      // the sum of the nums should be divisible by k
      if (nums.Sum() % k != 0) return false;
      int target = nums.Sum() / k;
      bool[] visited = new bool[nums.Length];
      Array.Sort(nums, (a, b)=> { return b - a; });
      bool BackTrack(int j, int k , int subsetSum)
      {
        // base condition 1
        if (k == 0) return true;
        // base condition 2
        if(target == subsetSum)
        {
          // reduce the k by 1 and reset subset sum 0 and start again from the begining
          return BackTrack(0, k - 1, 0);
        }

        for (int i = j; i < nums.Length; i++)
        {
          if (visited[i] || subsetSum + nums[i] > target) continue;
          visited[i] = true;
          if(BackTrack(i + 1, k, subsetSum + nums[i])) return true;
          visited[i] = false; // usual backtracking template,,we need to set to false to make the index available for later
        }

        return false;
      }

      return BackTrack(0, k, 0);
    }
  }
}
