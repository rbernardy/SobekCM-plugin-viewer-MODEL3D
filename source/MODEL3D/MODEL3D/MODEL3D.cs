using System;
using System.IO;
using System.Web;
using SobekCM.Core.BriefItem;
using SobekCM.Core.FileSystems;
using SobekCM.Core.Navigation;
using SobekCM.Core.Users;
using SobekCM.Engine_Library;
using SobekCM.Library.ItemViewer.Viewers;
using SobekCM.Library.UI;
using SobekCM.Tools;

namespace MODEL3D
{
    public class MODEL3D_ItemViewer : abstractNoPaginationItemViewer
    {
        /// <summary> Constructor for a new instance of the MODEL3D_ItemViewer class, used to display a 3D file from a digital resource </summary>
        /// <param name="BriefItem"> Digital resource object </param>
        /// <param name="CurrentUser"> Current user, who may or may not be logged on </param>
        /// <param name="CurrentRequest"> Information about the current request </param>
        /// <param name="Tracer"> Trace object keeps a list of each method executed and important milestones in rendering </param>
        public MODEL3D_ItemViewer(BriefItemInfo BriefItem, User_Object CurrentUser, Navigation_Object CurrentRequest, Custom_Tracer Tracer)
        {
            this.BriefItem = BriefItem;
            this.CurrentRequest = CurrentRequest;
            this.CurrentUser = CurrentUser;
        }

        public override void Add_Main_Viewer_Section(System.Web.UI.WebControls.PlaceHolder MainPlaceHolder, Custom_Tracer Tracer)
        {
            // do nothing
        }

        public override void Write_Main_Viewer_Section(TextWriter Output, Custom_Tracer Tracer)
        {
            String baseurl = CurrentRequest.Base_URL + "plugins/MODEL3D/";

            Output.WriteLine("<script type=\"text/javascript\">");
            Output.WriteLine("  $('#itemNavForm').prop('action','').submit(function(event){ event.preventDefault(); });");
            Output.WriteLine("</script>");

            // Is there a .nxs file in the content folder?  Otherwise, use the models/gargo sample
            string source_url = CurrentRequest.Base_URL + "plugins/MODEL3D/models/gargo.nxs";

            string network_location = SobekFileSystem.Resource_Network_Uri(BriefItem);

            // Does an *.nxs file exist?
            String[] files = Directory.GetFiles(network_location, "*.nxs", SearchOption.TopDirectoryOnly);

            if (files.Length>0)
            {
                source_url = UI_ApplicationCache_Gateway.Settings.Servers.Image_URL + SobekFileSystem.AssociFilePath(BriefItem).Replace("\\", "/") + Path.GetFileName(files[0]);
            }
    
            // Fit into SobekCM item page
            Output.WriteLine("    <td style=\"width:100%; height:100%;\">");

            // 3dhop index all tools
            Output.WriteLine("      <div id=\"3dhop\" class=\"tdhop\" onmousedown=\"if (event.preventDefault) event.preventDefault()\" style=\"width:100%; height:100%;\"><div id=\"tdhlg\"></div>");
            Output.WriteLine("          <div id=\"toolbar\">");
            Output.WriteLine("              <img id=\"home\" title=\"Home\" src=\"" + baseurl + "skins/dark/home.png\"/><br/>");

            //<!--ZOOM-->
            Output.WriteLine("              <img id=\"zoomin\" title=\"Zoom In\" src=\"" + baseurl + "skins/dark/zoomin.png\"/><br/>");
            Output.WriteLine("              <img id=\"zoomout\" title=\"Zoom Out\" src=\"" + baseurl + "skins/dark/zoomout.png\"/><br/>");
            //<!--ZOOM-->

            //<!--LIGHT-->
            Output.WriteLine("              <img id=\"light_on\" title=\"Disable Light Control\"  src=\"" + baseurl + "skins/dark/light_on.png\" style=\"position:absolute; visibility:hidden;\"/>");
            Output.WriteLine("              <img id=\"light\" title=\"Enable Light Control\" src=\"" + baseurl + "skins/dark/light.png\"/><br/>");
            //<!--LIGHT-->

            //<!--COLOR-->
            Output.WriteLine("              <img id=\"color_on\" title=\"Model color\" src=\"" + baseurl + "skins/dark/color_on.png\" style=\"position:absolute; visibility:hidden;\"/>");
            Output.WriteLine("              <img id=\"color\" title=\"Solid color\" src=\"" + baseurl + "skins/dark/color.png\"/><br/>");
            //<!--COLOR-->

            //<!--MEASURE-->
            Output.WriteLine("              <img id=\"measure_on\" title=\"Disable Measure Tool\" src=\"" + baseurl + "skins/dark/measure_on.png\" style=\"position:absolute; visibility:hidden;\"/>");
            Output.WriteLine("              <img id=\"measure\" title=\"Enable Measure Tool\" src=\"" + baseurl + "skins/dark/measure.png\"/><br/>");
            //<!--MEASURE-->

            //<!--POINT PICKING-->
            Output.WriteLine("              <img id=\"pick_on\" title=\"Disable PickPoint Mode\" src=\"" + baseurl + "skins/dark/pick_on.png\" style=\"position:absolute; visibility:hidden;\"/>");
            Output.WriteLine("              <img id=\"pick\" title=\"Enable PickPoint Mode\" src=\"" + baseurl + "skins/dark/pick.png\"/><br/>");
            //<!--POINT PICKING-->

            //<!--SECTIONS-->
            Output.WriteLine("              <img id=\"sections_on\" title=\"Disable Plane Sections\" src=\"" + baseurl + "skins/dark/sections_on.png\" style=\"position:absolute; visibility:hidden;\"/>");
            Output.WriteLine("              <img id=\"sections\" title=\"Enable Plane Sections\" src=\"" + baseurl + "skins/dark/sections.png\"/><br/>");
            //<!--SECTIONS-->

            //<!--FULLSCREEN-->
            Output.WriteLine("              <img id=\"full_on\" title=\"Exit Full Screen\" src=\"" + baseurl + "skins/dark/full_on.png\" style=\"position:absolute; visibility:hidden;\"/>");
            Output.WriteLine("              <img id=\"full\" title=\"Full Screen\" src=\"" + baseurl + "skins/dark/full.png\"/>");
            //<!--FULLSCREEN-->

            Output.WriteLine("</div> <!-- end of toolbar -->");

            //<!--MEASURE-->
            Output.WriteLine("<div id=\"measure-box\" class=\"output-box\">Measured length<hr/><span id=\"measure-output\" class=\"output-text\" onmousedown=\"event.stopPropagation()\">0.0</span></div>");
            //<!--MEASURE-->

            //<!--POINT PICKING-->
            Output.WriteLine("<div id=\"pickpoint-box\" class=\"output-box\">XYZ picked point<hr/><span id=\"pickpoint-output\" class=\"output-text\" onmousedown=\"event.stopPropagation()\">[ 0 , 0 , 0 ]</span></div>");
            //<!--POINT PICKING-->

            //<!--SECTIONS-->
            Output.WriteLine("<div id=\"sections-box\" class=\"output-box\">");
            Output.WriteLine("  <table class=\"output-table\" onmousedown=\"event.stopPropagation()\">");
            Output.WriteLine("      <tr><td>Plane</td><td>Position</td><td>Flip</td></tr>");
            Output.WriteLine("      <tr>");
            Output.WriteLine("          <td><img id=\"xplane_on\" title=\"Disable X Axis Section\" src=\"" + baseurl + "skins/icons/sectionX_on.png\" onclick=\"sectionxSwitch()\" style=\"position:absolute; visibility:hidden; border:1px inset;\"/>");
            Output.WriteLine("              <img id=\"xplane\" title=\"Enable X Axis Section\" src=\"" + baseurl + "skins/icons/sectionX.png\" onclick=\"sectionxSwitch()\"/><br/></td>");
            Output.WriteLine("          <td><input id=\"xplaneSlider\" class=\"output-input\" type=\"range\" title=\"Move X Axis Section Position\"/></td>");
            Output.WriteLine("          <td><input id=\"xplaneFlip\" class=\"output-input\" type=\"checkbox\" title=\"Flip X Axis Section Direction\"/></td></tr>");
            Output.WriteLine("      <tr>");
            Output.WriteLine("          <td><img id=\"yplane_on\" title=\"Disable Y Axis Section\" src=\"" + baseurl + "skins/icons/sectionY_on.png\" onclick=\"sectionySwitch()\" style=\"position:absolute; visibility:hidden; border:1px inset;\"/>");
            Output.WriteLine("              <img id=\"yplane\" title=\"Enable Y Axis Section\" src=\"" + baseurl + "skins/icons/sectionY.png\" onclick=\"sectionySwitch()\"/><br/></td>");
            Output.WriteLine("          <td><input id=\"yplaneSlider\" class=\"output-input\" type=\"range\" title=\"Move Y Axis Section Position\"/></td>");
            Output.WriteLine("          <td><input id=\"yplaneFlip\" class=\"output-input\" type=\"checkbox\" title=\"Flip Y Axis Section Direction\"/></td></tr>");
            Output.WriteLine("      <tr>");
            Output.WriteLine("          <td><img id=\"zplane_on\" title=\"Disable Z Axis Section\" src=\"" + baseurl + "skins/icons/sectionZ_on.png\" onclick=\"sectionzSwitch()\" style=\"position:absolute; visibility:hidden; border:1px inset;\"/>");
            Output.WriteLine("              <img id=\"zplane\" title=\"Enable Z Axis Section\" src=\"" + baseurl + "skins/icons/sectionZ.png\" onclick=\"sectionzSwitch()\"/><br/></td>");
            Output.WriteLine("          <td><input id=\"zplaneSlider\" class=\"output-input\" type=\"range\" title=\"Move Y Axis Section Position\"/></td>");
            Output.WriteLine("          <td><input id=\"zplaneFlip\" class=\"output-input\" type=\"checkbox\" title=\"Flip Z Axis Section Direction\"/></td></tr></table>");
            Output.WriteLine("<table class=\"output-table\" onmousedown=\"event.stopPropagation()\" style=\"text-align:right;\">");
            Output.WriteLine("  <tr>");
            Output.WriteLine("      <td>Show planes<input id=\"showPlane\" class=\"output-input\" type=\"checkbox\" title=\"Show Section Planes\" style=\"bottom:-3px;\"/></td>");
            Output.WriteLine("      <td>Show edges<input id=\"showBorder\" class=\"output-input\" type=\"checkbox\" title=\"Show Section Edges\" style=\"bottom:-3px;\"/></td></tr></table>");
            Output.WriteLine("</div><!-- end of sections-box -->");

            //<!--SECTIONS-->

            Output.WriteLine("<canvas id=\"draw-canvas\" style=\"background-image: url(" + baseurl + "skins/backgrounds/light.jpg)\"/>");
            Output.WriteLine("</div><!-- end of 3dhop div -->");

            // end of 3dhop index all tools

            // Fit into SobekCM item page 
            Output.WriteLine("    </td>");

            // testing additional jquery document ready
            Output.WriteLine("<script type=\"text/javascript\">");
            Output.WriteLine("$(document).ready(function()");
            Output.WriteLine("{");
            Output.WriteLine("console.log(\"additional jquery doc ready.\");");
            Output.WriteLine("init3dhop();");
            Output.WriteLine("console.log(\"3dhop - returned from init3dhop.\");");
            Output.WriteLine("setup3dhop('" + source_url + "');");
            Output.WriteLine("console.log(\"3dhop - returned from setup3dhop.\");");
            Output.WriteLine("resizeCanvas(960,600);");
            Output.WriteLine("setCenterModeScene();");
            Output.WriteLine("setCenterModeSpecific(\"model_1\");");
            Output.WriteLine("moveMeasurementbox(\"450px\",\"50px\")");
            Output.WriteLine("actionsToolbar(\"zoomin\");");
            Output.WriteLine("$(\".sbkIsw_DocumentDisplay2\").css(\"width\",\"100%\").css(\"height\",\"100%\");");
            Output.WriteLine("$(\"#3dhop\").css(\"width\",\"100%\").css(\"height\",\"100%\");");
            Output.WriteLine("console.log(\"3dhop done.\");");
            Output.WriteLine("});");
            Output.WriteLine("</script>");
        }

        /// <summary> Write any additional values within the HTML Head of the final served page </summary>
        /// <param name="Output"> Output stream currently within the HTML head tags </param>
        /// <param name="Tracer"> Trace object keeps a list of each method executed and important milestones in rendering </param>
        /// <remarks> By default this does nothing, but can be overwritten by all the individual item viewers </remarks>
        public override void Write_Within_HTML_Head(TextWriter Output, Custom_Tracer Tracer)
        {
            String baseurl = CurrentRequest.Base_URL + "plugins/MODEL3D/";
            Output.WriteLine("  <link rel=\"stylesheet\" type=\"text/css\" href=\"" + baseurl + "stylesheet/3dhop.css\"/>");

            // my encapsulation of js in original index_all_tools.html
            Output.WriteLine("  <script type=\"text/javascript\" src=\"" + baseurl + "js/3dhop.js\"></script>");

            Output.WriteLine("  <script type=\"text/javascript\" src=\"" + baseurl + "js/spidergl.js\"></script>");
            //Output.WriteLine("  <script type=\"text/javascript\" src=\"" + baseurl + "js/jquery.js\"></script>");
            Output.WriteLine("  <script type=\"text/javascript\" src=\"" + baseurl + "js/presenter.js\"></script>");
            Output.WriteLine("  <script type=\"text/javascript\" src=\"" + baseurl + "js/nexus.js\"></script>");
            Output.WriteLine("  <script type=\"text/javascript\" src=\"" + baseurl + "js/ply.js\"></script>");
            Output.WriteLine("  <script type=\"text/javascript\" src=\"" + baseurl + "js/trackball_turntable.js\"></script>");
            Output.WriteLine("  <script type=\"text/javascript\" src=\"" + baseurl + "js/trackball_turntable_pan.js\"></script>");
            Output.WriteLine("  <script type=\"text/javascript\" src=\"" + baseurl + "js/trackball_pantilt.js\"></script>");
            Output.WriteLine("  <script type=\"text/javascript\" src=\"" + baseurl + "js/trackball_sphere.js\"></script>");
            Output.WriteLine("  <script type=\"text/javascript\" src=\"" + baseurl + "js/init.js\"></script>");
        }
    }
}