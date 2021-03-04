var map = new mapboxgl.Map({
  container: 'map',
  attributionControl: false,
  style: 'https://tiles.locationiq.com/v3/streets/vector.json?key=' + config.location_iq_api_key,
  zoom: 8,
  center: [-122.42, 37.779]
});