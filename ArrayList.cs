using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class ArrayList : List
    {
        private int SIZE;
        private int cap;
        private object[] data;
        public ArrayList(int cap) { 
            this.cap = cap;
            data = new object[cap];
            
        }
        private void ensure() {
            if (SIZE + 1 > data.Length) {
                object[] tempdata = new object[SIZE * 2];
                for (int i = 0; i < SIZE; i++) {
                    tempdata[i] = data[i]; }
                data = tempdata;
            }
        }
      
        public void add(int index, object e)//addตัวที่ตำเเหน่งใดๆ
        {
            ensure();
            for (int i = index; i > index; i--) {
                data[i]=data[i-1];

            }
            data[index] = e;
            SIZE++;
        }

        public void add(object e)//addตัวตำเเหน่ง=SIZE
        {
            add(SIZE, e);
        }

        public bool contains(object e)//เช๊คดูว่ามีตัวตรงกันมั้ย
        {
            return indexOf(e) != -1;
        }

        public object get(int index)
        {
            return data[index];
        }
        
        public int indexOf(object e)//หาตัวเหมือน
        {
            for (int i = 0; i < SIZE; i++)
            {
                if (data[i].Equals(e))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool isEmpty(object e)
        {
            return SIZE == 0; ;
        }

        public void remove(int index)
        {
            if (index >= SIZE) {
                return;
            }       
            for (int i = index; i < SIZE - 1; i++) { 
                     data[i]=data[i++];}
            data[--SIZE] = null;
        }

        public void remove(object e)
        {
            int i = indexOf(e);
            if (i >= 0) {
                remove(i);
            }
        }
       

        public void set(int index, object e)//setค่า
        {
            this.data[index] = e;
        }

        public int size()
        {
            return SIZE;
        }
        
        
    }
}
