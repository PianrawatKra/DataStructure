//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.ExceptionServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace Lists
//{
//    public class DoublyLinkedList : List
//    {

//        public LinkedList()
//        {
//            first.next = first.back = first;
//        }
//        private void addBefore(LinkedNode node, object e)
//        {
//            LinkedNode before = node.back;
//            LinkedNode here = new LinkedNode(e, node.back, node);
//            before.next = node.back = here;
//            SIZE++;
//        }
//        public void add(int index, object e)
//        {
//            addBefore(nodeAt(index), e);
//        }

//        public void add(object e)
//        {
//            addBefore(first, e);
//        }

//        public bool contains(object e)
//        {
//            throw new NotImplementedException();
//        }

//        public object get(int index)
//        {
//            throw new NotImplementedException();
//        }

//        public int indexOf(object e)
//        {
//            throw new NotImplementedException();
//        }

//        public bool isEmpty(object e)
//        {
//            throw new NotImplementedException();
//        }
//        private void removeNode(LinkedNode node)
//        {
//            LinkedNode before = node.back;
//            LinkedNode after = node.next;
//            after.back = before;
//            before.next = after;
//        }

//        public void remove(int index)
//        {
//            removeNode(nodeAt(index));
//        }

//        public void remove(object e)
//        {
//            throw new NotImplementedException();
//        }

//        public void set(int index, object e)
//        {
//            throw new NotImplementedException();
//        }

//        public int size()
//        {
//           throw new NotImplementedException();
//       }   }
