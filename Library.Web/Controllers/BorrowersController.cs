using Library.Common;
using Library.Web.Models;
using Library.Web.Models.JqTable;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace Library.Web.Controllers
{
    public class BorrowersController : ApiController
    {

        /// <summary>
        /// Brings The DataBack to Borrowers Table Based on Filter
        /// </summary>          
        /// <param> Table Parameters</param>
        ///   <param> Search Criteria</param>
        ///   <returns>JqDataTable</returns>       
        public JqDataTable<object[]> Post_SearchBorrowerTable(jQueryDataTableParamModel param, string searchCriteria)
        {
            return SearchInBorrowers(param, searchCriteria);

        }



        /// <summary>
        /// Saves New Borrower
        /// </summary>          
        /// <param> BorrowersModel</param>
        ///   <returns>Bool</returns>
        public bool Post_SaveNewBorrower(BorrowersModel bModel)
        {
            try
            {
                BorrowersModel obj = new BorrowersModel();
                return obj.AddBorrower(bModel);
            }
            catch (Exception ex)
            {
                Logging.Error(ex.Message);
                return false;
            }
        }



        /// <summary>
        /// Brings The DataBack to Borrowers Table Based on Filter
        /// </summary>          
        /// <param> Table Parameters</param>
        ///   <param> Search Criteria</param>
        ///   <returns>JqDataTable</returns>  
        private JqDataTable<object[]> SearchInBorrowers(jQueryDataTableParamModel param, string searchCriteria)
        {
            try
            {

                SearchCriteria criteria = ConvertFromJsonToObject<SearchCriteria>(searchCriteria);

                int startIndex = 0;
                if (param.iDisplayStart > 0)
                    startIndex = param.iDisplayStart + 1;
                else startIndex = param.iDisplayStart;

                criteria.StartIndex = startIndex;
                criteria.EndIndex = param.iDisplayStart + param.iDisplayLength;
                criteria.SortOrder = param.sSortDir_0;
                criteria.SortingCol = param.iSortCol_0;

                if (String.IsNullOrWhiteSpace(criteria.Text))
                    criteria.Text = String.Empty;

                BorrowersModel obj = new BorrowersModel();
                int count = obj.TotalBorrowers(criteria);

                var data = new List<object[]>();

                IList<BorrowersModel> bModels = new List<BorrowersModel>();
                bModels = obj.GetAllBorrowers(criteria);


                foreach (BorrowersModel item in bModels)
                {
                    var array = new object[3];
                    array[0] = item.ID;
                    array[1] = item.FirstName;
                    array[2] = item.LastName;


                    data.Add(array);

                }

                return new JqDataTable<object[]>
                {
                    sEcho = param.sEcho,
                    iTotalRecords = count,
                    iTotalDisplayRecords = count,
                    aaData = data
                };
            }

            catch (Exception ex)
            {
                Logging.Error(ex.Message);
                return null;
            }
        }



        #region privateMethod

        /// <summary>
        /// Generic Method to Parse the Search Criteria       
        private T ConvertFromJsonToObject<T>(string searchCriteria) where T : new()
        {
            searchCriteria = searchCriteria.TrimStart('{').TrimEnd('}');
            List<string> results = searchCriteria.Split(',').ToList();
            var articleSearchCriteria = new T();
            Type type = articleSearchCriteria.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                int index = results.FindIndex(x => x.Contains(property.Name));
                if (index > -1)
                {
                    string value = results[index].Split(':')[1].TrimStart('"').TrimEnd('"');
                    if (value.Length > 0)
                    {
                        if (property.PropertyType.Name == typeof(DateTime).Name)
                        {
                            DateTime dt = DateTime.Now;
                            DateTime.TryParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture,
                                                   DateTimeStyles.None, out dt);

                            property.SetValue(articleSearchCriteria, dt, null);
                        }
                        else if (property.PropertyType.Name == typeof(Boolean).Name)
                        {
                            Boolean b;
                            Boolean.TryParse(value, out b);
                            property.SetValue(articleSearchCriteria, b, null);
                        }
                        else if (property.PropertyType.Name == typeof(Int32).Name)
                        {
                            Int32 b;
                            Int32.TryParse(value, out b);
                            property.SetValue(articleSearchCriteria, b, null);
                        }
                        else
                        {
                            property.SetValue(articleSearchCriteria, value, null);
                        }
                    }
                }
            }

            return (T)Convert.ChangeType(articleSearchCriteria, typeof(T));
            //  return articleSearchCriteria;
        }
        #endregion
    }
}
