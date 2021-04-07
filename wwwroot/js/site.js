/* Map View */
/* **************************************************** */

// define map variable to hold the mapboxgl map object
// provide initial zoom level and starting position (lat, lng)
var map = new mapboxgl.Map({
  container: 'map',
  attributionControl: false,
  style: 'https://tiles.locationiq.com/v3/streets/vector.json?key=' + config.location_iq_api_key,
  zoom: 1,
  center: [0, 25.0]
});

// define map controls
var nav = new mapboxgl.NavigationControl();
map.addControl(nav, 'top-right');
map.addControl(new mapboxgl.FullscreenControl());
map.addControl(new mapboxgl.ScaleControl({
    maxWidth: 80,
    unit: 'metric'
}));
map.addControl(new mapboxgl.GeolocateControl({
    positionOptions: {
        enableHighAccuracy: true
    },
    trackUserLocation: true
}));

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
          // parse json reponse data from the api call
          var json = JSON.parse(this.responseText);

          // make a request to map controller to get the recommendation based on the country clicked on the map
          $.ajax({
              type: 'GET',
              url: 'Map/GetRecommendation',
              data: ({
                  country: json.address.country
              }),
              success: function (res) {
                  // on success of the map controller get call, update the country and recommendation DOM elements
                  $("#country-text").text(json.address.country);
                  $("#recommendation-text").text(res);
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

/* **************************************************** */

function validate(event) {
  var res = true;
  var email = document.getElementById("login-email").value;
  var pwd = document.getElementById("login-password").value;

  
  var email_v = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
  var pwd_v = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/;

  document.getElementById("login-email-msg").innerHTML = "";
  document.getElementById("login-password-msg").innerHTML = "";

  if (email == null || email == "" || !email_v.test(email)) {
    document.getElementById("login-email-msg").innerHTML = "Invalid Email Format";
    res = false;
  }

  if (pwd == null || pwd == "" || !pwd_v.test(pwd)) {
    document.getElementById("login-password-msg").innerHTML = "Invalid Password Format\n";
    res = false;
  }

  if (res == false)
    event.preventDefault();

    console.log(email);
    console.log(pwd);
    console.log(res);
}

