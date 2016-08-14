﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public abstract class BaseController : Controller
    {
        public DataClassesDataContext data = new DataClassesDataContext();

        //TODO, this class help the other classes having accessibility to use method UpdateMode of Controller 
        public void updateModel(Object model)
        {
            UpdateModel(model);
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            ViewData[Constants.KEY_VIEWDATA_LIST_MODULE] = DataHelper.GeneralHelper.getInstance().getAllSupportedModules(data);
            ViewData[Constants.KEY_VIEWDATA_SHOPPING_CARD_ITEMS_AMOUNT] = DataHelper.ShoppingCardHelper.getInstance().getItemsAmountInShoppingCard(requestContext.HttpContext);
            ViewData[Constants.KEY_VIEWDATA_IS_LOGIN] = DataHelper.AccountHelper.getInstance().checkIsMemberLoggingIn(HttpContext);
        }
    }
}