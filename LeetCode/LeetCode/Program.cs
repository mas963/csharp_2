namespace LeetCode;

class Program
{
    static void Main(string[] args)
    {

    }

    // 1. Two Sum
    public int[] TwoSum(int[] nums, int target)
    {
        // [2,7,11,15], target = 9
        int[] result = new int[2];
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target && !(i == j))
                {
                    result[0] = i;
                    result[1] = j;
                    return result;
                }
            }
        }

        return result;
    }


    // 2. Add Two Numbers
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {

    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}