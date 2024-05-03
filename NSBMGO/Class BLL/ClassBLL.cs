using NSBMGO.Data_access_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSBMGO.Class_BLL
{
    internal class ClassBLL
    {
        public DataTable GetItems(string startCity, string endCity)
        {
			try
			{
				ClassDAL objDAL = new ClassDAL();
				return objDAL.ReadItemsFromTableShuttle( startCity,  endCity);
				
			}
			catch (Exception)
			{

				throw;
			}
        }

		
    }
}
