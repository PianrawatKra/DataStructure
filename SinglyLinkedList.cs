using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Collections;

namespace Lists
{
    public class SinglyLinkedList : List
    {
        private class LinkedNode {
            public object e;
            public LinkedNode next;
            public LinkedNode(object e, LinkedNode next)
            {
                this.e = e;
                this.next = next;
            }
        }
        private LinkedNode first = new LinkedNode(null, null);
        private int SIZE;
 
        private LinkedNode NodeAt(int index) {
            LinkedNode node = first;
            for (int i = -1; i < index; i++) { 
                node = node.next;
            }
            return node;
        }
        private void removeAfter(LinkedNode node) {
            if (node.next!=null) { 
                node.next=node.next.next;
                SIZE--;
            }
        }

        public void add(int index, object e)
        {
            if (index <= SIZE)
            {
                LinkedNode node = NodeAt(index - 1);
                node.next = new LinkedNode(e, node.next);
                SIZE++;
            }


        }

        public void add(object e)
        {
            add(SIZE, e);
        }

        public bool contains(object e)
        {
            if (indexOf(e) != -1)
            {
                return true;
            }
            return false;
        }

        public object get(int index)
        {
            return NodeAt(index).e;
        }

        public int indexOf(object e)
        {
            LinkedNode node = first;
            int index = 0;
            while (node.next != null)
            {
                if (node.next.e.Equals(e))
                {
                    return index;
                }
                node = node.next;
                index++;
            }
            return -1;
        }

        public bool isEmpty(object e)
        {
            return first.next == null;
        }

        public void remove(int index)
        {
            LinkedNode node = NodeAt(index - 1);
            removeAfter(node);


        }

        /*public void remove(object e)
        {
            int i = indexOf(e);
            remove(i);--
        }*/
        public void remove(object e) {
            LinkedNode node = first;
            if (indexOf(e) != -1)
            {
                if (SIZE > 1)
                {
                    removeAfter(node.next);
                }
                else {
                    removeAfter(node);
                }
            }
        }

        public void set(int index, object e)
        {
            NodeAt(index).e = e;
        }

        public int size()
        {
            return SIZE;
        }

        int List.indexOf(object e)
        {
            LinkedNode node = first;
            int index = 0;
            while (node.next != null)
            {
                if (node.next.e.Equals(e))
                {
                    return index;
                }
                node = node.next;
                index++;
            }
            return -1;
        }
    }
}
