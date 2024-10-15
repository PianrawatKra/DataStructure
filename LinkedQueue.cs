using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class LinkedQueue : Queues
    {
        int SIZE;

        private class LinkedNode
        {
            public object e;
            public LinkedNode next;
            public LinkedNode(object e, LinkedNode next)
            {
                this.e = e;
                this.next = next;
            }
        }
        private LinkedNode front = null;
        private LinkedNode rear = null;



        public object dequeue()
        {
            object e = front.e;
            front = front.next;
            if (front == null) {
                rear = null;
                return e; }
            return null;
        
        }

        public object enqueue(object e)
        {
            SIZE++;
            if (rear != null)
            {
                rear.next = new LinkedNode(e, null);
                rear = rear.next;
                return rear;
            }
            else {
                rear = new LinkedNode(e,null);
                front = rear;
                return front;
                
            }
         

        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public object peek()
        {
            return front;
        }

        public int size()
        {
            return SIZE;
        }
    }




}
