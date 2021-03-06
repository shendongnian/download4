        public static List<List<int>> GetLists(int[] nums) { 
            List<List<int>> lists = new List<List<int>>();
            List<int> list = new List<int>();
            lists.Add(list);
            if (nums.Length == 0) {
                return lists;
            }
            list.Add(nums[0]);
            if (nums.Length == 1) {
                return lists;
            }
            list.Add(nums[1]);
            if (nums.Length == 2) {
                return lists;
            }
            bool direction = nums[2] < nums[1];
            for (int i = 2; i < nums.Length; i++) {
                if (nums[i] < nums[i - 1] == direction)
                    list.Add(nums[i]);
                else {
                    direction = !direction;
                    list = new List<int>();
                    list.Add(nums[i]);
                    lists.Add(list);
                }
            }
            return lists;
        }
        static void Main(string[] args)
        {
            int[] nums = new int[] {1,2,3,6,5,3,1,2,5};
            var lists = GetLists(nums);
            foreach (var list in lists) {
                foreach (var item in list)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
         }
