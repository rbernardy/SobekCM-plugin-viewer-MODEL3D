var presenter = null;

function setup3dhop(sourceurl)
{
	console.log("setup3dhop: sourceurl=[" + sourceurl + "].");

	presenter = new Presenter("draw-canvas");

// mesh_1 url value was "models/gargo.nxs"

	presenter.setScene({
		meshes: {
			"mesh_1" : { url: sourceurl }
		},
		modelInstances : {
			"model_1" : { 
				mesh  : "mesh_1",
				color : [0.8, 0.7, 0.75],
				transform:{
					rotation: [0.0,0.0,0.0]
				}
			}
		},
		trackball: {
			type : TurntablePanTrackball,
			trackOptions : {
				startPhi: 35.0,
				startTheta: 15.0,
				startDistance: 2.5,
				minMaxPhi: [-180, 180],
				minMaxTheta: [-30.0, 70.0],
				minMaxDist: [0.5, 3.0]
			}
		}
	});

//--MEASURE--
	presenter._onEndMeasurement = onEndMeasure;
//--MEASURE--

//--POINT PICKING--
	presenter._onEndPickingPoint = onEndPick;
//--POINT PICKING--

//--SECTIONS--
	sectiontoolInit();
//--SECTIONS--
}

function actionsToolbar(action) {
	if(action=='home') presenter.resetTrackball();
//--FULLSCREEN--
	else if(action=='full'  || action=='full_on') fullscreenSwitch();
//--FULLSCREEN--
//--ZOOM--
	else if(action=='zoomin') presenter.zoomIn();
	else if(action=='zoomout') presenter.zoomOut();
//--ZOOM--
//--LIGHT--
	else if(action=='light' || action=='light_on') { presenter.enableLightTrackball(!presenter.isLightTrackballEnabled()); lightSwitch(); }
//--LIGHT--
//--COLOR--
	else if(action=='color' || action=='color_on') { presenter.toggleInstanceSolidColor(HOP_ALL, true); colorSwitch(); }
//--COLOR--
//--MEASURE--
	else if(action=='measure' || action=='measure_on') { presenter.enableMeasurementTool(!presenter.isMeasurementToolEnabled()); measureSwitch(); }
//--MEASURE--
//--POINT PICKING--
	else if(action=='pick' || action=='pick_on') { presenter.enablePickpointMode(!presenter.isPickpointModeEnabled()); pickpointSwitch(); }
//--POINT PICKING--
//--SECTIONS--
	else if(action=='sections' || action=='sections_on') { sectiontoolReset(); sectiontoolSwitch(); }
//--SECTIONS--
}

//--MEASURE--
function onEndMeasure(measure) {
	// measure.toFixed(2) sets the number of decimals when displaying the measure
	// depending on the model measure units, use "mm","m","km" or whatever you have
	$('#measure-output').html(measure.toFixed(2) + "mm"); 
}
//--MEASURE--

//--PICKPOINT--
function onEndPick(point) {
	// .toFixed(2) sets the number of decimals when displaying the picked point	
	var x = point[0].toFixed(2);
	var y = point[1].toFixed(2);
	var z = point[2].toFixed(2);
    $('#pickpoint-output').html("[ "+x+" , "+y+" , "+z+" ]");
} 
//--PICKPOINT--	
