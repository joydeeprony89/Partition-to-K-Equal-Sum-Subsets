using System;
using System.Linq;

namespace Partition_to_K_Equal_Sum_Subsets
{
  class Program
  {
    static void Main(string[] args)
    {
      var nums = new int[] { 4, 3, 2, 3, 5, 2, 1 }; //  //  5, 5, 5, 5, 4, 4, 4, 4, 3, 3, 3, 3
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
      var sum = nums.Sum();
      if (sum % k != 0) return false;

      int target = sum / k;
      var visited = new bool[nums.Length];
      return Backtrack(nums, k, 0, 0, target, visited);
    }

    private bool Backtrack(int[] nums, int k, int start, int sum, int target, bool[] visited)
    {
      if (k == 0) return true;
      if (sum == target)
      {
        return Backtrack(nums, k - 1, 0, 0, target, visited);
      }

      for (int i = start; i < nums.Length; i++)
      {
        if (visited[i] || sum + nums[i] > target) continue;
        visited[i] = true;
        if (Backtrack(nums, k, i + 1, sum + nums[i], target, visited)) return true;
        visited[i] = false;
      }

      return false;
    }
  }
}
