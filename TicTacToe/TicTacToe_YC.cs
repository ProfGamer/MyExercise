using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    static class TicTacToe_YC
    {
        public static string OutputState(char[,] state)
        {

            List<char> l = new List<char>();
            int countO = 0;
            int countX = 0;
            int countDot = 0;
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {
                    char ch = state[i, j];
                    if (ch == 'O')
                        countO += 1;
                    else if (ch == 'X')
                        countX += 1;
                    else if (ch == '.')
                        countDot += 1;
                    l.Add(ch);
                }
            }//with this double for loop, we get all points (O X .) in a list from up to down left to right
            if (countO > countX || countX - countO > 1 || countO + countX + countDot != 9)
            {
                return "wait what";
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (l[i] == 'O' || l[i] == 'X')
                    {
                        if (l[i] == 'O' && l[i] == l[i + 3] && l[i] == l[i + 6])
                        {
                            return "O wins";
                        }
                        else if (l[i] == 'X' && l[i] == l[i + 3] && l[i] == l[i + 6])
                        {
                            return "X wins";
                        }
                    }
                }
                for (int i = 0; i < 7; i += 3)
                {
                    if (l[i] == 'O' || l[i] == 'X')
                    {
                        if (l[i] == 'O' && l[i] == l[i + 1] && l[i] == l[i + 2])
                        {
                            return "O wins";
                        }
                        else if (l[i] == 'X' && l[i] == l[i + 1] && l[i] == l[i + 2])
                        {
                            return "X wins";
                        }
                    }
                }

                if (l[4] == 'O' || l[4] == 'X')
                {
                    if ((l[0] == 'O' && l[0] == l[4] && l[0] == l[8]) || (l[2] == 'O' && l[2] == l[4] && l[2] == l[8]))
                    {
                        return "O wins";
                    }
                    else if ((l[0] == 'X' && l[0] == l[4] && l[0] == l[8]) || (l[2] == 'X' && l[2] == l[4] && l[2] == l[8]))
                    {
                        return "X wins";
                    }
                }
                if (countX > countO && countDot != 0)
                {
                    return "O turns";
                }
                else if (countX == countO && countDot != 0)
                {
                    return "X turns";
                }
                else
                {
                    return "Draw";
                }

            }

        }// 第一种方法结束 method 1 no bug
        
        public static string OutputStateMethod2(char[,] state, int tableSize)
        {

            //(y3 - y1) * (x2 - x1) - (y2 - y1) * (x3 - x1) = 0
            List<int[]> stepO = new List<int[]>();
            List<int[]> stepX = new List<int[]>();
            int countDot = 0;
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {

                    if (state[i, j] == 'O')
                    {

                        stepO.Add(new int[] { i, j });
                    }
                    else if (state[i, j] == 'X')
                    {
                        stepX.Add(new int[] { i, j });
                    }
                    else if (state[i, j] == '.')
                    {
                        countDot ++;
                    }
                }
            }
            if (stepO.Count > stepX.Count || stepX.Count - stepO.Count > 1 || stepO.Count+stepX.Count+countDot != tableSize)
            {
                return "wait what";
            }
            else if (GameEnd(stepO))
            {
                return "O won";
            }
            else if (GameEnd(stepX))
            {
                return "X won";
            }
            else if (stepO.Count < stepX.Count && stepO.Count + stepX.Count < tableSize)
            {
                return "O turns";
            }
            else if (stepO.Count == stepX.Count)
            {
                return "X turns";
            }
            else
            {
                return "Draw";
            }
        }//第二种方法 has bug

        public static string OutputStateMethod3(char[,] state,int tableSize)
        {
            List<int[]> stepO = new List<int[]>();
            List<int[]> stepX = new List<int[]>();
            List<int[]> stepOCopy = new List<int[]>();
            List<int[]> stepXCopy = new List<int[]>();
            int countDot = 0;
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1);j++)
                {

                    if (state[i, j] == 'O')
                    {

                        stepO.Add(new int[] { i, j });
                        stepOCopy.Add(new int[] { i, j });
                    }
                    else if (state[i, j] == 'X')
                    {
                        stepX.Add(new int[] { i, j });
                        stepXCopy.Add(new int[] { i, j });
                    }
                    else if (state[i, j] == '.')
                    {
                        countDot++;
                    }
                }
            }

            if (stepO.Count > stepX.Count || stepX.Count - stepO.Count > 1 || stepO.Count + stepX.Count + countDot != tableSize)
            {
                return "wait what";
            }
            else if (ThreePointALine(stepOCopy) && ThreePointALine(stepXCopy))
            {

                return "wait what";
            }
            else if (ThreePointALine(stepOCopy))
            {
                if (stepX.Count > stepO.Count)
                {
                    return "wait what";
                }
                return "O won";
            }
            else if (ThreePointALine(stepXCopy))
            {
                if (stepX.Count == stepO.Count)
                {
                    return "wait what";
                }
                return "X won";
            }
            else if (stepO.Count < stepX.Count && stepO.Count + stepX.Count < 9)
            {
                return "O turns";
            }
            else if (stepO.Count == stepX.Count)
            {
                return "X turns";
            }
            else
            {
                return "Draw";
            }
        }// methor 3 no bug
        public static string OutputStateTest(char[,] state, int tableSize)
        {
            List<int[]> stepO = new List<int[]>();
            List<int[]> stepX = new List<int[]>();
            List<int[]> stepOCopy = new List<int[]>();
            List<int[]> stepXCopy = new List<int[]>();
            int countDot = 0;
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {

                    if (state[i, j] == 'O')
                    {

                        stepO.Add(new int[] { i, j });
                        stepOCopy.Add(new int[] { i, j });
                    }
                    else if (state[i, j] == 'X')
                    {
                        stepX.Add(new int[] { i, j });
                        stepXCopy.Add(new int[] { i, j });
                    }
                    else if (state[i, j] == '.')
                    {
                        countDot++;
                    }
                }
            }

            if (stepO.Count > stepX.Count || stepX.Count - stepO.Count > 1 || stepO.Count + stepX.Count + countDot != tableSize)
            {
                return "wait what";
            }
            else if (ThreePointALine(stepOCopy))
            {
                return "O won";
            }
            else if (ThreePointALine(stepXCopy))
            {
                return "X won";
            }
            else if (stepO.Count < stepX.Count && stepO.Count + stepX.Count < tableSize)
            {
                return "O turns";
            }
            else if (stepO.Count == stepX.Count)
            {
                return "X turns";
            }
            else
            {
                return "Draw";
            }
        }// to test in bigger table

        public static bool GameEnd(List<int[]> check)
        {
            if (check.Count < 3)
            {
                return false;
            }
            else
            {
                if (check.Count == 3)
                {
                    int[] p1 = check[0];
                    int[] p2 = check[1];
                    int[] p3 = check[2];


                    if ((p3[1] - p1[1]) * (p2[0] - p1[0]) - (p2[1] - p1[1]) * (p3[0] - p1[0]) == 0)
                    {
                        return true;
                    }
                }
                else if (check.Count == 4)
                {
                    int[] p1 = check[0];
                    int[] p2 = check[1];
                    int[] p3 = check[2];
                    int[] p4 = check[3];
                    if (((p4[1] - p1[1]) * (p2[0] - p1[0]) - (p2[1] - p1[1]) * (p4[0] - p1[0]) == 0)
                            || (p4[1] - p1[1]) * (p3[0] - p1[0]) - (p3[1] - p1[1]) * (p4[0] - p1[0]) == 0
                            || (p4[1] - p2[1]) * (p3[0] - p2[0]) - (p3[1] - p2[1]) * (p4[0] - p2[0]) == 0
                       )
                    {
                        return true;
                    }
                }
                else
                {
                    int[] p1 = check[0];
                    int[] p2 = check[1];
                    int[] p3 = check[2];
                    int[] p4 = check[3];
                    int[] p5 = check[4];
                    if (
                        (p5[1] - p1[1]) * (p2[0] - p1[0]) - (p2[1] - p1[1]) * (p5[0] - p1[0]) == 0
                        || (p5[1] - p1[1]) * (p3[0] - p1[0]) - (p3[1] - p1[1]) * (p5[0] - p1[0]) == 0
                        || (p5[1] - p1[1]) * (p4[0] - p1[0]) - (p4[1] - p1[1]) * (p5[0] - p1[0]) == 0
                        || (p5[1] - p2[1]) * (p3[0] - p2[0]) - (p3[1] - p2[1]) * (p5[0] - p2[0]) == 0
                        || (p5[1] - p2[1]) * (p4[0] - p2[0]) - (p4[1] - p2[1]) * (p5[0] - p2[0]) == 0
                        || (p4[1] - p5[1]) * (p3[0] - p5[0]) - (p3[1] - p5[1]) * (p4[0] - p5[0]) == 0
                        )
                    {
                        return true;
                    }
                }
                return false;
            }
        }// not good and has bug

        //p3[1] - p1[1]) * (p2[0] - p1[0]) - (p2[1] - p1[1]) * (p3[0] - p1[0]) == 0
        public static bool ThreePointALine(List<int[]> check)
        {
            if (check.Count < 3)//when the num of points is smaller than 3, can not do the check again and return false.
            {
                return false;
            }
            /*
            I found that when we want to choose 3 point in one list:
            1. 3 point {p0,p1,p2}
                condition: -----> 1
                {p0,p1,p2}
            2. 4 points {p0,p1,p2,p3}
                condition: -----> 4 = (3+1)
                {p0,p1,p2}---->from 3 points
                
                {p0,p1,p3}    out loop 2 time inter loop 2+1 times         
                {p0,p2,p3}

                {p1,p2,p3}
            3. 5 points {p0,p1,p2,p3,p4}
                condition: -----> 10 = (6+3+1)
                {p0,p1,p2}---->from 3 points
                {p0,p1,p3}---->from 4 points
                {p0,p2,p3}---->from 4 points
                {p1,p2,p3}---->from 4 points

                {p0,p1,p4} 
                {p0,p2,p4}
                {p0,p3,p4}

                {p1,p2,p4}
                {p1,p3,p4}

                {p2,p3,p4}

            So that: for the new condition, it will first loop i times (i starts from 0  to < check.Length - 3 + 1 : 3 is how many points are in a line ) and in each i loop they will loop j in here length -2

            And in each j loop the first point will become p[i] and the second point will become p[i+k] (k starts from 1 and ++ for each j loop, then reset in each i loop)
            the 3rd point will always be p[nums of points -1], which is the new point add in the list.

            So, for each j loop we could use the formula (y3-y1)*(x2-x1)-(y2-y1)*(x3-x1) = 0 ; to test whether the 3 points are in one line.
            If we do not return true in this nums of points, we cut the last point and Recursion until the number of points is < 3;
            If all false, will return false || false || false ..... == false;
            If there are three points in one line, will return false || false || true == true and end the recursion.
            */
            int checkTime = check.Count - 3 + 1;
            for (int i = 0; i < checkTime; i++)
            {
                int k = 1;
                for (int j = check.Count-2; j > i; j--)
                {
                    
                    int[] p1 = check[i];
                    int[] p2 = check[i + k];
                    int[] p3 = check[check.Count - 1];
                    
                    if ((p3[1] - p1[1]) * (p2[0] - p1[0]) - (p2[1] - p1[1]) * (p3[0] - p1[0]) == 0)
                    {
                        //return true; //just test if three points are in a line
                        return ThreePointAdjoin(p1,p2,p3);
                    }
                    k++;
                }
            }
            check.RemoveAt(check.Count-1);
            return false || ThreePointALine(check);
        }//Three point a line
        private static bool ThreePointAdjoin(int[] p1, int[] p2, int[] p3)
        {
            if (p1[0] + p3[0] == 2 * p2[0] && p1[1] + p3[1] == 2 * p2[1])
            {
                return true;

            }
            else
            {
                return false;
            }
        
        }// three points together
        public static void XPointALine(List<int[]> check, int x)
        { 
        // the out loop -----> i loop ----->i =  1+(check.Length-x) times
        // the internal loop -----> j loop -----> 
        
        }//just some idea but not do it
    
    
    }
    
}
