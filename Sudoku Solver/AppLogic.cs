using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Sudoku_Solver
{
    public partial class SolvePage
    {
      
        bool ArrayTest(int i, int j,int K)
        {
           int x, y, temp1, temp2;

   
            for (x = 1; x <= 9; x++) if ((ArrayA[i, x] == K) || (ArrayA[x, j] == K)) return false;

             if (i % 3 == 0) temp1 = (i / 3) - 1;
              else temp1 = i/3 ;

              if (j % 3 == 0) temp2 = (j / 3) - 1;
              else temp2= (j / 3) ;
              for (x = 1 + 3 * temp1; x <= (3 + 3 * temp1); x++)
                  for (y = 1 + 3 * temp2; y <= (3 + 3 * temp2); y++)
                      if (ArrayA[x, y] == K) return false;
            return true;
        }
     //   public int dem = 0;
        int[,] B;
        int M = 0;
        public  int T = 1;
        public void Build()
        {
            M = 0;
            B = new int[3, 1000];
            int i, j;
            T = 1;
            for (i = 1; i <= 9; i++) for (j=1;j<=9;j++) if (ArrayA[i, j] == 0)
                {
                    M++;
                    B[1, M]= i;
                    B[2, M]= j;
                }
            
        }
        public bool Continue = true;
        public void Try(int i, int j)
        {
            int k;
            if (T > M)
            {
             //   dem++;
                ArrayToButton();
                Continue = false;
            }
            else
            {
                for (k = 1; k <= 9; k++)
                {
                    if (ArrayTest(i, j, k))
                        {
                        
                        ArrayA[B[1, T], B[2, T]] = k;
  
                        T++;
                        Try(B[1,T], B[2, T]);
                        if (Continue)
                        {
                            T--;
                            ArrayA[B[1, T], B[2, T]] = 0;
                        }
                        else return;
                        
                        }
                } 
                 }
        }
        public void Solve()
        {
            Try(B[1, T], B[2, T]);
        }
    }
}