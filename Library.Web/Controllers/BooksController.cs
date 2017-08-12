using Library.Web.Models;
using Library.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Library.Web.Models.JqTable;

namespace Library.Web.Controllers
{
    public class BooksController : ApiController
    {


        /// <summary>
        /// Brings The DataBack to Books Table Based on Filter
        /// </summary>          
        /// <param> Table Parameters</param>
        ///   <param> Search Criteria</param>
        ///   <returns>JqDataTable</returns>   
        public JqDataTable<object[]> Post_SearchInBooksTable(jQueryDataTableParamModel param, string searchCriteria, string type)
        {
            return SearchInBooks(param, searchCriteria);

        }


        /// <summary>
        /// Saves New Book
        /// </summary>          
        /// <param> BooksModel</param>
        ///   <returns>Bool</returns>
        public bool Post_SaveNewBook(BooksModel bModel)
        {
            BooksModel obj = new BooksModel();
            return obj.AddNewBook(bModel);
        }



        /// <summary>
        /// Brings The DataBack to Books Table Based on Filter
        /// </summary>          
        /// <param> Table Parameters</param>
        ///   <param> Search Criteria</param>
        ///   <returns>JqDataTable</returns>   
        private JqDataTable<object[]> SearchInBooks(jQueryDataTableParamModel param, string searchCriteria)
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

                BooksModel obj = new BooksModel();
                int count = obj.TotalBooks(criteria);

                var data = new List<object[]>();

                IList<BooksModel> bModel = new List<BooksModel>();
                bModel = obj.GetAllBooks(criteria);


                foreach (BooksModel item in bModel)
                {
                    var array = new object[7];
                    array[0] = item.ID;
                    array[1] = item.Title;
                    array[2] = item.Author;
                    array[3] = (item.TotalInStock - item.TotalAssigned > 0) ? "Y" : "N";                    
                    array[4] = item.TotalInStock;
                    array[5] = item.TotalAssigned;
                    array[6] = item.ID;

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


        /// <summary>
        /// Generic function to Convert JSON to object
        /// </summary>          
        /// <param> Search Criteria</param>
        ///   <param> Search Criteria</param>
        ///   <returns><t>Object</returns>   
        #region privateMethod
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
