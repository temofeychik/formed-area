using System;

int[,]? matrix = null;
int Xcount = 0;
int Ycount = 0;

while (matrix == null)
{
    Console.WriteLine("Please enter a matrix accepts of values 0 and 1.");
    Console.WriteLine("The matrix is presented as a string value where ‘,’ is used as a separator for columns, ‘;’ is used as a separator for rows.");
    string? matrixInput = Console.ReadLine();
    matrix = ParseMatrix(matrixInput);
}

Console.WriteLine($"Number of areas formed of number 1 is - {FindPerimeter(matrix)}");
Console.ReadLine();

int[,]? ParseMatrix(string? matrixInput)
{
    try
    {
        int[,]? tempMatrix = null; 
        if (!string.IsNullOrEmpty(matrixInput))
        {
            string[] Xvalues = (matrixInput.Split(';'));
            Xcount = Xvalues.Length;
            Ycount = (Xvalues[0].Split(',')).Length;
            tempMatrix = new int[Xcount, Ycount];

            for (int i = 0; i < Xcount; i++)
            {
                string[] Yvalues = Xvalues[i].Split(',');
                for (int j = 0; j < Ycount; j++)
                {
                    int value = int.Parse(Yvalues[j]);
                    if (value != 0 && value != 1)
                    {
                        Console.WriteLine("matrix accepts of values 0 and 1");
                        return null;
                    }
                    tempMatrix[i, j] = value;
                }
            }
            return tempMatrix;
        }
        return null;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Parsing error - {ex.Message}");
        return null;
    }
}


int countArea(int x, int y)
{
    if ((x < 0) || (x >= Ycount) || (y < 0) || (y >= Xcount) || (matrix[y, x] == 0))
    {
        return 0;
    }

    matrix[y,x] = 0;

    return 1 + countArea(x - 1, y) + countArea(x + 1, y) + countArea(x, y - 1) + countArea(x, y + 1);
}

int FindPerimeter(int[,] mat)
{
    int areas = 0;

    for (int i = 0; i < Ycount; ++i)
    {
        for (int j = 0; j < Xcount; ++j)
        {
            if (matrix[j,i] == 1)
            {
                if (countArea(i, j) > 0)
                {
                    areas++;
                }
            }
        }
    }

    return areas;
}