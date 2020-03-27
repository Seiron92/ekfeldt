var street = document.getElementById("street");
var postal = document.getElementById("postal");
var city = document.getElementById("city");


// GET LONGITUDE LATITUDE FROM ADRESS
function coordinates(list) {

    var latutudes = [];
    var longitudes = []
    for (var i = 0; i < list.length; i++) {


        longitudes.push(list[i].resources[0].point.coordinates[0])
        latutudes.push(list[i].resources[0].point.coordinates[1])
    }
    var longitude = longitudes;
    var latitude = latutudes;

    var address = document.getElementById('address').value;

    map = new Microsoft.Maps.Map(document.getElementById("myMap"), 
        {
            credentials: 'AgJc-CFgzRtz_dfIVjSLmkTBKDWcd3CNCZjJHJPOyiz4H77kh4bih7cA0FQKcVds',
            center: new Microsoft.Maps.Location(longitude, latitude),
          
            zoom: 15,
            showBreadcrumb: true,
            enableSearchLogo: false,
            enableClickableLogo: false,
            customizeOverlays: true 
        });

    var center = map.getCenter();

    //Create custom Pushpin
    var pin = new Microsoft.Maps.Pushpin(center, {
        title: address,
        // subTitle: locality,
        //text: 'Here',
        color: '#ee8a29'
    });

    //Add the pushpin to the map
    map.entities.push(pin);
  
}




/* SET ADDRESS */
function loadContent() {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var display = JSON.parse(this.response);
            coordinates(display.resourceSets);
        
        }
    };
   xhr.open('GET', 'https://dev.virtualearth.net/REST/v1/Locations/SE/' + city.value + '/' + postal.value + '/' + street.value + '?&key=AgJc-CFgzRtz_dfIVjSLmkTBKDWcd3CNCZjJHJPOyiz4H77kh4bih7cA0FQKcVds', true);
    xhr.send();
}
loadContent();

