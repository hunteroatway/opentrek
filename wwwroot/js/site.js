// define map variable to hold the mapboxgl map object
// provide initial zoom level and starting position (lat, lng)
var map = new mapboxgl.Map({
  container: 'map',
  attributionControl: false,
  style: 'https://tiles.locationiq.com/v3/streets/vector.json?key=' + config.location_iq_api_key,
  zoom: 1,
  center: [0, 25.0]
});

// create an element to hold the marker
var marker;
var marker_el = document.createElement('div');
marker_el.className = 'marker';
marker_el.style.backgroundImage = 'url(https://maps.locationiq.com/v3/samples/marker50px.png)';
marker_el.style.width = '50px';
marker_el.style.height = '50px';

// define a new mapboxgl marker object, set the position and add it to the map object
marker = new mapboxgl.Marker({
  element: marker_el,
  draggable: true
}).setLngLat([0, 25.0]).addTo(map);

function addMarker(e) {
  // define a new mapboxgl marker object, set the position and add it to the map object
  marker = new mapboxgl.Marker({
    element: marker_el,
    draggable: true
  }).setLngLat(e.lngLat.wrap()).addTo(map);

  // call api to get country of location that was clicked
  getCountryFromLatLng();
}

// function to call api to get country
function getCountryFromLatLng() {
  const req = new XMLHttpRequest();
  const url = 'https://us1.locationiq.com/v1/reverse.php?key=' + config.location_iq_api_key + '&lat=' + marker.getLngLat().lat + '&lon=' + marker.getLngLat().lng + '&format=json';

  // send http get request and parse json reponse to get the country
  req.onreadystatechange = function test() {
      if (this.readyState == 4 && this.status == 200) {
          var json = JSON.parse(this.responseText);
          console.log(json.address.country);
          $.post({
              type: 'GET',
              url: 'Map',
              data: ({
                  country: json.address.country
              }),
              success: function () {
                  window.location.href = 'https://localhost:5001/Map?country=' + json.address.country;
              }
          });
    }
  }  
  req.open("GET", url);
  req.send();
}

// setup event listeners for map and marker
map.on('click', addMarker);
marker.on('dragend', addMarker);