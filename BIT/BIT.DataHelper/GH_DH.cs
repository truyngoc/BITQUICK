﻿
// =============================================
// This Class is generated by BuildProject
// Author:	Bop
// Create date:	07/09/2016 20:08
// Description:	
// Revise History:	
// =============================================

using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Collections.Generic;
using BIT.Objects;
using BIT.Common;
using BIT.DataHelper;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace BIT.DataHelper
{ 
	public class GH_DH : DataAccessBase
	{	
		public void InsertItem(GH obj)
		{
			defaultDB.ExecuteNonQuery("sp_GH_Insert"
				, obj.CodeId, obj.Amount, obj.CurrentAmount, obj.CreateDate, obj.Status);
		}

		public void UpdateItem(GH obj)
		{
			defaultDB.ExecuteNonQuery("sp_GH_Update"
				, obj.ID, obj.CodeId, obj.Amount, obj.CurrentAmount, obj.CreateDate, obj.Status);
		}

		public void DeleteItem(int ID)
		{
			defaultDB.ExecuteNonQuery("sp_GH_Delete"
				, ID);
		}

		public GH SelectItem(int ID)
		{
			return defaultDB.ExecuteSprocAccessor<GH>("sp_GH_SelectItem"
				, ID).FirstOrDefault();
		}

		public IEnumerable<GH> SelectAllItems()
		{
			return defaultDB.ExecuteSprocAccessor<GH>("sp_GH_SelectAllItems");
		}

		public bool IsExistsItem(int ID)
		{
			IDataReader dr  = defaultDB.ExecuteReader("sp_GH_SelectItem"
				, ID);
			
			bool bol = dr.Read();
			dr.Close();
			
			return bol;
		}



        public IEnumerable<GH_Info> SelectItemsByNumber(int numberGH)
        {
            return defaultDB.ExecuteSprocAccessor<GH_Info>("sp_GH_SelectItemsByNumber", numberGH);
        }

        public IEnumerable<GH_Info> SelectWaitingGH()
        {
            return defaultDB.ExecuteSprocAccessor<GH_Info>("sp_GH_SelectWaitingGH");
        }

        public IEnumerable<GH_Info> SelectAdminMemberGH()
        {
            return defaultDB.ExecuteSprocAccessor<GH_Info>("sp_GH_SelectAdminMemberGH");
        }
	}
}
