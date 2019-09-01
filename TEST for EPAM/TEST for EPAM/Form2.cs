using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST_for_EPAM
{
    public partial class Form2 : Form
    {
        //Связывание формы 1 и формы 2 для реализации возможности переключения между ними
        public Form2(Form1 f1)
        {
            InitializeComponent();
            this.f1= f1;
        }
        private Form f1;
                
        //Кнопка выхода
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Переключение на окно работы с массивами
        private void дляРаботыСМассивамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            f1.Show();               
        }

        //Отключение стандартных кнопок управления окном при загрузке формы 
        private void Form2_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        //Запуск алгоритма поиска уникальных слов и проверка вводимых данных
        private void button2_Click(object sender, EventArgs e)
        {
            //Проверка вводимых данных
            if (textBox1.Text != ""){
                //Если поле не пусто, то запуск алгоритма.
                //Вывод результата осуществляется сразу в textBox2.
                string a = textBox1.Text;
                textBox2.Text = Form1.finder(a);
            }
            else{                
                MessageBox.Show("Введите текст");
            }
        }
        
        //Запуск алгоритма анализа установленных скобок и проверка вводимых данных
        private void button1_Click(object sender, EventArgs e)
        {
            //Проверка вводимых данных
            if (textBox1.Text == ""){
                MessageBox.Show("Введите текст");
            }
            else{
                //Если поле не пусто, то запуск алгоритма и вывод результата
                int res = Form1.checker(textBox1.Text);
                //1 - скобки использовались и расставлены верно
                //0 - скобки не использовались
                //-1 - скобки использовались и расставлены не верно
                if (res==1){
                    MessageBox.Show("Скобки расставлены верно");                  
                }
                else{
                    if (res==-1)
                    MessageBox.Show("Скобки расставлены не верно");
                    else{
                        MessageBox.Show("Скобки не использовались");
                    }
                }
            }
               
        }

        //Очистка текстовых полей
        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
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
