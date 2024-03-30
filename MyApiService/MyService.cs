using ApiZada;
using Model;
using MyApiService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModel;

namespace MyApiService
{
    public class MyService : IApiService
    {
        private HttpClient _httpClient;
        private string _uri;
        public MyService()
        {
            _httpClient = new HttpClient();
            _uri = "http://localhost:50352/api/";
        }

        public async Task<int> DeleteBranch(int id)
        {
            return (await _httpClient.DeleteAsync(_uri + "Values/" + "DeleteBranch")).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteBusiness(int id)
        {
            return (await _httpClient.DeleteAsync(_uri + "Values/" + "DeleteBusiness")).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteCards(int id)
        {
            return (await _httpClient.DeleteAsync(_uri + "Values/" + "DeleteCards")).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteChargeType(int id)
        {
            return (await _httpClient.DeleteAsync(_uri + "Values/" + "DeleteChargeType")).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteCity(int id)
        {
            return (await _httpClient.DeleteAsync(_uri + "Values/" + "DeleteCity")).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteCreditCharges(int id)
        {
            return (await _httpClient.DeleteAsync(_uri + "Values/" + "DeleteCreditCharges")).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteCustomer(int id)
        {
            return (await _httpClient.DeleteAsync(_uri + "Values/" + "DeleteCustomer")).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteManagement(int id)
        {
            return (await _httpClient.DeleteAsync(_uri + "Values/" + "DeleteManagement")).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteOperations(int id)
        {
            return (await _httpClient.DeleteAsync(_uri + "Values/" + "DeleteOperations")).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<BranchsList> GetBranchListAsync()
        {
            return await _httpClient.GetFromJsonAsync<BranchsList>(_uri + "Values/" + "BranchsSelector");
        }

        public async Task<BusinessList> GetBusinessListAsync()
        {
            return await _httpClient.GetFromJsonAsync<BusinessList>(_uri + "Values/" + "BusinessSelector");
        }

        public async Task<CardsList> GetCardsListAsync()
        {
            return await _httpClient.GetFromJsonAsync<CardsList>(_uri + "Values/" + "CardsSelector");
        }

        public async Task<ChargeTypeList> GetChargeTypeListAsync()
        {
            return await _httpClient.GetFromJsonAsync<ChargeTypeList>(_uri + "Values/" + "ChargeTypeSelector");
        }

        public async Task<CitysList> GetCitysListAsync()
        {
            return await _httpClient.GetFromJsonAsync<CitysList>(_uri + "Values/" + "CitysSelector");
        }

        public async Task<CreditChargesList> GetCreditChargesListAsync()
        {
            return await _httpClient.GetFromJsonAsync<CreditChargesList>(_uri + "Values/" + "CreditChargesSelector");
        }

        public async Task<CustomerList> GetCustomerListAsync()
        {
            return await _httpClient.GetFromJsonAsync<CustomerList>(_uri + "Values/" + "CustomerSelector");
        }

        public async Task<ManagementList> GetManagementListAsync()
        {
            return await _httpClient.GetFromJsonAsync<ManagementList>(_uri + "Values/" + "ManagementSelector");
        }

        public async Task<OperationsList> GetOperationsListAsync()
        {
            return await _httpClient.GetFromJsonAsync<OperationsList>(_uri + "Values/" + "OperationsSelector");
        }

        public async Task<int> InsertBranch(Branchs branchs)
        {
            return (await _httpClient.PostAsJsonAsync(_uri + "Values/" + "InsertBranchs", branchs)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertBusiness(Business business)
        {
            return (await _httpClient.PostAsJsonAsync(_uri + "Values/" + "InsertBusiness", business)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertCards(CardForCustomers card)
        {
            return (await _httpClient.PostAsJsonAsync(_uri + "Values/" + "InsertCards", card)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertChargeType(ChargeType chargeType)
        {
            return (await _httpClient.PostAsJsonAsync(_uri + "Values/" + "InsertChargeType", chargeType)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertCity(City city)
        {
            return (await _httpClient.PostAsJsonAsync(_uri + "Values/" + "InsertCitys", city)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertCreditCharges(CreditCharges creditCharges)
        {
            return (await _httpClient.PostAsJsonAsync(_uri + "Values/" + "InsertCreditCharges", creditCharges)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertCustomer(Customer customer)
        {
            var x = (await _httpClient.PostAsJsonAsync(_uri + "Values/" + "InsertCustomers", customer));

            var y = await x.Content.ReadAsStringAsync();

            Console.WriteLine(y);

            return x.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertManagement(Management management)
        {
            return (await _httpClient.PostAsJsonAsync(_uri + "Values/" + "InsertManagement", management)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertOperations(Operations operations)
        {
            return (await _httpClient.PostAsJsonAsync(_uri + "Values/" + "InsertOperations", operations)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateBranch(Branchs branchs)
        {
            return (await _httpClient.PutAsJsonAsync(_uri + "Values/" + "UpdateBranch", branchs)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateBusiness(Business business)
        {
            return (await _httpClient.PutAsJsonAsync(_uri + "Values/" + "UpdateBusiness", business)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateCards(CardForCustomers card)
        {
            return (await _httpClient.PutAsJsonAsync(_uri + "Values/" + "UpdateCard", card)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateChargeType(ChargeType chargeType)
        {
            return (await _httpClient.PutAsJsonAsync(_uri + "Values/" + "UpdateChargeType", chargeType)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateCity(City city)
        {
            return (await _httpClient.PutAsJsonAsync(_uri + "Values/" + "UpdateCity", city)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateCreditCharges(CreditCharges creditCharges)
        {
            return (await _httpClient.PutAsJsonAsync(_uri + "Values/" + "UpdateCreditCharges", creditCharges)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateCustomer(Customer customer)
        {
            return (await _httpClient.PutAsJsonAsync(_uri + "Values/" + "UpdateCustomer", customer)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateManagement(Management management)
        {
            return (await _httpClient.PutAsJsonAsync(_uri + "Values/" + "UpdateManagement", management)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateOperations(Operations operations)
        {
            return (await _httpClient.PutAsJsonAsync(_uri + "Values/" + "UpdateOperations", operations)).IsSuccessStatusCode ? 1 : 0;
        }
    }
}
