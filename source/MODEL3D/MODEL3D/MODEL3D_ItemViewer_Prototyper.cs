using System;
using System.Web;
using System.Collections.Generic;
using SobekCM.Core.BriefItem;
using SobekCM.Core.Navigation;
using SobekCM.Core.Users;
using SobekCM.Library.ItemViewer.Menu;
using SobekCM.Library.ItemViewer.Viewers;
using SobekCM.Tools;

namespace MODEL3D
{
    public class MODEL3D_ItemViewer_Prototyper : iItemViewerPrototyper
    {
        public string ViewerType { get; set; }
        public string ViewerCode { get; set; }
        public string[] FileExtensions { get; set; }

        /// <summary> Constructor for a new instance of the MODEL3D_ItemViewerPrototyper class </summary>
        public MODEL3D_ItemViewer_Prototyper()
        {
            ViewerType = "MODEL3D";
            ViewerCode = "model3d";
        }

        /// <summary> Indicates if the specified item matches the basic requirements for this viewer, or
        /// if this viewer should be ignored for this item </summary>
        /// <param name="CurrentItem"> Digital resource to examine to see if this viewer really should be included </param>
        /// <returns> If the user elected to add the RTI, who are we to disagree?  always returns TRUE </returns>
        public bool Include_Viewer(BriefItemInfo CurrentItem)
        {
            return true;
        }

        /// <summary> Flag indicates if this viewer should be override on checkout </summary>
        /// <param name="CurrentItem"> Digital resource to examine to see if this viewer should really be overriden </param>
        /// <returns> TRUE always, since RTI should never be shown if an item is checked out </returns>
        public bool Override_On_Checkout(BriefItemInfo CurrentItem)
        {
            return true;
        }

        /// <summary> Flag indicates if the current user has access to this viewer for the item </summary>
        /// <param name="CurrentItem"> Digital resource to see if the current user has correct permissions to use this viewer </param>
        /// <param name="CurrentUser"> Current user, who may or may not be logged on </param>
        /// <param name="IpRestricted"> Flag indicates if this item is IP restricted AND if the current user is outside the ranges </param>
        /// <returns> TRUE if the user has access to use this viewer, otherwise FALSE </returns>
        public bool Has_Access(BriefItemInfo CurrentItem, User_Object CurrentUser, bool IpRestricted)
        {
            return !IpRestricted;
        }

        /// <summary> Gets the menu items related to this viewer that should be included on the main item (digital resource) menu </summary>
        /// <param name="CurrentItem"> Digital resource object, which can be used to ensure if and how this viewer should appear 
        /// in the main item (digital resource) menu </param>
        /// <param name="CurrentUser"> Current user, who may or may not be logged on </param>
        /// <param name="CurrentRequest"> Information about the current request </param>
        /// <param name="MenuItems"> List of menu items, to which this method may add one or more menu items </param>
        /// <param name="IpRestricted"> Flag indicates if this item is IP restricted AND if the current user is outside the ranges </param>
        public void Add_Menu_Items(BriefItemInfo CurrentItem, User_Object CurrentUser, Navigation_Object CurrentRequest, List<Item_MenuItem> MenuItems, bool IpRestricted)
        {
            // Get the URL for this
            string previous_code = CurrentRequest.ViewerCode;
            CurrentRequest.ViewerCode = ViewerCode;
            string url = UrlWriterHelper.Redirect_URL(CurrentRequest);
            CurrentRequest.ViewerCode = previous_code;

            // Start with the default label on the menu
            string label = "MODEL3D";

            // Allow the label to be implemented for this viewer
            BriefItem_BehaviorViewer thisViewerInfo = CurrentItem.Behaviors.Get_Viewer(ViewerCode);

            // If this is found, and has a custom label, use that 
            if ((thisViewerInfo != null) && (!String.IsNullOrWhiteSpace(thisViewerInfo.Label)))
                label = thisViewerInfo.Label;

            // Add the item menu information
            Item_MenuItem menuItem = new Item_MenuItem(label, null, null, url, ViewerCode);
            MenuItems.Add(menuItem);
        }

        /// <summary> Creates and returns the an instance of the <see cref="JPEG_ItemViewer"/> class for showing a  
        /// JPEG image from a page within a digital resource during execution of a single HTTP request. </summary>
        /// <param name="CurrentItem"> Digital resource object </param>
        /// <param name="CurrentUser"> Current user, who may or may not be logged on </param>
        /// <param name="CurrentRequest"> Information about the current request </param>
        /// <param name="Tracer"> Trace object keeps a list of each method executed and important milestones in rendering </param>
        /// <returns> Fully built and initialized <see cref="JPEG_ItemViewer"/> object </returns>
        /// <remarks> This method is called whenever a request requires the actual viewer to be created to render the HTML for
        /// the digital resource requested.  The created viewer is then destroyed at the end of the request </remarks>
        public iItemViewer Create_Viewer(BriefItemInfo CurrentItem, User_Object CurrentUser, Navigation_Object CurrentRequest, Custom_Tracer Tracer)
        {
            return new MODEL3D_ItemViewer(CurrentItem, CurrentUser, CurrentRequest, Tracer);
        }
    }
}