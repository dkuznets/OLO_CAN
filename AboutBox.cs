using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace OLO_CAN
{
	partial class AboutBox : Form
	{
		int sw = 0;
        #region Комментарий

        public String comment =
                        "v.1.4.3.201" + "\r\n" +
                        " - Вроде как все работает." + "\r\n" +
                        "v.1.4.3.194" + "\r\n" +
                        " - Пока не работает замена файла." + "\r\n" +
                        "v.1.4.2.185" + "\r\n" +
                        " - Пока не работает замена файла и проверка." + "\r\n" +
                        "v.1.4.1.180" + "\r\n" +
                        " - Попытка добавить новый протокол РУП удалась." + "\r\n" +
                        "v.1.4.0.173" + "\r\n" +
                        " - Попытка добавить новый протокол РУП." + "\r\n" +
                        "v.1.3.3.169" + "\r\n" +
                        " - Добавлена новая прошивка SELECT_LONG_TIME_V2." + "\r\n" +
                        "v.1.3.2.168" + "\r\n" +
                        " - Добавлено автоматическое сохранение скриншотов." + "\r\n" +
                        "v.1.3.1.163" + "\r\n" +
                        " - Добавлены запрос и сохранение серийного номера при юстировке. Работает на прошивке SELECT_LONG_TIME_V2.bin)." + "\r\n" +
                        "v.1.3.1.158" + "\r\n" +
                        " - Добавлены запрос и сохранение серийного номера при юстировке (заработает после переделки прошивок ОЛО)." + "\r\n" +
                        "v.1.3.0.155" + "\r\n" +
                        " - Добавлена вкладка с настройками." + "\r\n" +
                        "v.1.2.2.151" + "\r\n" +
                        " - Добавлены тесты загрузки ПЛИС." + "\r\n" +
                        "v.1.2.1.147" + "\r\n" +
                        " - Добавлены запрос и сохранение серийного номера." + "\r\n" +
                        "v.1.2.0.144" + "\r\n" +
                        " - Статусы систем ОЛО переехали в байт 2" + "\r\n" +
                        " - Статусы самотестирования выдаются в байтах 6 и 7" + "\r\n" +
                        "v.1.2.0.141" + "\r\n" +
                        " - NET Framework 4.0" + "\r\n" +
                        "v.1.1.4.141" + "\r\n" +
                        " - Добавлен вывод результатов встроенного контроля." + "\r\n" +
                        " - Убраны варианты загрузки. Навсегда. А может, и нет." + "\r\n" +
                        "v.1.1.3.135" + "\r\n" +
                        " - Переделана загрузка по старому алгоритму. Работает. Больше ее не трогаю." + "\r\n" +
                        "v.1.1.2.121" + "\r\n" +
                        " - Массовые доработки теста ОЛО и переход на новый протокол." + "\r\n" +
                        "v.1.1.0.106" + "\r\n" +
                        " - Попытка переделать CANSET." + "\r\n" +
                        "v.1.0.15.103" + "\r\n" +
                        " - Пофиксен косяк с CAN." + "\r\n" +
                        "v.1.0.15.102" + "\r\n" +
                        " - Добавлен режим автоматических выстрелов в эмуляторе." + "\r\n" +
                        " - Добавлено изменение частоты выстрелов в эмуляторе." + "\r\n" +
                        "v.1.0.14.96" + "\r\n" +
                        " - Пофиксен косяк с эмуляцией выстрелов. Опять виноват Верещагин." + "\r\n" +
                        "v.1.0.14.95" + "\r\n" +
                        " - Пофиксен косяк с отображением выстрелов." + "\r\n" +
                        "v.1.0.14.94" + "\r\n" +
                        " - Найден и пофиксен косяк с запуском программы при отсутствии CAN." + "\r\n" +
                        " - Найден косяк с отображением выстрелов в эмуляции и тестировании." + "\r\n" +
                        " - Добавлена запись лога при тестиротвании." + "\r\n" +
                        "v.1.0.13.90" + "\r\n" +
                        " - Тест Д21 работает полностью. Д13 и Д19 только шина данных. После использования необходимо передернуть питание." + "\r\n" +
                        "v.1.0.13.87" + "\r\n" +
                        " - Добавлены тесты шин данных и адреса под 31 версию прошивки." + "\r\n" +
                        "v.1.0.12.82" + "\r\n" +
                        " - Зум работает." + "\r\n" +
                        "v.1.0.12.80" + "\r\n" +
                        " - Найден и пофиксен косяк с сохранением конфига." + "\r\n" +
                        " - Найден косяк с зумом. Работаем..." + "\r\n" +
                        "v.1.0.12.79" + "\r\n" +
                        " - Добавлен Тест 5 для D21." + "\r\n" +
                        "v.1.0.11.78" + "\r\n" +
                        " - Найден и пофиксен косяк с видео в Юстировке" + "\r\n" +
                        "v.1.0.10.75" + "\r\n" +
                        " - В тестировании изменены тесты D13 и D19." + "\r\n" +
                        "v.1.0.9.73" + "\r\n" +
                        " - Добавлена возможность прошивки ОЛО по адресу (в соответствии с протоколом)." + "\r\n" +
                        "v.1.0.8.72" + "\r\n" +
                        " - Заработало!" + "\r\n" +
                        " - Имеются глюки все еще :(." + "\r\n" +
                        "v.1.0.8.69" + "\r\n" +
                        " - Заработал режим широковещательных запросов в OLO_Emu." + "\r\n" +
                        " - Имеются глюки :(." + "\r\n" +
                        "v.1.0.7.65" + "\r\n" +
                        " - Заработал режим широковещательных запросов в OLO_Test." + "\r\n" +
                        " - Широковещательные запросы OLO_Emu пока не понимает :(." + "\r\n" +
                        " - Убрана проверка повторного запуска приложения." + "\r\n" +
                        "v.1.0.6.63" + "\r\n" +
                        " - Исправлена ошибка с выстрелами в эмуляторе." + "\r\n" +
                        "v.1.0.6.62" + "\r\n" +
                        " - Функции OLO_CANTest работают." + "\r\n" +
                        " - Исправлено несколько косяков." + "\r\n" +
                        " - В эмуляторе добавлена панелька с тракбарами для выстрелов." + "\r\n" +
                        " - Исправлен косяк OLO_CANSet c сохранением паспорта." + "\r\n" +
                        "v.1.0.4.31" + "\r\n" +
                        " - Функции OLO_Emu работают." + "\r\n" +
                        "v.1.0.3.24" + "\r\n" +
                        " - Функции OLO_Test работают." + "\r\n" +
                        " - Пока не формируются широковещательные запросы." + "\r\n" +
                        "v.1.0.2.15" + "\r\n" +
                        " - Функции OLO_CANBoot работают." + "\r\n" +
                        "v.1.0.1.12" + "\r\n" +
                        " - Функции OLO_CANSet работают." + "\r\n" +
                        "v.1.0.0.7" + "\r\n" +
                        " - Не работает ничего." + "\r\n" +
                        "v.1.0.0.0" + "\r\n" +
                        " - Не работает ничего." + "\r\n" +
                        "";
        #endregion
		public AboutBox()
		{
			InitializeComponent();
			this.Text = String.Format("О программе {0}", AssemblyTitle);
			this.labelProductName.Text = AssemblyProduct;
			this.labelVersion.Text = String.Format("Версия {0}", AssemblyVersion);
			this.labelCopyright.Text = AssemblyCopyright;
			this.labelCompanyName.Text = AssemblyCompany;
			this.label1.Text = AssemblyDescription;
            this.textBoxDescription.Text = comment;
		}

		#region Методы доступа к атрибутам сборки

		public static string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public static string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public static string AssemblyDescription
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public static string AssemblyProduct
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public static string AssemblyCopyright
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public static string AssemblyCompany
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion

		private void AboutBox1_Load(object sender, EventArgs e)
		{

		}
		private void logoPictureBox_MouseEnter(object sender, EventArgs e)
		{
			timer1.Enabled = true;
		}
		private void logoPictureBox_MouseLeave(object sender, EventArgs e)
		{
			timer1.Enabled = false;
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (sw == 0)
			{
				logoPictureBox.Image = imageList1.Images[sw];
				sw = 1;
			}
			else
			{
				logoPictureBox.Image = imageList1.Images[sw];
				sw = 0;
			}
		}
	}
}
