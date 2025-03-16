public class Solution {
    // TC => O(n)
    // SC => O(n)
    public IList<string> RemoveInvalidParentheses(string s) {
        if(s == null || s.Length == 0){
            return new List<string>();
        }

        Queue<string> queue = new Queue<string>();
        HashSet<string> hashset = new HashSet<string>();
        IList<string> result = new List<string>();
        bool flag = false;
        queue.Enqueue(s);
        
        while(queue.Count > 0 && !flag){
            int size = queue.Count;
            for(int i = 0; i < size; i++){
                var current = queue.Dequeue();
                if(IsValid(current)){
                    flag = true;
                    result.Add(new string(current));
                }
                else if(!flag){
                    for(int j = 0; j < current.Length; j++){
                        var child = current.Substring(0, j) + current.Substring(j+1);
                        if(hashset.Contains(child)){
                            continue;
                        }
                        hashset.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }
            if(flag){
                return result;
            }
        }
        return result;
    }

    public bool IsValid(string s){
        int count = 0;
        for(int i = 0; i< s.Length; i++){
            if(s[i] >= 'a' && s[i] <= 'z'){
                continue;
            }
            if(s[i] == '('){
                count++;
            }
            if(s[i] == ')'){
                count--;
                if(count < 0){
                    return false;
                }
            }
        }
        return count == 0;
    }
}