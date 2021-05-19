using System;

namespace Lab2.Folder
{
    class Chess
    {
        private static int Size = 8; //размер поля
        private static int[,] ChessField = new int[Size, Size]; //матрица представляющая поле
        private static int QuantityFerz = 8; //количество нужных ферзей

        private void CreateChessField() // заполнение матрицы, где 0 - пустые клетки
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    ChessField[i, j] = 0;
                }
            }
        }

        private bool Prov(int indexX, int indexY) // проверка, чтоб не выйти за границы игрового поля
        {
            if (indexX > 7 || indexX < 0 || indexY > 7 || indexY < 0)
                return false;
            else return true;

        }


        //добавление нового ферзя на поле, при этом клетки по диагоналя,вертикалям,горизонталям заполняются двойками
        //это значит, что на эти клетки нельзя постаить другого ферзя
        private void AddFerz(int indexX, int indexY)
        {
            for (int i = 0; i < Size; i++)
            {
                if (i != indexX)
                {
                    ChessField[i, indexY] = 2;
                }
            }

            for (int j = 0; j < Size; j++)
            {
                if (j != indexY)
                {
                    ChessField[indexX, j] = 2;
                }
            }

            int indexX1 = indexX;
            int indexY1 = indexY;


            for (int i = indexX1 + 1; i < Size; i++)
            {
                if (Prov(i, indexY1 + 1))
                    ChessField[i, indexY1 = indexY1 + 1] = 2;
                else break;
            }

            indexX1 = indexX;
            indexY1 = indexY;

            for (int i = indexX1 - 1; i >= 0; i--)
            {
                indexY1 = indexY1 - 1;
                if (Prov(i, indexY1))
                {

                    ChessField[i, indexY1] = 2;

                }
                else break;
            }

            indexX1 = indexX;
            indexY1 = indexY;

            for (int i = indexY1 - 1; i >= 0; i--)
            {
                indexX1 = indexX1 + 1;
                if (Prov(indexX1, i))
                {

                    ChessField[indexX1, i] = 2;

                }
                else break;
            }

            indexX1 = indexX;
            indexY1 = indexY;


            for (int i = indexY1 + 1; i < Size; i++)
            {
                indexX1 = indexX1 - 1;
                if (Prov(indexX1, i))
                {
                    ChessField[indexX1, i] = 2;
                }
                else break;
            }

        }

        private void PrintMatrix()// функция для выводв игрового поля на экран
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(ChessField[i, j] + " ");
                }
                Console.Write("\r\n");
            }
        }


        private bool FindPlace()//нахождение свободного места для нового ферзя(там где нет 1 или 2, пустые места отмечены нулем)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (ChessField[i, j] == 0)
                    {
                        ChessField[i, j] = 1;
                        AddFerz(i, j);
                        return true;
                    }
                }
            }
            return false;
        }

        private void DelateTwo()//удаление всех 2 с поля перед выводом матрицы,для наглядности
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (ChessField[i, j] == 2)
                    {
                        ChessField[i, j] = 0;
                    }
                }
            }
        }

        public void Arrange()// расстановка ферзей
        {

            while (true)
            {
                CreateChessField();//создание игрового поля
                                   //генерируем позицию первого ферзя
                Random rand = new Random();
                int indexX = rand.Next(0, 8);
                int indexY = rand.Next(0, 8);
                //ставим его на поле как единицу
                ChessField[indexX, indexY] = 1;
                //заполняем все недступные места для будущих ферзей
                AddFerz(indexX, indexY);

                int count = 0;
                //ищем места для остальных ферзей

                for (int i = 0; i < QuantityFerz; i++)
                {
                    count++;
                    if (!FindPlace()) break;
                }
                //если все цспешно расставлены то выходим из цикла
                if (count == QuantityFerz) break;
                //если расставлены не все ферзи то делаем все заново
            }
            //когда найдена расстановка ферзей, удаляем все 2 и выводим матрицу
            DelateTwo();
            PrintMatrix();
        }
    }
}