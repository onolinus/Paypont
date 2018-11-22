using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paypont.Models;

namespace Paypont.Controllers.api
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerContext _personContext;
        private readonly ILogger _logger;

        public CustomerController(CustomerContext context, ILogger<CustomerController> logger)
        {
            _personContext = context;
            _logger = logger;

            try
            {
                if (_personContext.customers.Count() == 0)
                {
                    // read from file and add to entityframework memory based
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    string resourceName = "Paypont.Data.cust.csv";


                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            CsvReader csvReader = new CsvReader(reader);
                            csvReader.Configuration.RegisterClassMap<CustomerMapper>();
                            var custs = csvReader.GetRecords<Customer>().ToArray();

                            foreach (var customer in custs)
                            {
                                _personContext.customers.Add(customer);
                            }
                            _personContext.SaveChanges();
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogInformation("Open File :"+ex.ToString());
            }
        }


        [HttpPost]
        public IActionResult Post()
        {

            _logger.LogInformation("Post Customer :");
            var requestFormData = Request.Form;
            _logger.LogInformation("RequestFormData :" + requestFormData);
            List<Models.Customer> lstCust = _personContext.customers.ToList();

            var listCustomer = populateCollection(lstCust, requestFormData);
            int recFiltered = GetTotalRecordsFiltered(requestFormData, lstCust, listCustomer);

            dynamic response = new
            {
                Data = listCustomer,
                Draw = requestFormData["draw"],
                RecordsFiltered = recFiltered,
                RecordsTotal = lstCust.Count
            };
            return Ok(response);

        }


        private PropertyInfo getProperty(string name)
        {
            var properties = typeof(Models.Customer).GetProperties();
            PropertyInfo prop = null;
            foreach (var item in properties)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = item;
                    break;
                }
            }
            return prop;
        }

      
<<<<<<< HEAD
        private List<Models.Customer> populateCollection(List<Models.Customer> listElements, IFormCollection requestFormData)
=======
        private List<Models.Customer> populateCollection(List<Models.Customer> lstElements, IFormCollection requestFormData)
>>>>>>> 237ab996d9e131ad007669fe4c2c7217505a3177
        {
            string searchText = string.Empty;

            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

            if (requestFormData.TryGetValue("search[value]", out tempOrder))
            {
                searchText = requestFormData["search[value]"].ToString();
            }

            tempOrder = new[] { "" };

            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
           
            if (requestFormData.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requestFormData["order[0][column]"].ToString();
                var sortDirection = requestFormData["order[0][dir]"].ToString();

                tempOrder = new[] { "" };

                if (requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columName = requestFormData[$"columns[{columnIndex}][data]"].ToString();

                    if (pageSize > 0)
                    {
                        var prop = getProperty(columName);
                        // for ascending
                        if (sortDirection == "asc")
                        {
                            return listElements
                                .Where(x => x.SureName.ToLower().Contains(searchText.ToLower()))
                                .Skip(skip)
                                .Take(pageSize)
                                .OrderBy(prop.GetValue).ToList();
                        }
                        else
                        {
                            // for descending
                            return listElements
                                .Where(
                                    x => x.SureName.ToLower().Contains(searchText.ToLower()))
                                .Skip(skip)
                                .Take(pageSize)
                                .OrderByDescending(prop.GetValue).ToList();
                        }
                    }
                    else
                        return listElements;
                }
            }
            return null;
        }

        private int GetTotalRecordsFiltered(IFormCollection requestFormData, List<Models.Customer> listCustomer, List<Models.Customer> listProcessedItems)
        {
            var recFiltered = 0;
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };
            if (requestFormData.TryGetValue("search[value]", out tempOrder))
            {
                if (string.IsNullOrEmpty(requestFormData["search[value]"].ToString().Trim()))
                {
                    recFiltered = listCustomer.Count;
                }
                else
                {
                    recFiltered = listProcessedItems.Count;
                }
            }
            return recFiltered;

        }
    }
}
