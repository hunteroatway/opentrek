// define map variable to hold the mapboxgl map object
// provide initial zoom level and starting position (lat, lng)
var map = new mapboxgl.Map({
  container: 'map',
  attributionControl: false,
  style: 'https://tiles.locationiq.com/v3/streets/vector.json?key=' + config.location_iq_api_key,
  zoom: 8,
  center: [-122.42, 37.779]
});

// create an element to hold the marker
var marker_el = document.createElement('div');
marker_el.className = 'marker';
marker_el.style.backgroundImage = 'url(https://maps.locationiq.com/v3/samples/marker50px.png)';
marker_el.style.width = '50px';
marker_el.style.height = '50px';

// define a new mapboxgl marker object, set the position and add it to the map object
var marker = new mapboxgl.Marker({
  element: marker_el,
  draggable: true
}).setLngLat([0, 0]).addTo(map);

function updateMarkerPos(e) {
  // update position of marker on map to current event lat and lng values
  marker = new mapboxgl.Marker({
    element: marker_el,
    draggable: true
  }).setLngLat(e.lngLat.wrap()).addTo(map);

  getLatLng();
}

// get the lat and lng at the end of a drag event
function getLatLng() {
  // get the markers lat, lng coordinates and update the pre-defined dom object to display it to the user
  var lngLat = marker.getLngLat();
  coordinates.style.display = 'block';
  coordinates.innerHTML = 'Latitude: ' + lngLat.lat + '<br />Longitude: ' + lngLat.lng;
}

// setup event listeners for map and marker
map.on('click', updateMarkerPos);
marker.on('dragend', getLatLng);