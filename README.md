# SobekCM-plugin-viewer-MODEL3D
<p>SobekCM-plugin-viewer-MODEL3D is a plugin for the open-source SobekCM Digital Repository software (Mark V. Sullivan, lead developer). It provides a viewer for 3D model content (nxs format) using 3DHOP, a HTML5-WebGL viewer created by Marco Potenziani and Marco Callieri.</p>

<h2>Testing the plugin:</h2>

<ul>
<li>Complete the standard SobekCM plugin installation steps.</li>
<li>Create a new item.</li>
<li>Upload a 3D model in the .nxs format.</li>
<li>Edit behaviors and add the MODEL3D viewer.</li>
</ul>
 
<h2>Credits</h2>

<p>Mark V. Sullivan (SobekCM's lead developer) - Although I developed this plugin myself I was able to do so because of the excellent traning Mark provided to me in December 2016. I followed the initial design pattern of the SobekCM-plugin-viewer-RTI plugin that we  started developing collaboratively during that training session.</p>

<p>Marco Potenziani and Marco Callieri - Created the <a href="http://vcg.isti.cnr.it/3dhop/">3DHOP</a> viewer at the Visual Computing Lab - Istituto di Scienza e Tecnologie dell’Informazione “A. Faedo”(ISTI), an Institute of the National Research Council of Italy (CNR) at Pisa, Italy. See the <a href="http://vcg.isti.cnr.it/3dhop/contacts.php">3DHOP contacts</a> page. 3DHOP was released under the GNU General Public License version 3.</p>

<p>Marco Di Benedetto and Marco Potenziani (also from the Visual Computing Lab - ISTI - CNR) - 3DHOP depends upon SpiderGL, also available via GitHub. SpiderGL was released under the GNU General Public License version 3.</p>

<p><a href="http://vcg.isti.cnr.it/nexus/">NEXUS</a> tools - the NEXUS Windows console apps are used to generate multi-resolution nxs content.</p>

<p>3DHOP - using their gargo.nxs sample 3D model content as the default content if no .nxs file is available in the SobekCM item content folder. The sample content used is in the 3DHOP/models folder in the 3DHOP official distribution file (currently 4.1) which is linked on the <a href="http://vcg.isti.cnr.it/3dhop/download.php">3DHOP download</a> page.</p>

<hr/>

<p>Richard Bernardy - rbernard@usf.edu - 12/31/2016.</p>
