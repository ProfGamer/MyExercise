using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] state1 =
                    {
            { 'O','.','X'},
            { 'O','.','X'},
            { '.','.','X'}
            };
            char[,] state2 =
        {
            { 'O','.','X'},
            { '.','O','X'},
            { '.','.','.'}
            };
            char[,] state3 =
        {
            { 'O','.','X'},
            { '.','O','X'},
            { '.','.','O'}
            };
            char[,] state4 =
{
            { 'O','X','O'},
            { 'X','O','X'},
            { 'X','O','X'}
            };
            char[,] state5 =
{
            { 'X','O','O'},
            { 'X','X','O'},
            { 'X','O','X'}
            };
            char[,] state6 =
{
            { 'O','X','O'},
            { 'X','X','O'},
            { 'X','.','O'}
            };

            char[,] state7 =
{
            { '.','.','X','X','.'},
            { '.','.','O','O','.'},
            { '.','O','X','X','O'},
            { 'X','.','X','X','.'},
            { 'O','.','O','O','.'}
            };// in this case, even both X & O have 3 points in a line, it will not show who wins but X turn;

            char[,] state8 =
{
            { 'O','.','X'},
            { 'O','X','.'},
            { 'X','O','.'}
            };
            char[,] state9 =
{
            { 'O','X','.'},
            { 'O','X','X'},
            { 'O','.','X'}
            };
            char[,] state10 =
{
            { 'O','X','.'},
            { 'O','X','.'},
            { 'O','X','.'}
            };
            //Console.WriteLine(TicTacToe_YC.OutputStateTest(state7, 25));
            //Console.WriteLine();

            Console.WriteLine(TicTacToe_YC.OutputStateMethod3(state8, 9));
            Console.WriteLine(TicTacToe_YC.OutputStateMethod3(state9, 9));
            Console.WriteLine(TicTacToe_YC.OutputStateMethod3(state10, 9));
            
            //Console.WriteLine(TicTacToe_YC.OutputState(state1));
            //Console.WriteLine(TicTacToe_YC.OutputState(state2));
            //Console.WriteLine(TicTacToe_YC.OutputState(state3));
            //Console.WriteLine(TicTacToe_YC.OutputState(state4));
            //Console.WriteLine(TicTacToe_YC.OutputState(state5));
            //Console.WriteLine(TicTacToe_YC.OutputState(state6));
            //Console.WriteLine();

            //Console.WriteLine(TicTacToe_YC.OutputStateMethod2(state1,9));
            //Console.WriteLine(TicTacToe_YC.OutputStateMethod2(state2,9));
            //Console.WriteLine(TicTacToe_YC.OutputStateMethod2(state3,9));
            //Console.WriteLine(TicTacToe_YC.OutputStateMethod2(state4,9));
            //Console.WriteLine(TicTacToe_YC.OutputStateMethod2(state5,9));
            //Console.WriteLine(TicTacToe_YC.OutputStateMethod2(state6,9));
            //Console.WriteLine();

            //Console.WriteLine(TicTacToe_YC.OutputStateMethod3(state1,9));
            //Console.WriteLine(TicTacToe_YC.OutputStateMethod3(state2,9));
            //Console.WriteLine(TicTacToe_YC.OutputStateMethod3(state3,9));
            //Console.WriteLine(TicTacToe_YC.OutputStateMethod3(state4,9));
            //Console.WriteLine(TicTacToe_YC.OutputStateMethod3(state5,9));
            //Console.WriteLine(TicTacToe_YC.OutputStateMethod3(state6,9));
        }
    }
}
