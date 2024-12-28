using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

using Tyuiu.MajdQadhi.Sprint7.Project.V12.Lib;

namespace Tyuiu.MajdQadhi.Sprint7.Project.V12
{
    public partial class FormStatistic : Form
    {
        public FormStatistic()
        {
            InitializeComponent();
        }
        string path = $@"{Directory.GetCurrentDirectory()}\Back-end\personal_computer.csv";
        DataService ds = new DataService();
        private void FormStatistic_Load(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetData(path);

            double[] pricePC = ds.GetPrice(DataMatrix);

            int rows = ds.GetCountRows(DataMatrix);

            string[] nameManufacturer = ds.GetNameManufacturer(DataMatrix);

            double minPrice = ds.MinValue(pricePC);

            double maxPrice = ds.MaxValue(pricePC);

            double avgPrice = ds.AverageValue(pricePC);

            double sum = 0;
            for (int i = 0; i < pricePC.Length; i++)
            {
                sum += pricePC[i];
            }

            textBoxMinPrice_KKA.Text = minPrice.ToString();
            textBoxMaxPrice_KKA.Text = maxPrice.ToString();
            textBoxAvgPrice_KKA.Text = avgPrice.ToString();
            textBoxCountRows_KKA.Text = rows.ToString();
            textBoxSumPrice_KKA.Text = sum.ToString();

            Title title = new Title();
            title.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            title.Text = "Статистика стоимости ЭВМ";

            chartCirclePC_KKA.Titles.Add(title);
            chartPillarPC_KKA.Titles.Add(title);

            for (int i = 0; i < pricePC.Length; i++)
            {
                //chartCirclePC_KKA.Series.Add("s1");

                // Add point.
                chartCirclePC_KKA.Series["S1"].IsValueShownAsLabel = true;
                chartCirclePC_KKA.Series["S1"].Points.AddXY(nameManufacturer[i], pricePC[i]);

                chartPillarPC_KKA.Series["S1"].IsValueShownAsLabel = true;
                chartPillarPC_KKA.Series["S1"].Points.AddXY(nameManufacturer[i], pricePC[i]);
            }
        }

        private void textBoxCountRows_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Количество записей";
        }

        private void textBoxSumPrice_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Сумма";
        }

        private void textBoxMinPrice_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Минимальное значение";
        }

        private void textBoxMaxPrice_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Максимальное значение";
        }

        private void textBoxAvgPrice_KKA_MouseEnter(object sender, EventArgs e)
        {
            toolTipHelp_KKA.ToolTipTitle = "Среднее значение";
        }
    }
}
