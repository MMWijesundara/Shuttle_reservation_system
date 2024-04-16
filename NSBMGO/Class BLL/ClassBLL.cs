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
        public DataTable GetItems(string ResCity)
        {
			try
			{
				ClassDAL objDAL = new ClassDAL();
				return objDAL.ReadItemsFromTable(ResCity);
				
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
