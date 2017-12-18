function displayMap(mapDivId, latInputId, lngInputId) {
    lat = document.getElementById(latInputId).value;
    lng = document.getElementById(lngInputId).value;

    var mapCenter = new google.maps.LatLng(lat, lng);
    
    var options = {
        zoom: 14,
        center: mapCenter
    };
    
    new google.maps.Map(document.getElementById(mapDivId), options);
}

function displayGeocoordinate(address) {
    var geocoder = new google.maps.Geocoder();

    geocoder.geocode({'address': address}, function(results, status) {        
        if (status === 'OK') {            
            var geocoordinate = results[0].geometry.location;

            alert('Address: ' + address 
                + '\nLat: ' + geocoordinate.lat().toFixed(3)
                + '\nLng: ' + geocoordinate.lng().toFixed(3));
        } 
        else {
            alert('Geocoder failed: ' + status);
        }
    });
}