
namespace Homework5
{
    class Matrix
    {
        public void OutputMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0); // количество строк
            int columns = matrix.GetLength(1); // количество столбцов

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public int[,] MultiplyMatrix(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException();
            }

            int rowsOfFirst = matrix1.GetLength(0); // количество строк первой матрицы
            int columnsOfFirst = matrix1.GetLength(1); // количество столбцов первой матрицы 

            int rowsOfSecond = matrix2.GetLength(0); // количество строк второй матрицы
            int columnsOfSecond = matrix2.GetLength(1); // количество столбцов второй матрицы 

            if (columnsOfFirst != rowsOfSecond)
            {
                throw new ArgumentException("Невозможно перемножить матрицы, т.к. не выполняется условие (количество столбцов первой матрицы равно количеству строк второй!)");
            }

            int[,] resultMatrix = new int[rowsOfFirst, columnsOfSecond];

            for (int i = 0; i < rowsOfFirst; i++)
            {
                for (int j = 0; j < columnsOfSecond; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < columnsOfFirst; k++)
                        sum += matrix1[i, k] * matrix2[k, j];

                    resultMatrix[i, j] = sum;
                }
            }

            return resultMatrix;
        }
    }
}
