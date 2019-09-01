using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;



namespace TEST_for_EPAM
{

    public partial class Form1 : Form
    {
        //Инициализация глобального массива
        int[] mas = new int[0];
        //Стандартное количество генерируемых элементов для генератора массива
        int sizeAutoGen = 25;
        //Счётчик
        Stopwatch sw;

        public Form1(){
            InitializeComponent();
        }
        
        //Ручной ввод массива и проверка вводимых данных
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //Ввод по нажатию ENTER
            if (Keys.Enter == e.KeyCode){
                e.Handled = true;
                e.SuppressKeyPress = true;
                //Запись элемента в текстовое поле
                if (Int32.TryParse(textBox1.Text, out int b)){
                    textBox2.Text += textBox1.Text + " ";
                    textBox1.Text = "";
                    button1.Enabled = true;
                }
                else{
                    textBox1.Text = "";
                    MessageBox.Show("Введите число");
                }               
            }
        }

        //Проверка вводимых данных и запуск выбранного алгоритма сортировки
        private void button1_Click(object sender, EventArgs e)
        {
            //Инициализация счётчика
            sw = Stopwatch.StartNew();
            //Считывание массива
            int[] mas = textBox2.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n.Trim())).ToArray();
            try {
                //Сортировка по выбранному алгоритму
                if (radioButton1.Checked) {
                    Form1.JSort.Start(mas);
                }
                else {
                    Form1.QSort.Start(mas, 0, mas.Length - 1);
                }
                textBox2.Text = "";
                //Вывод полученного массива
                for (int i = 0; i < mas.Length; i++)
                    textBox2.Text += Convert.ToString(mas[i]) + " ";
            }
            catch { MessageBox.Show("Ошибка!"); }
            //Остановка счётчика
            textBox5.Text = Convert.ToString(sw.ElapsedMilliseconds);
        }

        //Проверка вовдимых данных для алгоритма поиска
        private void textBox3_TextChanged(object sender, EventArgs e){
            if (!Int32.TryParse(textBox3.Text, out int b)){
                textBox3.Text = "";
                MessageBox.Show("Введите число");
            }
           
        }

        //Проверка вводимых данных и запуск алгоритма поиска элемента массива
        private void button2_Click(object sender, EventArgs e)
        {           
            //Проверка вводимых данных
            if (textBox3.Text != "" ){
                int key;
                //Считываем массив с текстового поля и применяем к нему алгоритм поиска
                int[] mas = textBox2.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n.Trim())).ToArray();
                if (mas.Length != 0){
                    int res = binFinder(key = Convert.ToInt32(textBox3.Text), mas);
                    //Выводим полученные результаты
                    if (res == -1){
                        MessageBox.Show("Элемент не найден");
                    }
                    else{ MessageBox.Show("Число является "+ res + "-м элементом массива"); }
                }
                else{ MessageBox.Show("Массив пуст"); }
            }
            else{
                textBox3.Text = "";
                MessageBox.Show("Введите число");
            }
        }

        //Очистка полей
        private void button3_Click(object sender, EventArgs e){
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        
        //Выходи из приложения
        public void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        //Запуск автогенерации массива
        private void автозаполнениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Инициализируем счётчик
            sw = Stopwatch.StartNew();
            textBox2.Text = "";
            Random r = new Random();
            int[] rmas = new int[sizeAutoGen];
            //Генерируем заданное количество случайных чисел и выводим их в текстовое поле
            for (int i=0; i<rmas.Length;i++){
                rmas[i] = r.Next(sizeAutoGen);
                textBox2.Text += Convert.ToString(rmas[i]) + " ";
            }
            //Останавливаем счётчик
            textBox5.Text = Convert.ToString(sw.ElapsedMilliseconds);
        }

        //Переключение между окнами
        private void дляРаботыСоСтрокамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            this.Hide();
            newForm.Show();            
        }
                
        //Проверка введенных данных и запуск алгоритма нахождения факториала
        private void button4_Click(object sender, EventArgs e)
        {
            //Проверка введенных данных
            if (textBox4.Text != "" && Int32.TryParse(textBox4.Text, out int b)){
                //Запуск алгоритма непосредственно в момент вывода сообщения
                MessageBox.Show("Факториал " + textBox4.Text + " равен: " + Convert.ToString(Factorial(Convert.ToUInt64(textBox4.Text))));
            }
            else{
                textBox4.Text = "";
                MessageBox.Show("Введите число");
            }            
        }

        //Отключение ситемных кнопок у окна работы с массивами
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        //Переключение между режимами автогенерации массива
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            sizeAutoGen = 25;
            toolStripMenuItem2.Text = "25 (выбрано)";
            toolStripMenuItem3.Text = "50";
            toolStripMenuItem4.Text = "100";
            toolStripMenuItem5.Text = "500";
        }

        //Переключение между режимами автогенерации массива
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            sizeAutoGen = 50;
            toolStripMenuItem2.Text = "25";
            toolStripMenuItem3.Text = "50 (выбрано)";
            toolStripMenuItem4.Text = "100";
            toolStripMenuItem5.Text = "500";
            
        }

        //Переключение между режимами автогенерации массива
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            sizeAutoGen = 100;
            toolStripMenuItem2.Text = "25";
            toolStripMenuItem3.Text = "50";
            toolStripMenuItem4.Text = "100 (выбрано)";
            toolStripMenuItem5.Text = "500";
        }

        //Переключение между режимами автогенерации массива
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            sizeAutoGen = 500;
            toolStripMenuItem2.Text = "25";
            toolStripMenuItem3.Text = "50";
            toolStripMenuItem4.Text = "100";
            toolStripMenuItem5.Text = "500 (выбрано)";
        }

        //Отключение кнопки "Сортировка" при пустом поле
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            { button1.Enabled = true;
            }
        }
        
        //Справка
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа разработана в целях выполнения тестового задания и включает в себя следующие функции:" +
                "\n Окно работы с массивами:" +
                "\n 1) Генерация случайного массива заданного размера;" +
                "\n 2) Ручной ввод массива;" +
                "\n 3) Сортировка массива алгоритмом Быстрой сортировки или J-сортировки;" +
                "\n 4) Нахождение позиции заданного элемента массива;" +
                "\n 5) Рассчёт факториала заданного числа;" +
                "\n 6) Очистка текстовых полей;" +
                "\n 7) Счётчик времени выполнения операций для пунктов: (1), (3), (5)" +
                "\n Окно работы со строками:" +
                "\n 1) Ручной ввод текста" +
                "\n 2) Поиск в тексте уникальных слов" +
                "\n 3) Проверка на правильность использования скобок 3-х видов: ( ), [ ], { }." +
                "\n\n Автор программы: Кондидатов Дмитрий Олегович" +
                "\n ", "Справка");
        }
    }
}


