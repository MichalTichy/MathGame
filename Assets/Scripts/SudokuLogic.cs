using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuLogic {

    public int[,] grid = new int[4, 4] { { 0, 3, 0, 4 },
                                            { 2, 0, 0, 0 },
                                            { 0, 0, 0, 1 },
                                            { 3, 0, 4, 0 },
                                            };

    public bool Validate()
    {
        for (int i = 0; i < 4; i++)
        {
            bool[] row = new bool[4];
            bool[] col = new bool[4];

            for (int j = 0; j < 4; j++)
            {
                if (row[grid[i, j]] & grid[i, j] > 0)
                {
                    return false;
                }
                row[grid[i, j]] = true;

                if (col[grid[j, i]] & grid[j, i] > 0)
                {
                    return false;
                }
                col[grid[j, i]] = true;

                if ((i + 2) % 2 == 0 && (j + 2) % 2 == 0)
                {
                    bool[] sqr = new bool[4];
                    for (int m = i; m < i + 2; m++)
                    {
                        for (int n = j; n < j + 2; n++)
                        {
                            if (sqr[grid[m, n]] & grid[m, n] > 0)
                            {
                                return false;
                            }
                            sqr[grid[m, n]] = true;
                        }
                    }
                }

            }
        }
        return true;
    }

}
