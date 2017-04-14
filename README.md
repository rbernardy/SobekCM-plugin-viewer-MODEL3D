# SobekCM-plugin-viewer-MODEL3D
<p>SobekCM-plugin-viewer-MODEL3D is a plugin for the open-source SobekCM Digital Repository software (Mark V. Sullivan, lead developer). It provides a viewer for 3D model content (nxs format) using 3DHOP, a HTML5-WebGL viewer created by Marco Potenziani and Marco Callieri.</p>

<h2>Testing the plugin:</h2>

<ul>
<li>Complete the standard SobekCM plugin installation steps.</li>
<li>Create a new item.</li>
<li>Upload a 3D model in the .nxs or .ply format.</li>
<li>Upload a config.js, changing defaults if desired.</li>
<li>Edit behaviors and add the MODEL3D viewer.</li>
</ul>

<h3>config.js file</h3>

<p>The config.js file supports two different approaches to initial scene configuration - rotation &amp; start distance and/or trackball position. You can use one or the other or both in combination. The file contains variables that will be used by the setup3dhopCustom.js file. The myrot values and mystartd values are required, the tbpos value is optional.</p>

<ul>
<li>myrotx - the X value of the initial transformation rotation. Default value is 0.</li>
<li>myrotx = the Y value of the initial transformation rotation. Default value is 0.</li>
<li>myrotz = the Z value of the initial transformation rotation. Default value is 0.</li>
<li>mystartd = the starting distance.</li>
<li>tbpos = An array of the trackball position values. To make it easier to obtain this data I added an additional 'function' to the standard interface. An additional icon appears at the bottom of the tool links on the left. Use the trackball (the default is the Sphere trackball) to position the model how you want it to display initially, click the icon, and the current trackball position array will display in a popup. Copy and past this into your config.js file.</li>
</ul>
 
<h2>Credits</h2>

<p>Mark V. Sullivan (SobekCM's lead developer, <a href="https://sobekdigital.com/">Sobek Digital Hosting &amp; Consulting</a>) - Although I developed this plugin myself I was able to do so because of the excellent traning Mark provided to me in December 2016. I followed the initial design pattern of the SobekCM-plugin-viewer-RTI plugin that we started developing collaboratively during that training session.</p>

<p>SobekCM - the open-source digital repository software of which I am also a contributor. The GitHub repository for SobekCM is a <a href="https://github.com/SobekCM/SobekCM-Web-Application">SobekCM/SobekCM-Web-Application</a>. See also the <a href="http://sobekrepository.org/">Sobek Home</a>.</p>

<p>Marco Potenziani and Marco Callieri - Created the <a href="http://vcg.isti.cnr.it/3dhop/">3DHOP</a> viewer at the Visual Computing Lab - Istituto di Scienza e Tecnologie dell’Informazione “A. Faedo”(ISTI), an Institute of the National Research Council of Italy (CNR) at Pisa, Italy. See the <a href="http://vcg.isti.cnr.it/3dhop/contacts.php">3DHOP contacts</a> page. 3DHOP was released under the GNU General Public License version 3.</p>

<p>Marco Di Benedetto and Marco Potenziani (also from the Visual Computing Lab - ISTI - CNR) - 3DHOP depends upon SpiderGL, also available via GitHub. SpiderGL was released under the GNU General Public License version 3.</p>

<p><a href="http://vcg.isti.cnr.it/nexus/">NEXUS</a> tools - the NEXUS Windows console apps are used to generate multi-resolution nxs content.</p>

<p>3DHOP - using their gargo.nxs sample 3D model content as the default content if a .nxs file is not available in the SobekCM item content folder. The sample content used is in the 3DHOP/models folder in the 3DHOP official distribution file (currently 4.1) which is linked on the <a href="http://vcg.isti.cnr.it/3dhop/download.php">3DHOP download</a> page.</p>

<hr/>

<p>Richard Bernardy - <a href="mailto:rbernard@usf.edu">rbernard@usf.edu</a> - 04/14/2017.</p>
<p>I'd appreciate a courtesy notification by email if you find this plugin useful and are using it in your SobekCM-based respository.</p>
