using System;
using MapKit;
using UIKit;
namespace DrugStoreIOS
{
    public class MapViewDelegeate: MKMapViewDelegate
    {
        string pId = "PinAnnotation";

        public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            if (annotation is MKUserLocation)
                return null;
            
            MKAnnotationView pinView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation(pId);

            if (pinView == null)
                pinView = new MKPinAnnotationView(annotation, pId);

            var annot = annotation as AnnotationForMap;
            if(annot.available == true)
                ((MKPinAnnotationView)pinView).PinColor = MKPinAnnotationColor.Green;
            else
                ((MKPinAnnotationView)pinView).PinColor = MKPinAnnotationColor.Red;
            
            pinView.CanShowCallout = true;
            return pinView;
        }
	}
}
