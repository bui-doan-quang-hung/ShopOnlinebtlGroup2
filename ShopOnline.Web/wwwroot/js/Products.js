mapboxgl.accessToken = 'pk.eyJ1IjoiaHVuZ2J1aSIsImEiOiJjbHVhaXNtaHQwa2h1MnRvZW94eHJpaWJuIn0.sbASKwqCPw-yXcM_cf7GAw';
var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [105.85, 21.0],
    zoom: 7.2
});
const marker = new mapboxgl.Marker({
    color: "#FFFFFF",
    draggable: true
}).setLngLat([105.85, 21.0])
    .addTo(map);
// Add zoom and rotation controls to the map.
map.addControl(new mapboxgl.NavigationControl({
    showCompass: true,
    showZoom: true,
}));
map.addControl(new mapboxgl.GeolocateControl({
    positionOptions: {
        enableHighAcuracy: true
    },
    trackUserLocation: true
}));
map.addControl(new mapboxgl.FullscreenControl());
var scale = new mapboxgl.ScaleControl({
    maxWidth: 80,
    unit: 'imperial'
})
map.addControl(scale);

map.on('dblclick', function (e) {
    new mapboxgl.Marker({
        color: 'orange',
        draggable: true,
    }).setLngLat([e.lngLat.lng, e.lngLat.lat]).addTo(map);
})
map.addControl(
    new MapboxDirections({
        accessToken: mapboxgl.accessToken
    }),
    'top-left'
);