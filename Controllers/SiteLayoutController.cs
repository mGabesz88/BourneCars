﻿using System.Web.Mvc;
using Umbraco.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BourneCars.Models;
using Umbraco.Core.Models;
using System.Runtime.Caching;
using Umbraco.Web;

namespace BourneCars.Controllers
{
    public class SiteLayoutController : SurfaceController
    {
        public const string SiteLayoutPartialViewFolder = "~/Views/Partials/SiteLayout/";

        /// <summary>
        /// Renders the header partial
        /// </summary>
        /// <returns>Partial view with a model</returns>
        public ActionResult RenderHeader()
        {
            return PartialView(SiteLayoutPartialViewFolder + "/_Header.cshtml");
        }

        /// <summary>
        /// Renders the footer partial
        /// </summary>
        /// <returns>Partial view with a model</returns>
        public ActionResult RenderFooter()
        {
            //return PartialView(SiteLayoutPartialViewFolder + "/_Footer.cshtml");
            List<NavigationListItem> nav = GetObjectFromCache<List<NavigationListItem>>("mainNav", 5, GetNavigationModelFromDatabase);
            return PartialView(SiteLayoutPartialViewFolder + "/_Footer.cshtml", nav);
        }

        /// <summary>
        /// Renders the Page title partial
        /// </summary>
        /// <returns>Partial view with a model</returns>
        public ActionResult RenderPageTitle()
        {
            return PartialView(SiteLayoutPartialViewFolder + "/_PageTitle.cshtml");
        }

        /// <summary>
        /// Renders the Home page navigation partial
        /// </summary>
        /// <returns>Partial view with a model</returns>
        public ActionResult RenderHomePageNavigation()
        {
            List<NavigationListItem> nav = GetObjectFromCache<List<NavigationListItem>>("mainNav", 5, GetNavigationModelFromDatabase);
            return PartialView(SiteLayoutPartialViewFolder + "/_HomePageNavigation.cshtml", nav);
        }

        /// <summary>
        /// Renders the top navigation partial
        /// </summary>
        /// <returns>Partial view with a model</returns>
        public ActionResult RenderNavigation()
        {
            List<NavigationListItem> nav = GetObjectFromCache<List<NavigationListItem>>("mainNav", 5, GetNavigationModelFromDatabase);
            return PartialView(SiteLayoutPartialViewFolder + "/_Navigation.cshtml", nav);
        }

        /// <summary>
        /// Finds the home page and gets the navigation structure based on it and it's children
        /// </summary>
        /// <returns>A List of NavigationListItems, representing the structure of the site.</returns>
        private List<NavigationListItem> GetNavigationModelFromDatabase()
        {
            IPublishedContent homePage = CurrentPage.AncestorOrSelf(1).DescendantsOrSelf().Where(x => x.DocumentTypeAlias == "home").FirstOrDefault();
            List<NavigationListItem> nav = new List<NavigationListItem>();
            nav.Add(new NavigationListItem(new NavigationLink(homePage.Url, homePage.Name)));
            nav.AddRange(GetChildNavigationList(homePage));
            return nav;
        }

        /// <summary>
        /// Loops through the child pages of a given page and their children to get the structure of the site.
        /// </summary>
        /// <param name="page">The parent page which you want the child structure for</param>
        /// <returns>A List of NavigationListItems, representing the structure of the pages below a page.</returns>
        private List<NavigationListItem> GetChildNavigationList(IPublishedContent page)
        {
            List<NavigationListItem> listItems = null;
            var childPages = page.Children.Where("Visible").Where(x => x.Level <= 2);
            if (childPages != null && childPages.Any() && childPages.Count() > 0)
            {
                listItems = new List<NavigationListItem>();
                foreach (var childPage in childPages)
                {
                    NavigationListItem listItem = new NavigationListItem(new NavigationLink(childPage.Url, childPage.Name));
                    listItem.Items = GetChildNavigationList(childPage);
                    listItems.Add(listItem);
                }
            }
            return listItems;
        }

        /// <summary>
        /// A generic function for getting and setting objects to the memory cache.
        /// </summary>
        /// <typeparam name="T">The type of the object to be returned.</typeparam>
        /// <param name="cacheItemName">The name to be used when storing this object in the cache.</param>
        /// <param name="cacheTimeInMinutes">How long to cache this object for.</param>
        /// <param name="objectSettingFunction">A parameterless function to call if the object isn't in the cache and you need to set it.</param>
        /// <returns>An object of the type you asked for</returns>
        private static T GetObjectFromCache<T>(string cacheItemName, int cacheTimeInMinutes, Func<T> objectSettingFunction)
        {
            ObjectCache cache = MemoryCache.Default;
            var cachedObject = (T)cache[cacheItemName];
            if (cachedObject == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTimeInMinutes);
                cachedObject = objectSettingFunction();
                cache.Set(cacheItemName, cachedObject, policy);
            }
            return cachedObject;
        }
    }
}