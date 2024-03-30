using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiZada.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [ActionName("CustomerSelector")]
        public CustomerList SelectAllCustomers()
        {
            CustomerDB customerDB = new CustomerDB();
            CustomerList customers = customerDB.SelectAll();
            return customers;
        }

        // GET api/<ValuesController>/5
        [HttpGet]
        [ActionName("CitysSelector")]
        public CitysList SelectAllCitys()
        {
            CityDB cityDB = new CityDB();
            CitysList cities = cityDB.SelectAll();
            return cities;
        }

        // POST api/<ValuesController>
        [HttpGet]
        [ActionName("BranchsSelector")]
        public BranchsList SelectAllBranchs()
        {
            BranchDB branchDB = new BranchDB();
            BranchsList branchs = branchDB.SelectAll();
            return branchs;
        }

        // PUT api/<ValuesController>/5
        [HttpGet]
        [ActionName("ManagementSelector")]
        public ManagementList SelectAllManagements()
        {
            ManagementDB managementDB = new ManagementDB();
            ManagementList management = managementDB.SelectAll();
            return management;
        }

        // DELETE api/<ValuesController>/5
        [HttpGet]
        [ActionName("BusinessSelector")]
        public BusinessList SelectAllBusinesses()
        {
            BusinessDB businessDB = new BusinessDB();
            BusinessList business = businessDB.SelectAll();
            return business;
        }
        [HttpGet]
        [ActionName("CardsSelector")]
        public CardsList SelectAllCards()
        {
            CardsDB cardsDB = new CardsDB();
            CardsList cards = cardsDB.SelectAll();
            return cards;
        }
        [HttpGet]
        [ActionName("ChargeTypeSelector")]
        public ChargeTypeList SelectAllChargeTypes()
        {
            ChargeTypeDB chargeTypeDB = new ChargeTypeDB();
            ChargeTypeList ct = chargeTypeDB.SelectAll();
            return ct;
        }
        [HttpGet]
        [ActionName("CreditChargesSelector")]
        public CreditChargesList SelectAllCreditCharges()
        {
            CreditChargesDB creditChargesDB = new CreditChargesDB();
            CreditChargesList cc = creditChargesDB.SelectAll();
            return cc;
        }
        [HttpGet]
        [ActionName("OperationsSelector")]
        public OperationsList SelectAllOperations()
        {
            OperationsDB operationsDB = new OperationsDB();
            OperationsList operations = operationsDB.SelectAll();
            return operations;
        }
        [HttpPost]
        [ActionName("InsertCustomers")]
        public int InsertCustomers([FromBody] Customer c)
        {
            CustomerDB customerDB = new CustomerDB();
            customerDB.Insert(c);
            int x = customerDB.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("InsertCitys")]
        public int InsertCitys([FromBody] City c)
        {
            CityDB cityDB = new CityDB();
            cityDB.Insert(c);
            int x = cityDB.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("InsertBranchs")]
        public int InsertBranchs([FromBody] Branchs b)
        {
            BranchDB branchDB = new BranchDB();
            branchDB.Insert(b);
            int x = branchDB.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("InsertManagement")]
        public int InsertManagement([FromBody] Management m)
        {
            ManagementDB managementDB = new ManagementDB();
            managementDB.Insert(m);
            int x = managementDB.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("InsertBusiness")]
        public int InsertBusiness(Business b) 
        {
            BusinessDB businessDB = new BusinessDB();
            businessDB.Insert(b);
            int x = businessDB.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName ("InsertCards")]
        public int InsertCards(CardForCustomers c)
        {
            CardsDB cardsDB = new CardsDB();
            cardsDB.Insert(c);
            int x = cardsDB.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("InsertChargeType")]
        public int InsertChargeType(ChargeType c)
        {
            ChargeTypeDB chargeTypeDB = new ChargeTypeDB();
            chargeTypeDB.Insert(c);
            int x = chargeTypeDB.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("InsertCreditCharges")]
        public int InsertCreditCharges(CreditCharges c)
        {
            CreditChargesDB creditChargesDB = new CreditChargesDB();
            creditChargesDB.Insert(c);
            int x = creditChargesDB.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("InsertOperations")]
        public int InsertOperations(Operations o)
        {
            OperationsDB operationsDB = new OperationsDB();
            operationsDB.Insert(o);
            int x = operationsDB.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName ("UpdateCustomer")]
        public int UpdateCustomer(Customer customer) 
        {
            CustomerDB customerDB = new CustomerDB();
            customerDB.Update(customer);
            int x = customerDB.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("UpdateCity")]
        public int UpdateCity(City city)
        {
            CityDB cityDB = new CityDB();
            cityDB.Update(city);
            int x = cityDB.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("UpdateBranch")]
        public int UpdateBranch(Branchs branch)
        {
            BranchDB branchDB = new BranchDB();
            branchDB.Update(branch);
            int x = branchDB.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("UpdateManagement")]
        public int UpdateManagement(Management management)
        {
            ManagementDB managementDB = new ManagementDB();
            managementDB.Update(management);
            int x = managementDB.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("UpdateBusiness")]
        public int UpdateBusiness(Business business)
        {
            BusinessDB businessDB = new BusinessDB();
            businessDB.Update(business);
            int x = businessDB.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("UpdateCard")]
        public int UpdateCard(CardForCustomers card)
        {
            CardsDB cardsDB = new CardsDB();
            cardsDB.Update(card);
            int x = cardsDB.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("UpdateChargeType")]
        public int UpdateChargeType(ChargeType chargeType)
        {
            ChargeTypeDB chargeTypeDB = new ChargeTypeDB();
            chargeTypeDB.Update(chargeType);
            int x = chargeTypeDB.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("UpdateCreditCharges")]
        public int UpdateCreditCharges(CreditCharges creditCharges)
        {
            CreditChargesDB creditChargesDB = new CreditChargesDB();
            creditChargesDB.Update(creditCharges);
            int x = creditChargesDB.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("UpdateOperations")]
        public int UpdateOperations(Operations operations)
        {
            OperationsDB operationsDB = new OperationsDB();
            operationsDB.Update(operations);
            int x = operationsDB.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        [ActionName ("DeleteCustomer")]
        public int DeleteCustomer(int id) 
        {
            Customer customer = CustomerDB.SelectById(id);
            CustomerDB customerDB = new CustomerDB();
            customerDB.Delete(customer);
            int x = customerDB.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        [ActionName("DeleteCity")]
        public int DeleteCity(int id)
        {
            City city = CityDB.SelectById(id);
            CityDB cityDB = new CityDB();
            cityDB.Delete(city);
            int x = cityDB.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        [ActionName("DeleteBranch")]
        public int DeleteBranch(int id)
        {
            Branchs branchs = BranchDB.SelectById(id);
            BranchDB branchDB = new BranchDB();
            branchDB.Delete(branchs);
            int x = branchDB.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        [ActionName("DeleteManagement")]
        public int DeleteManagement(int id)
        {
            Management management = ManagementDB.SelectById(id);
            ManagementDB managementDB = new ManagementDB();
            managementDB.Delete(management);
            int x = managementDB.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        [ActionName("DeleteBusiness")]
        public int DeleteBusiness(int id)
        {
            Business business = BusinessDB.SelectById(id);
            BusinessDB businessDB = new BusinessDB();
            businessDB.Delete(business);
            int x = businessDB.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        [ActionName("DeleteCards")]
        public int DeleteCards(int id)
        {
            CardForCustomers card = CardsDB.SelectById(id);
            CardsDB cardsDB = new CardsDB();
            cardsDB.Delete(card);
            int x = cardsDB.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        [ActionName("DeleteChargeType")]
        public int DeleteChargeType(int id)
        {
            ChargeType chargeType = ChargeTypeDB.SelectById(id);
            ChargeTypeDB chargeTypeDB = new ChargeTypeDB();
            chargeTypeDB.Delete(chargeType);
            int x = chargeTypeDB.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        [ActionName("DeleteCreditCharges")]
        public int DeleteCreditCharges(int id)
        {
            CreditCharges creditCharges = CreditChargesDB.SelectById(id);
            CreditChargesDB creditChargesDB = new CreditChargesDB();
            creditChargesDB.Delete(creditCharges);
            int x = creditChargesDB.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        [ActionName("DeleteOperations")]
        public int DeleteOperations(int id)
        {
            Operations operations = OperationsDB.SelectById(id);
            OperationsDB operationsDB = new OperationsDB();
            operationsDB.Delete(operations);
            int x = operationsDB.SaveChanges();
            return x;
        }
    }
}
