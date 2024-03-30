using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace MyApiService
{
    public interface IApiService
    {
        #region Customer
        Task<CustomerList> GetCustomerListAsync();
        Task<int> InsertCustomer(Customer customer);
        Task<int> UpdateCustomer(Customer customer);
        Task<int> DeleteCustomer(int id);
        #endregion

        #region City
        Task<CitysList> GetCitysListAsync();
        Task<int> InsertCity(City city);
        Task<int> UpdateCity(City city);
        Task<int> DeleteCity(int id);
        #endregion

        #region Branchs
        Task<BranchsList> GetBranchListAsync();
        Task<int> InsertBranch(Branchs branchs);
        Task<int> UpdateBranch(Branchs branchs);
        Task<int> DeleteBranch(int id);
        #endregion

        #region Management
        Task<ManagementList> GetManagementListAsync();
        Task<int> InsertManagement(Management management);
        Task<int> UpdateManagement(Management management);
        Task<int> DeleteManagement(int id);
        #endregion

        #region Business
        Task<BusinessList> GetBusinessListAsync();
        Task<int> InsertBusiness(Business business);
        Task<int> UpdateBusiness(Business business);
        Task<int> DeleteBusiness(int id);
        #endregion

        #region Cards
        Task<CardsList> GetCardsListAsync();
        Task<int> InsertCards(CardForCustomers card);
        Task<int> UpdateCards(CardForCustomers card);
        Task<int> DeleteCards(int id);
        #endregion

        #region ChargeType
        Task<ChargeTypeList> GetChargeTypeListAsync();
        Task<int> InsertChargeType(ChargeType chargeType);
        Task<int> UpdateChargeType(ChargeType chargeType);
        Task<int> DeleteChargeType(int id);
        #endregion

        #region CreditCharges
        Task<CreditChargesList> GetCreditChargesListAsync();
        Task<int> InsertCreditCharges(CreditCharges creditCharges);
        Task<int> UpdateCreditCharges(CreditCharges creditCharges);
        Task<int> DeleteCreditCharges(int id);
        #endregion

        #region Operations
        Task<OperationsList> GetOperationsListAsync();
        Task<int> InsertOperations(Operations operations);
        Task<int> UpdateOperations(Operations operations);
        Task<int> DeleteOperations(int id);
        #endregion
    }
}
