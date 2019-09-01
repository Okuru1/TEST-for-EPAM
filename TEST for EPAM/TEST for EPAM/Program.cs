using System;
using System.Windows.Forms;

namespace TEST_for_EPAM
{

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    partial class Form1
    {
        //Алгоритм J-сортировки
        public class JSort
        {
            ///<summary>
            ///Автор алгоритма: Джейсон Моррисон(Jason Morrison)
            ///Название: Jsort (J-сортировка)
            ///Гибридная сортировка (кучей + вставками)
            ///Устойчивость: Неустойчивая
            ///Временная сложность:	
            ///             лучшая	             O(n); 
            ///             средняя                  ?; 
            ///             худшая               O(n^2).
            ///Сложность по памяти:
            ///             всего                 O(n);
            ///             дополнительные данные O(1).
            ///</summary>        

            //Строим НЕубывающую кучу
            private static void ReHeap(int[] a, int length, int i)
            {
                bool done = false;
                int T = a[i];
                int parent = i;
                int child = 2 * (i + 1) - 1;
                //Пока не дошли до конца массива и не выполнено условие 
                while ((child < length) && (!done)){
                    if (child < length - 1){
                        //Если предыдущий элемент больше последующего двигаемся дальше
                        if (a[child] >= a[child + 1]){
                            child++;
                        }
                    }
                    //Если все дети больше родителя, то цикл окончен
                    if (T < a[child]){
                        done = true;
                    }
                    //Если родитель больше ребенка, то производим замену
                    else{
                        a[parent] = a[child];
                        parent = child;
                        child = 2 * (parent + 1) - 1;
                    }
                }
                //Родитель меньший элемент
                a[parent] = T;
            }

            //Строим НЕвозрастающую кучу
            private static void InvrHeap(int[] a, int length, int i)
            {
                bool done = false;
                int T = a[length - 1 - i];
                int parent = i;
                int child = 2 * (i + 1) - 1;
                //Пока не дошли до конца массива и не выполнено условие 
                while ((child < length) && !done){
                    if (child < length - 1){
                        //Движемся с конца массива
                        if (a[length - 1 - child] <= a[length - 1 - (child + 1)]){
                            child++;
                        }
                    }
                    //Если все дети меньше родителя, то завершаем цикл
                    if (T > a[length - 1 - child]){
                        done = true;
                    }
                    //Если ребёнок больше родителя производим замену
                    else{
                        a[length - 1 - parent] = a[length - 1 - child];
                        parent = child;
                        child = 2 * (parent + 1) - 1;
                    }
                }
                a[length - 1 - parent] = T;
            }

            public static void Start(int[] a)
            {
                //Строим неубывающую кучу
                //Большие элементы из начала массива 
                //Размещаем ближе к концу массива
                for (int i = a.Length - 1; i >= 0; i--)
                    ReHeap(a, a.Length, i);
                //Строим невозрастающую кучу
                //Меньшие элементы из конца массива
                //Размещаем ближе к началу массива
                for (int i = a.Length - 1; i >= 0; i--)
                    InvrHeap(a, a.Length, i);
                //Заканчиваем сортировку вставками
                for (int j = 1; j < a.Length; j++)
                {
                    int T = a[j];
                    int i = j - 1;
                    while (i >= 0 && a[i] > T)
                    {
                        a[i + 1] = a[i];
                        i--;
                    }
                    a[i + 1] = T;
                }
            }
        };

        //Алгоритм быстрой сортировки
        public class QSort
        {
            //Разделение исходного массива на подмассивы и их сортировка
            private static int partition(int[] array, int start, int end)
            {
                int temp;
                int marker = start;
                for (int i = start; i < end; i++){
                    if (array[i] < array[end]){
                        temp = array[marker];
                        array[marker] = array[i];
                        array[i] = temp;
                        marker++;
                    }
                }
                temp = array[marker];
                array[marker] = array[end];
                array[end] = temp;
                return marker;
            }

            //Старт рекурсии с заданными параметрами
            public static void Start(int[] array, int start, int end)
            {
                if (start >= end){
                    return;
                }
                int pivot = partition(array, start, end);
                Start(array, start, pivot - 1);
                Start(array, pivot + 1, end);
            }
        }

        //Алгоритм бинарного поиска
        public static int binFinder(int b, int[] a)
        {
            int k;
            int L = 0;        // Левая граница
            int R = a.Length - 1;    // Лравая граница
            k = (R + L) / 2;
            while (L < R - 1){
                k = (R + L) / 2;
                if (a[k] == b)
                    return k; // Остановка цикла, число найдено
                if (a[k] < b)
                    L = k;
                else
                    R = k;
            }
            if (a[k] != b){
                if (a[L] == b)
                    k = L;
                else {
                    if (a[R] == b)
                        k = R;
                    else
                        k = -1;
                };
            }
            return k;
        }

        //Функция вычисления факториала
        public static ulong Factorial(ulong k)
        {
            if (k == 1) return 1;
            return k * Factorial(k - 1);
        }

        //Алгоритм поиска уникальных слов
        public static string finder(string a)
        {
            //Разделение заданной строки на слова
            string[] separator = { ",", ".", " " };
            string[] strlist = a.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //Сортировка слов алгоритмом из библиотеки
            Array.Sort(strlist);
            a = strlist[0] + " ";
            //Сравнение слов и вывод результата
            for (int i = 1; i < strlist.Length; i++){
                if (strlist[i] != strlist[i - 1]){
                    a += strlist[i] + " ";
                }

            }
            return a;
        }

        //Моя собственная идея решения задачи
        //по анализу правильности постановки скобок в тексте
        public static int checker(string a)
        {
            int m = 0, b = 0, g = 0, size = 0;
            char[] ch = new char[100];
            var skb = new[] { '(', ')', '[', ']', '{', '}' };
            bool done ;
            //Ищем в строке скобки
            foreach (char r in a){
                done = false;
                //Каждый символ сравниваем с набором скобок
                foreach (char c in skb){
                    //Если скобка ещё не найдена, то продолжаем цикл
                    if (!done){
                        if (r == c){
                            //Каждую скобку записываем в массив
                            ch[size] = r;
                            size++;
                            done = true;
                            //Для каждого набора скобок ведём счётчики и проверяем на ошибку в их постановке по типу "( ]" и т.п.
                            //Если встречается подобная ошибка, то процедура завершается с соответствующим сообщением
                            if (c == '(') { m++; continue; }                           
                            if (c == ')'&&(ch[size-2] == '[' || ch[size - 2] == '{')){
                                return -1;
                            }
                            else{
                                if (c==')') { m--; continue; }
                            }
                            if (c == '[') { b++; continue; }
                            if (c == ']' && (ch[size - 2] == '(' || ch[size - 2] == '{')){
                                return -1;
                            }
                            else{
                                if (c == ']') { b--; continue; }
                            }                            
                            if (c == '{') { g++; continue; }
                            if (c == '}' && (ch[size - 2] == '[' || ch[size - 2] == '(')){
                                return -1;
                            }
                            else{
                                if (c == '}') { g--; continue; }
                            }                          
                        }
                    }
                    else { break; }                    
                }
            }
            //Если скобок нет выводим 0
            if (size == 0){
                return 0;
            }
            //Если скобки есть выводим 1
            else{
                if (m == b && b == g && g == 0){
                    return 1;
                }
                //Если скобки введены неверно выводим 0
                else {
                    return -1;
                }
            }
        }
    }
}


