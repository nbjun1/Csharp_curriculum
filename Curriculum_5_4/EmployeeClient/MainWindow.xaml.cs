using System;
using System.Windows;
using System.Windows.Controls;
using EmployeeClient.Models;
using EmployeeClient.Services;

namespace EmployeeClient
{
    public partial class MainWindow : Window
    {
        private readonly EmployeeApiService _apiService = new EmployeeApiService();

        public MainWindow()
        {
            InitializeComponent();
            DpHireDate.SelectedDate = DateTime.Today;
            LoadData();
        }

        // 一覧取得
        private async void LoadData()
        {
            try
            {
                var employees = await _apiService.GetAllAsync();
                GridEmployees.ItemsSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"データ取得失敗: {ex.Message}");
            }
        }

        // 追加ボタン
        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var emp = new Employee
            {
                Name = TxtName.Text,
                Department = TxtDepartment.Text,
                HireDate = DpHireDate.SelectedDate ?? DateTime.Today
            };

            if (await _apiService.AddAsync(emp))
            {
                ClearInputs();
                LoadData();
            }
        }

        // 更新ボタン
        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (GridEmployees.SelectedItem is Employee selected)
            {
                selected.Name = TxtName.Text;
                selected.Department = TxtDepartment.Text;
                selected.HireDate = DpHireDate.SelectedDate ?? DateTime.Today;

                if (await _apiService.UpdateAsync(selected))
                {
                    ClearInputs();
                    LoadData();
                }
            }
        }

        // 削除ボタン
        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GridEmployees.SelectedItem is Employee selected)
            {
                if (await _apiService.DeleteAsync(selected.Id))
                {
                    ClearInputs();
                    LoadData();
                }
            }
        }

        // 再読込ボタン
        private void BtnReload_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        // 行選択時に入力欄へ反映
        private void GridEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridEmployees.SelectedItem is Employee selected)
            {
                TxtName.Text = selected.Name;
                TxtDepartment.Text = selected.Department;
                DpHireDate.SelectedDate = selected.HireDate;
            }
        }

        private void ClearInputs()
        {
            TxtName.Text = "";
            TxtDepartment.Text = "";
            DpHireDate.SelectedDate = DateTime.Today;
        }
    }
}