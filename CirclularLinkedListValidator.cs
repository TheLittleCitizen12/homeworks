using System;
using System.Collections.Generic;

namespace LinkedList
{
    public class CirclularLinkedListValidator 
    {
        public bool IsCircular<T>(LinkedList<T> linkedList)
        {
           

            Node slow = head, fast = haed;
            while(slow != null && fast != null && fast != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if(slow == fast)
                {
                    return true;
                }

            }
            false;
        }
    }
}
