using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Tyuiu.MajdQadhi.Sprint7.Project.V12.Lib;

namespace Tyuiu.MajdQadhi.Sprint7.Project.V12
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            dateTimePickerRelease_KKA.CustomFormat = "DD MM YYYY";
        }
        DataService ds = new DataService();
        string pathPersonalComputer = $@"{Directory.GetCurrentDirectory()}\Back-end\personal_computer.csv";
        string pathSeller = $@"{Directory.GetCurrentDirectory()}\Back-end\selling_company.csv";

        private void toolStripButtonInfoProgram_KKA_Click(object sender, EventArgs e)
        {
            FormInfo info = new FormInfo();
            info.ShowDialog();
        }

        private void buttonAddNewPC_KKA_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxManufacturer_KKA.Text == "" || textBoxTypeCPU_KKA.Text == "" || numericUpDownCountCore_KKA.Text == "" ||
                    textBoxClockFrequency_KKA.Text == "" || numericUpDownCountMemory_KKA.Text == "" || textBoxCountDisk_KKA.Text == "" ||
                    dateTimePickerRelease_KKA.Text == "" || textBoxPrice_KKA.Text == "")
                {
                    MessageBox.Show("Введите все данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    string[] row = new string[] { $"{textBoxManufacturer_KKA.Text}", $"{textBoxTypeCPU_KKA.Text}",
                    $"{numericUpDownCountCore_KKA.Text}", $"{textBoxClockFrequency_KKA.Text}",
                    $"{numericUpDownCountMemory_KKA.Text}", $"{textBoxCountDisk_KKA.Text}",
                    $"{dateTimePickerRelease_KKA.Text}", $"{textBoxPrice_KKA.Text}" };
                    dataGridViewPC_KKA.Rows.Add(row);
                    bool completed = ds.AddNewData(pathPersonalComputer, row);
                    if (completed)
                    {
                        MessageBox.Show("Данные добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    textBoxManufacturer_KKA.Clear();
                    textBoxTypeCPU_KKA.Clear();
                    numericUpDownCountCore_KKA.Text = "0";
                    textBoxClockFrequency_KKA.Clear();
                    numericUpDownCountMemory_KKA.Text = "0";
                    textBoxCountDisk_KKA.Clear();
                    dateTimePickerRelease_KKA.Text = $"{DateTime.Now}";
                    textBoxPrice_KKA.Clear();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowControls(bool pcVisible, params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.Visible = pcVisible;
            }
        }

        private void buttonPC_KKA_Click(object sender, EventArgs e)
        {
            ShowControls(true, dataGridViewPC_KKA, labelSearch_KKA, textBoxSearch_KKA, buttonSearchPC_KKA, textBoxManufacturer_KKA,
                textBoxClockFrequency_KKA, textBoxCountDisk_KKA, textBoxTypeCPU_KKA, textBoxPrice_KKA, numericUpDownCountCore_KKA,
                numericUpDownCountMemory_KKA, dateTimePickerRelease_KKA, buttonAddNewPC_KKA, buttonSavePC_KKA, buttonStatistic_KKA,
                labelClockFrequency_KKA, labelCountCore_KKA, labelCountDisk_KKA, labelCountMemory_KKA, labelManufacturer_KKA,
                labelPrice_KKA, labelTypeCPU_KKA, labelRelease_KKA);
            ShowControls(false, buttonSearchSeller_KKA, dataGridViewSeller_KKA, dataGridViewSeller_KKA, textBoxNameSeller_KKA,
                textBoxPhoneNumber_KKA, textBoxURL_KKA, textBoxAddress_KKA, buttonAddNewSeller_KKA, buttonSaveSeller_KKA,
                labelAddress_KKA, labelNameSeller_KKA, labelPhoneNumber_KKA, labelURL_KKA);

            textBoxTitle_KKA.Text = "Электронно-вычислительные машины";
            try
            {

                string[,] DataMatrix = ds.GetData(pathPersonalComputer);

                int rows = DataMatrix.GetLength(0);
                int columns = DataMatrix.GetLength(1);

                dataGridViewPC_KKA.RowCount = rows;
                dataGridViewPC_KKA.ColumnCount = columns;

                dataGridViewPC_KKA.Columns[0].HeaderText = "Производитель";
                dataGridViewPC_KKA.Columns[1].HeaderText = "Тип процессора";
                dataGridViewPC_KKA.Columns[2].HeaderText = "Кол-во ядер";
                dataGridViewPC_KKA.Columns[3].HeaderText = "Тактовая частота";
                dataGridViewPC_KKA.Columns[4].HeaderText = "Объем ОЗУ";
                dataGridViewPC_KKA.Columns[5].HeaderText = "Объем ЖД";
                dataGridViewPC_KKA.Columns[6].HeaderText = "Дата выпуска";
                dataGridViewPC_KKA.Columns[7].HeaderText = "Цена";

                for (int i = 0; i < columns; i++)
                {
                    dataGridViewPC_KKA.Columns[i].Width = 150;
                }

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        dataGridViewPC_KKA.Rows[r].Cells[c].Value = DataMatrix[r, c];
                    }
                }
                buttonPC_KKA.BackColor = Color.FromArgb(33, 150, 243);
                buttonSeller_KKA.BackColor = Color.FromArgb(51, 51, 77);
                dataGridViewPC_KKA.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSeller_KKA_Click(object sender, EventArgs e)
        {
            ShowControls(false, dataGridViewPC_KKA, buttonSearchPC_KKA, textBoxManufacturer_KKA,
                textBoxClockFrequency_KKA, textBoxCountDisk_KKA, textBoxTypeCPU_KKA, textBoxPrice_KKA, numericUpDownCountCore_KKA,
                numericUpDownCountMemory_KKA, dateTimePickerRelease_KKA, buttonAddNewPC_KKA, buttonSavePC_KKA, buttonStatistic_KKA,
                labelClockFrequency_KKA, labelCountCore_KKA, labelCountDisk_KKA, labelCountMemory_KKA, labelManufacturer_KKA,
                labelPrice_KKA, labelTypeCPU_KKA, labelRelease_KKA);
            ShowControls(true, buttonSearchSeller_KKA, labelSearch_KKA, textBoxSearch_KKA, dataGridViewSeller_KKA, dataGridViewSeller_KKA, textBoxNameSeller_KKA,
                textBoxPhoneNumber_KKA, textBoxURL_KKA, textBoxAddress_KKA, buttonAddNewSeller_KKA, buttonSaveSeller_KKA,
                labelAddress_KKA, labelNameSeller_KKA, labelPhoneNumber_KKA, labelURL_KKA);

            textBoxTitle_KKA.Text = "Фирмы-реализаторы";
            try
            {

                string[,] DataMatrix = ds.GetData(pathSeller);

                int rows = DataMatrix.GetLength(0);
                int columns = DataMatrix.GetLength(1);

                dataGridViewSeller_KKA.RowCount = rows;
                dataGridViewSeller_KKA.ColumnCount = columns;

                dataGridViewSeller_KKA.Columns[0].HeaderText = "Наименование";
                dataGridViewSeller_KKA.Columns[1].HeaderText = "Адрес";
                dataGridViewSeller_KKA.Columns[2].HeaderText = "Номер телефона";
                dataGridViewSeller_KKA.Columns[3].HeaderText = "Ссылка на сайт";

                for (int i = 0; i < columns; i++)
                {
                    dataGridViewSeller_KKA.Columns[i].Width = 150;
                }

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        dataGridViewSeller_KKA.Rows[r].Cells[c].Value = DataMatrix[r, c];
                    }
                }
                buttonPC_KKA.BackColor = Color.FromArgb(51, 51, 77);
                buttonSeller_KKA.BackColor = Color.FromArgb(33, 150, 243);
                dataGridViewSeller_KKA.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonManual_KKA_Click(object sender, EventArgs e)
        {
            FormManual manual = new FormManual();
            manual.Show();
        }

        private void buttonAbout_KKA_Click(object sender, EventArgs e)
        {
            FormInfo info = new FormInfo();
            info.ShowDialog();
        }

        private void buttonSearchPC_KKA_Click(object sender, EventArgs e)
        {
            dataGridViewPC_KKA.ClearSelection();
            for (int i = 0; i <= dataGridViewPC_KKA.Rows.Count - 1; i++)
                for (int j = 0; j <= dataGridViewPC_KKA.ColumnCount - 1; j++)
                    if (dataGridViewPC_KKA.Rows[i].Cells[j].Value != null && dataGridViewPC_KKA.Rows[i].Cells[j].Value.ToString() == textBoxSearch_KKA.Text)
                        dataGridViewPC_KKA.Rows[i].Selected = true;
        }

        private void buttonAddNewSeller_KKA_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxURL_KKA.Text == "" || textBoxPhoneNumber_KKA.Text == "" || textBoxNameSeller_KKA.Text == "" || textBoxAddress_KKA.Text == "")
                {
                    MessageBox.Show("Введите все данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    string[] row = new string[] { $"{textBoxNameSeller_KKA.Text}", $"{textBoxAddress_KKA.Text}",
                    $"{textBoxPhoneNumber_KKA.Text}", $"{textBoxURL_KKA.Text}" };
                    dataGridViewSeller_KKA.Rows.Add(row);
                    bool completed = ds.AddNewData(pathSeller, row);
                    if (completed)
                    {
                        MessageBox.Show("Данные добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    textBoxNameSeller_KKA.Clear();
                    textBoxAddress_KKA.Clear();
                    textBoxPhoneNumber_KKA.Clear();
                    textBoxURL_KKA.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonStatistic_KKA_Click(object sender, EventArgs e)
        {
            FormStatistic statistic = new FormStatistic();
            statistic.Show();
        }

        private void buttonSaveSeller_KKA_Click(object sender, EventArgs e)
        {
            string[,] data = new string[dataGridViewSeller_KKA.RowCount, dataGridViewSeller_KKA.ColumnCount];
            for (int i = 0; i < dataGridViewSeller_KKA.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewSeller_KKA.ColumnCount; j++)
                {
                    data[i, j] = dataGridViewSeller_KKA.Rows[i].Cells[j].Value.ToString();
                }
            }
            bool completed = ds.UpdateData(pathSeller, data);

            if (completed)
            {
                MessageBox.Show("Данные обновлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSavePC_KKA_Click(object sender, EventArgs e)
        {
            string[,] data = new string[dataGridViewPC_KKA.RowCount, dataGridViewPC_KKA.ColumnCount];
            for (int i = 0; i < dataGridViewPC_KKA.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewPC_KKA.ColumnCount; j++)
                {
                    data[i, j] = dataGridViewPC_KKA.Rows[i].Cells[j].Value.ToString();
                }
            }
            bool completed = ds.UpdateData(pathPersonalComputer, data);

            if (completed)
            {
                MessageBox.Show("Данные обновлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSearchSeller_KKA_Click(object sender, EventArgs e)
        {
            dataGridViewSeller_KKA.ClearSelection();
            for (int i = 0; i <= dataGridViewSeller_KKA.Rows.Count - 1; i++)
                for (int j = 0; j <= dataGridViewSeller_KKA.ColumnCount - 1; j++)
                    if (dataGridViewSeller_KKA.Rows[i].Cells[j].Value != null && dataGridViewSeller_KKA.Rows[i].Cells[j].Value.ToString() == textBoxSearch_KKA.Text)
                        dataGridViewSeller_KKA.Rows[i].Selected = true;
        }

        private void buttonPC_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Персональные компьютеры";
        }

        private void buttonSeller_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Фирмы-реализаторы";
        }

        private void buttonManual_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Руководство пользователя";
        }

        private void buttonAbout_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "О программе";
        }

        private void buttonSearchSeller_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Поиск";
        }

        private void buttonStatistic_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Статистика";
        }

        private void buttonAddNewSeller_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Добавить";
        }

        private void buttonSaveSeller_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Сохранить";
        }

        private void textBoxManufacturer_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Наименование производителя";
        }

        private void textBoxTypeCPU_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Тип процессора";
        }

        private void numericUpDownCountCore_KKA_Enter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Количество ядер процессора";
        }

        private void textBoxClockFrequency_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Тактовая частота процессора";
        }

        private void textBoxCountDisk_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Объем жесткого диска";
        }

        private void dateTimePickerRelease_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Дата выпуска ЭВМ";
        }

        private void textBoxPrice_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Стоимость ЭВМ";
        }

        private void textBoxNameSeller_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Наименование фирмы";
        }

        private void textBoxAddress_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Адрес фирмы";
        }

        private void textBoxPhoneNumber_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Номер телефона фирмы";
        }

        private void textBoxURL_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "URL-ссылка";
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            e.Cancel = !(res == DialogResult.Yes);
        }

        private void textBoxPrice_KKA_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != ',')
            {
                e.Handled = true;
            }
        }

        private void textBoxClockFrequency_KKA_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != ',')
            {
                e.Handled = true;
            }
        }
    }
}
