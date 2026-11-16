using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TimeLord_Данилова.Pages
{
    /// <summary>
    /// Логика взаимодействия для Stopwatch.xaml
    /// </summary>
    public partial class Stopwatch : Page
    {
        public DispatcherTimer dispatcherTimer = new DispatcherTimer(); // объявляем таймер
        public float full_second = 0; // прошедшее время
        public bool start_stopwatch = false; // переменная старта

        public Stopwatch()
        {
            InitializeComponent();

            dispatcherTimer.Tick += TimerSecond; // присваиваем функцию для выполнения
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1); // устанавливаем время для выполнения
        }

        /// <summary>
        /// Функция таймера для выполнения
        /// </summary>
        private void TimerSecond(object sender, EventArgs e)
        {
            full_second++; // увеличиваем пройденное время

            // выводим время на экран
            float hours = (int)(full_second / 60 / 60); // рассчитываем часы
            float minutes = (int)(full_second / 60) - (hours * 60); // рассчитываем минуты
            float seconds = full_second - (hours * 60 * 60) - (minutes * 60); // рассчитываем секунды

            string s_seconds = seconds.ToString(); // присваиваем как текст
            if (seconds < 10) s_seconds = "0" + seconds; // добавляем ноль если меньше 10

            string s_minutes = minutes.ToString(); // присваиваем как текст
            if (minutes < 10) s_minutes = "0" + minutes;

            string s_hours = hours.ToString(); // присваиваем как текст
            if (hours < 10) s_hours = "0" + hours; // добавляем ноль если меньше 10

            time.Content = s_hours + ":" + s_minutes + ":" + s_seconds; // выводим на экран
        }

        private void StartStopwatch(object sender, RoutedEventArgs e)
        {
            if (start_stopwatch == false) // если таймер не запущен
            {
                full_second = 0;
                dispatcherTimer.Start(); // запускаем таймер
                start_stopwatch = true; // запоминаем состояние
                start.Content = "Стоп"; // меняем надпись на кнопке
            }
            else
            { // если таймер запущен
                dispatcherTimer.Stop(); // останавливаем таймер
                start_stopwatch = false; // запоминаем состояние
                start.Content = "Начать"; // меняем надпись на кнопке
            }
        }
    }
}
