function setup3dhopCustom(sourceurl)
{
        console.log("setup3dhop: sourceurl=[" + sourceurl + "].");

	console.log("myrotx=[" + myrotx + "].");
	console.log("myroty=[" + myroty + "].");
	console.log("myrotz=[" + myrotz + "].");
	console.log("mystartd=[" + mystartd + "].");

        presenter = new Presenter("draw-canvas");

// mesh_1 url value was "models/gargo.nxs"

        presenter.setScene({
                meshes: {
                        "mesh_1" : { url: sourceurl }
                },
                modelInstances : {
                        "model_1" : { 
                                mesh  : "mesh_1",
                                color : [0.1, 0.1, 0.1],
                                transform:{
                                        rotation: [myrotx,myroty,myrotz]
                                }
                        }
                },
                trackball: {
                        type : SphereTrackball,
                        trackOptions : {
                                startDistance: mystartd,
                        }
                }
        });

if (typeof tbpos !== 'undefined')
{
	console.log("The tbpos array exists.");
	presenter.animateToTrackballPosition(tbpos);
}
else
{
	console.log("The tbpos array does NOT exist.");
}

if (typeof myskinbackgroundfile !== 'undefined')
{
	url_bi="/plugins/MODEL3D/skins/backgrounds/" + myskinbackgroundfile;
	console.log("myskinbackgroundfile is defined: url_bi=[" + url_bi + "].");
	$("canvas#draw-canvas").prop("style","");
	$("canvas#draw-canvas").css("background-image","url(" + url_bi + ")");
}
else
{
	console.log("myskinbackgroundfile is undefined.");
}

if (typeof mybackgroundcolor !== 'undefined')
{
	console.log("mybackgroundcolor is defined [" + mybackgroundcolor + "].");
	$("canvas#draw-canvas").prop("style","");
	$("canvas#draw-canvas").css("background-color",mybackgroundcolor);
}
else
{
	console.log("mybackgroundcolor is undefined.");
}

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

