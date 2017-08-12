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
    public class AssignBookController : ApiController
    {

        /// <summary>
        /// Book is Assigned to the Borrower
        /// </summary>          
        /// <param> AssignBookModel</param>
        ///   <returns>bool<BorrowersModel> </returns>  
        public bool Post_AssignBook(AssignBookModel aBookModel)
        {
            AssignBookModel aBook = new AssignBookModel();
            aBookModel.AssignedDate = DateTime.Now; //Current Assign Date
            aBookModel.DueDate = DateTime.Now.AddDays(7);//7 Days time to return book
            return aBook.AssignBook(aBookModel);

        }

        ///<summary>
        ///All Issued books History
        ///</summary>          
        ///<param> jQueryDataTableParamModel</param>
        ///<param> searchCriteria</param>
        ///<returns>bool<BorrowersModel> </returns>  
        public JqDataTable<object[]> Post_AllAssignedBooks(jQueryDataTableParamModel param, string searchCriteria,string type)
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

                AssignBookModel obj = new AssignBookModel();
                int count = obj.TotalAssigned(criteria);

                var data = new List<object[]>();

                IList<AssignBookModel> bModel = new List<AssignBookModel>();
                bModel = obj.GetAllAssignedBooks(criteria);


                foreach (AssignBookModel item in bModel)
                {
                    var array = new object[8];
                    array[0] = item.Title;
                    array[1] = item.FirstName + "," + item.LastName ;
                    array[2] = Convert.ToDateTime(item.AssignedDate).ToString("MMMM d, yyyy");
                    array[3] = Convert.ToDateTime(item.DueDate).ToString("MMMM d, yyyy"); ;
                    array[4] = (item.isCurrentlyAssigned==true) ? "N" : "Y";
                    array[5] = (DateTime.Now - item.DueDate).TotalDays > 0 && item.isCurrentlyAssigned==true ? "Y" : "N";
                    array[6] = item.BorrowerID;
                    array[7] = item.BookID;

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

            catch (Exception e)
            {
                return null;
            }
        }


        ///<summary>
        /// DeAssign the Book incase user has retruned it
        ///</summary>          
        ///<param> BookId</param>
        ///<param> BorrowerId</param>
        ///<returns>bool<BorrowersModel> </returns>  
        public bool GetDeAssignBook(int BookId, int BorrowerId)
        {
            AssignBookModel aBook = new AssignBookModel();
            aBook.BorrowerID = BorrowerId;
            aBook.BookID = BookId;

            return aBook.DeAssignBook(aBook);
        }


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
