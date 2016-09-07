﻿
// =============================================
// This Class is generated by BuildProject 
// Author:	Bop
// Create date:	07/09/2016 20:08
// Description:	
// Revise History:	
// =============================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BIT.DataHelper;
using BIT.Objects;
using BIT.Common;

namespace BIT.Controller
{ 
	public class PH_BC
	{
		PH_DH ctl = new PH_DH();
		
		public void InsertItem(PH obj)		
		{
			ctl.InsertItem(obj);
		}

		public void UpdateItem(PH obj)
		{
			ctl.UpdateItem(obj);
		}

		public void DeleteItem(int ID)
		{
			ctl.DeleteItem(ID);
		}

		public PH SelectItem(int ID)
		{
			return ctl.SelectItem(ID);
		}

		public List<PH> SelectAllItems()
		{
			return ctl.SelectAllItems().ToList();
		}
		
		public bool IsExistsItem(int ID)
		{
			return ctl.IsExistsItem(ID);
		}

        // lay so lan PH cua CodeId trong ngay (de check neu qua >=1 thi ko cho PH)
        public int GetNumberPH(string CodeId)
        {
            return ctl.GetNumberPH(CodeId);
        }

        public List<PH> SelectItemsByCodeId(string CodeId)
        {
            return ctl.SelectItemsByCodeId(CodeId).ToList();
        }
	}
}
