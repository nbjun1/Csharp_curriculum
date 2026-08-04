using System;
using System.Net.Http;
using System.Net.Http.Json;
using EmployeeClient.Models;

namespace EmployeeClient.Services
{
    public class EmployeeApiService
    {
        private readonly HttpClient _httpClient;

        public EmployeeApiService()
        {
            // Web APIのアドレス
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7010/")
            };
        }

        // 一覧取得（GET）
        public async Task<List<Employee>?> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("api/Employee");
        }

        // 新規登録（POST）
        public async Task<bool> AddAsync(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Employee", employee);
            return response.IsSuccessStatusCode;
        }

        // 更新（PUT）
        public async Task<bool> UpdateAsync(Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Employee/{employee.Id}", employee);
            return response.IsSuccessStatusCode;
        }

        // 削除（DELETE）
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Employee/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}