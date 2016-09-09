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
using System.Data.Common;
using System.Linq;
using System.Collections.Generic;
using BIT.Objects;
using BIT.Common;
using BIT.DataHelper;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace BIT.DataHelper
{ 
	public class COMMAND_DETAIL_DH : DataAccessBase
	{	
		public void InsertItem(COMMAND_DETAIL obj)
		{
			defaultDB.ExecuteNonQuery("sp_COMMAND_DETAIL_Insert"
				, obj.CommandID, obj.CodeId_From, obj.CodeId_To, obj.TransactionId, obj.DateCreate, obj.ConfirmGH, obj.DateConfirmGH, obj.ConfirmPH, obj.DateConfirmPH, obj.Amount, obj.Status, obj.PH_ID, obj.GH_ID);
		}

        public void InsertItemWithTrans(DbTransaction trans, COMMAND_DETAIL obj)
        {
            defaultDB.ExecuteNonQuery(trans,"sp_COMMAND_DETAIL_Insert"
                , obj.CommandID, obj.CodeId_From, obj.CodeId_To, obj.TransactionId, obj.DateCreate, obj.ConfirmGH, obj.DateConfirmGH, obj.ConfirmPH, obj.DateConfirmPH, obj.Amount, obj.Status, obj.PH_ID, obj.GH_ID);
        }

		public void UpdateItem(COMMAND_DETAIL obj)
		{
			defaultDB.ExecuteNonQuery("sp_COMMAND_DETAIL_Update"
                , obj.ID, obj.CommandID, obj.CodeId_From, obj.CodeId_To, obj.TransactionId, obj.DateCreate, obj.ConfirmGH, obj.DateConfirmGH, obj.ConfirmPH, obj.DateConfirmPH, obj.Amount, obj.Status, obj.PH_ID, obj.GH_ID);
		}

		public void DeleteItem(int ID)
		{
			defaultDB.ExecuteNonQuery("sp_COMMAND_DETAIL_Delete"
				, ID);
		}

		public COMMAND_DETAIL SelectItem(int ID)
		{
			return defaultDB.ExecuteSprocAccessor<COMMAND_DETAIL>("sp_COMMAND_DETAIL_SelectItem"
				, ID).FirstOrDefault();
		}

		public IEnumerable<COMMAND_DETAIL> SelectAllItems()
		{
			return defaultDB.ExecuteSprocAccessor<COMMAND_DETAIL>("sp_COMMAND_DETAIL_SelectAllItems");
		}

		public bool IsExistsItem(int ID)
		{
			IDataReader dr  = defaultDB.ExecuteReader("sp_COMMAND_DETAIL_SelectItem"
				, ID);
			
			bool bol = dr.Read();
			dr.Close();
			
			return bol;
		}


        public IEnumerable<COMMAND_DETAIL> SelectItemsByPhId(int PH_ID)
        {
            return defaultDB.ExecuteSprocAccessor<COMMAND_DETAIL>("sp_PH_GetListCommandDetails", PH_ID);
        }

        public IEnumerable<COMMAND_DETAIL> SelectItemsByGhId(int GH_ID)
        {
            return defaultDB.ExecuteSprocAccessor<COMMAND_DETAIL>("sp_GH_GetListCommandDetails", GH_ID);
        }

        public void ConfirmPH(COMMAND_DETAIL obj)
        {
            defaultDB.ExecuteNonQuery("sp_COMMAND_DETAIL_ConfirmPH"
                , obj.ID, obj.TransactionId, obj.ConfirmPH, obj.DateConfirmPH, obj.Status);
        }
	}
}
