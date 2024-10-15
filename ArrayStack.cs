using System;
using System.Linq;
using Lists;
using Collections;
using System.Collections.Generic;
using System.CodeDom;
using System.Runtime.InteropServices;

namespace Stacks
{
    public class ArrayStack : Stack
    {
        private object[] data;
        private int SIZE;
        private int cap;
        public ArrayStack(int cap)
        {
            this.cap = cap;
            data = new object[cap];
        }
        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public object peek()
        {
            if (isEmpty()) throw new System.MissingMemberException();
            return data[SIZE - 1];
        }

        public object pop()
        {
            object e = peek(); ; // คืนค่าข้อมูลจากตำแหน่งที่ถูกต้อง
            data[--SIZE] = null; // ลดขนาด SIZE และลบข้อมูล
            return e;
        }

        public void push(object e)
        {
            ensureCapacity();
            data[SIZE++] = e;
        }

        public int size()
        {
            return SIZE;
        }
        private void ensureCapacity()
        {
            if (SIZE + 1 > data.Length)
            {
                object[] tempdata = new object[2 * SIZE];
                for (int i = 0; i < SIZE; i++)
                    tempdata[i] = data[i];
                data = tempdata;
            }
        }
        public static bool IsCorrectParentheses(String t)
        {
            String open = "({[<";
            String close = ")}]>";
            Stack Stack = new ArrayStack(t.Length);
            if (t.Any(c => "({[<)}]>".Contains(c)))
            {
                for (int i = 0; i < t.Length; i++)
                {
                    if (open.Contains(t[i]))
                    {
                        Stack.push(t[i]);
                    }
                    else if (close.Contains(t[i]))
                    {
                        if (Stack.isEmpty() || open.IndexOf((char)Stack.peek()) != close.IndexOf(t[i]))
                        {
                            return false;
                        }
                        Stack.pop();

                    }
                }
                return Stack.isEmpty();
            }
            return false;
        }
        //    public static object ConvertInfixToPostfix(String t)
        //    {
        //        String num = "0123456789";
        //        String operate = "/*-+";
        //        List s = new ArrayList(t.Length);
        //        if (t.Any(c => "0123456789/*-+".Contains(c)))
        //        {
        //            for (int i = 0; i < t.Length; i++)
        //            {
        //                if (num.Contains(t[i]))
        //                {
        //                    s.add(t[i]);
        //                }
        //                else if (operate.Contains(t[i])) {
        //                    s.add(i+1, t[i]);
        //                    s.add(i, t[i + 1]);
        //                }

        //            }



        //        }
        //        return new string(s.ToArray());


        //    }
        public static string ConvertInfixToPostfix2(string t)
        {
            string num = "0123456789";
            string operate = "/*-+";
            List<char> s = new List<char>();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < t.Length; i++)
            {
                char c = t[i];

                if (num.Contains(c))
                {
                    s.Add(c);
                }
                else if (operate.Contains(c))
                {
                    while (stack.Count > 0 && Precedence(stack.Peek()) >= Precedence(c))
                    {
                        s.Add(stack.Pop());
                    }
                    stack.Push(c);
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        s.Add(stack.Pop());
                    }
                    stack.Pop(); // Pop the '('
                }
            }

            while (stack.Count > 0)
            {
                s.Add(stack.Pop());
            }

            return new string(s.ToArray());
        }

        private static int Precedence(char op)
        {
            switch (op)//เเยกเเยะลำดับเรื่องหมาย
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return 0;
            }
        }
        public static object CalCulated(String x)//ใช้ไม่ได้เพระามไ่ด้ฟิกค่าว่าเเต่ละลิสหรือเเสตคเก้บอะไร
        {

            char[] y = x.ToArray();
            Stack result = new LinkedStack();
            for (int i = 0; i < y.Length; i++)
            {
                if (operators.Contains(y[i].ToString()))
                {
                    object e1 = result.pop();
                    int d = int.Parse(e1.ToString());
                    object e2 = result.pop();
                    int f = int.Parse(e1.ToString());


                    int u;
                    switch (y[i])
                    {

                        case '+':
                            u = f + d;
                            result.push(u);
                            break;
                        case '-':
                            u = f - d;
                            result.push(u);

                            break;
                        case '*':
                            u = f * d;
                            result.push(u);
                            break;
                        case '/':
                            u = f / d;
                            result.push(u);
                            break;

                        case '^':
                            u = (int)Math.Pow(f, d);
                            result.push(u);
                            break;


                        default:
                            break;

                    }

                }
                else
                {
                    result.push((int)y[i]);
                }

            }


            return result.pop();

        }




        //}

        private static String operators = "+-*/^()";
        private static int[] priority = { 1, 1, 2, 2, 3 };
        private static int[] OutPriority = { 2, 2, 3, 3, 4, 5, 1 };
        private static int[] InPriority = { 2, 2, 3, 3, 4, 4, 0 };
        private static bool IsOperator(String infix)
        {
            return operators.IndexOf(infix) >= 0;
        }
        private static int inPriority(String input)
        {
            return InPriority[operators.IndexOf(input)];
        }
        private static int outPriority(String input)
        {
            return OutPriority[operators.IndexOf(input)];
        }


        //public static object Calculate2(string x)
        //{
        //    char[] y = x.ToCharArray();
        //    Stack<int> result = new Stack<int>();

        //    for (int i = 0; i < y.Length; i++)
        //    {
        //        if (operators.Contains(y[i].ToString()))
        //        {
        //            int d = result.Pop();
        //            int f = result.Pop();

        //            int u;
        //            switch (y[i])
        //            {
        //                case '+':
        //                    u = f + d;
        //                    result.Push(u);
        //                    break;
        //                case '-':
        //                    u = f - d;
        //                    result.Push(u);
        //                    break;
        //                case '*':
        //                    u = f * d;
        //                    result.Push(u);
        //                    break;
        //                case '/':
        //                    u = f / d;
        //                    result.Push(u);
        //                    break;
        //                case '^':
        //                    u = (int)Math.Pow(f, d);
        //                    result.Push(u);
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            // Convert char to int and push onto stack
        //            result.Push(y[i]);
        //        }
        //    }

        //    return result.Pop();
        //}


        public static object Calculate(string x)//ของจริง
        {
            char[] y = x.ToCharArray();
            Stack<int> result = new Stack<int>();

            for (int i = 0; i < y.Length; i++)
            {
                if (operators.Contains(y[i].ToString()))
                {
                    int d = result.Pop();
                    int f = result.Pop();

                    int u;
                    switch (y[i])
                    {
                        case '+':
                            u = f + d;
                            result.Push(u);
                            break;
                        case '-':
                            u = f - d;
                            result.Push(u);
                            break;
                        case '*':
                            u = f * d;
                            result.Push(u);
                            break;
                        case '/':
                            u = f / d;
                            result.Push(u);
                            break;
                        case '^':
                            u = (int)Math.Pow(f, d);
                            result.Push(u);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    // Convert char to int and push onto stack
                    result.Push(y[i] - '0');
                }
            }

            return result.Pop();
        }


        public static List ConvertInfixToPostfix3(List x)
        {//ของคุณเศรษฐา
            List postfix = new ArrayList(x.size());
            Stack c = new ArrayStack(x.size());
            for (int i = 0; i < x.size(); i++)
            {
                String b = (String)x.get(i);
                if (!IsOperator(b))
                {
                    postfix.add(b);
                }
                else
                {
                    int s = outPriority(b);
                    while (!c.isEmpty() && inPriority((String)c.peek()) >= s)
                    {
                        postfix.add(c.pop());
                    }
                    if (b.Equals(")"))
                    {
                        c.pop();

                    }
                    else
                    {
                        c.push(b);
                    }


                }
            }
            while (!c.isEmpty())
            {
                postfix.add(c.pop());
            }
            return postfix;


        }

        public static char[,] Maze()
        {//เป็นโจทย์
            char[,] g = { { '0','e','0','0','0','0','0','0','0','0','0','0'},
                          { '0','1','0','0','1','1','0','1','1','1','1','0'},
                          { '0','1','0','1','1','0','1','1','1','0','1','0'},
                          { '0','1','0','0','1','1','0','1','1','0','1','0'},
                          { '0','1','0','1','1','1','0','1','1','0','1','0'},
                          { '0','1','1','1','0','1','1','1','1','0','p','0'},
                          { '0','0','0','0','0','0','0','0','0','0','0','0'},

            };
            return g;
        }
        //public static char[,] SolveStep(object e)
        //{//ตำเเหน่งpในโจทย์
        //    char[,] maze = Maze();
        //    int[] goX = { -1, 1, -0, +0 };
        //    int[] goY = { -0, -0, -1, +1 };
        //    int x = 10;
        //    int y = 5;
        //    Stack ToDo = new ArrayStack(1);
        //    Stack UnDo = new ArrayStack(1);



        //    for (int t = 0; t < maze.Length; t++)
        //    {
        //        if (maze[x, y] - goX[t] != 0)
        //        {
        //            if (maze[x, y] - goY[t] != 0 && maze[x, y] != 'e')
        //            {

        //                maze[x, y] = '.';
        //                maze[x + goX[t], y + goY[t]] = 'p';
        //                ToDo.push(goY[t]);
        //                ToDo.push(goX[t]);
        //            }
        //            else
        //            {
        //                UnDo.push(goY[t]);
        //                UnDo.push(goX[t]);
        //            }


        //        }

        //    }
        //    return maze;
        //}
        public static char[,] SolveStep2(char[,]v)
        {
            char[,] maze = Maze();

            
            int[] goY = { -1, 1, 0, 0 };
            int[] goX = { 0, 0, -1, 1 }; 

            
            int x = 10; 
            int y = 5;  

            Stack ToDo = new ArrayStack(1); 
            Stack UnDo = new ArrayStack(1); 

          
            while (maze[y, x] != 'e')//problem
            {
                bool moved = false;

                for (int t = 0; t < 4; t++)
                {
                    
                    if (maze[x + goX[t], y + goY[t]] == '1' || maze[x + goX[t], y + goY[t]] == 'e')
                    {
                        
                        maze[x, y] = '.'; 
                        x += goX[t];       
                        y += goY[t];      
                        maze[x, y] = 'p';  

                        
                        ToDo.push(goX[t]);
                        ToDo.push(goY[t]);

                        moved = true;  
                        break;  
                    }
                }

                if (!moved)
                {
                    y -= (int)ToDo.pop();  
                    x -= (int)ToDo.pop();  
                }
            }

            return maze;  






        }
        //public static void DisplayMaze(char[,] maze)
        //{
        //    for (int i = 0; i < maze.GetLength(0); i++)
        //    {  
        //        for (int j = 0; j < maze.GetLength(1); j++)
        //        {  
        //            Console.Write(maze[i, j] + " ");  
        //        }
        //        Console.WriteLine(); 
        //    }
        //    Console.WriteLine(); 
        //}





    }
}