using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ลองน๊ะจ๊ะอย่าพึ่งทำตาม
namespace Queues
{
    public class ArrayListQueue3 : Queues
    {
        private object[] data;
        private int cap;
        private int SIZE=0;
        private int front=0;
        private int rear = 0;




        public  ArrayListQueue3(int cap) {
            data = new object[cap];
            this.cap = cap;
            front = 0;
            SIZE= 0;
            rear = 0;



        }
        public object dequeue()
        {
            object e = data[front];
            data[front] = null;
            front++;
            if (front == data.Length) {
                front =0;
            }
            return data;

        }

        public object enqueue(object e)
        {
            data[rear] = e;
            rear++;
            SIZE++;
            if (rear == data.Length) {
                rear = 0;
            }
            return data;
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public object peek()
        {
            return data[front];
        }

        public int size()
        {
            return SIZE;
        }
    }
}
