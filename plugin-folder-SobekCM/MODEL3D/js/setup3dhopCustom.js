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

