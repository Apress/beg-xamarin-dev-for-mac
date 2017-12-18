using CoreLocation;
using MapKit;

namespace Users.MobileClient.Helpers
{
    public class PinMapAnnotation : MKAnnotation
    {
    	private CLLocationCoordinate2D coordinate;
    	private string title;

    	public override CLLocationCoordinate2D Coordinate 
        {
            get => coordinate;
        }

    	public override void SetCoordinate(CLLocationCoordinate2D value)
    	{
    		coordinate = value;
    	}

    	public override string Title 
        { 
            get => title;
        }
    	
    	public PinMapAnnotation(CLLocationCoordinate2D coordinate, string title)
    	{
    		this.coordinate = coordinate;
    		this.title = title;			
    	}
    }
}
