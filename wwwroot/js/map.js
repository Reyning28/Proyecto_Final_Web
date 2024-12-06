// wwwroot/js/map.js
let map;

window.getCurrentPosition = function () {
    return new Promise((resolve, reject) => {
        if (!navigator.geolocation) {
            reject('Geolocalización no soportada');
        }

        navigator.geolocation.getCurrentPosition(
            position => {
                resolve({
                    latitude: position.coords.latitude,
                    longitude: position.coords.longitude
                });
            },
            error => {
                reject(error);
            }
        );
    });
};

window.cleanupMap = function() {
    if (map) {
        // Remover el mapa existente
        map.remove();
        map = null;
    }
};

window.initializeMap = function (multas) {
    // Crear mapa centrado en República Dominicana
    map = L.map('map').setView([18.7357, -70.1627], 8);

    // Agregar capa de OpenStreetMap
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    // Agregar marcadores para cada multa
    multas.forEach(multa => {
        const marker = L.marker([multa.latitude, multa.longitude])
            .addTo(map)
            .bindPopup(`
                <strong>Multa</strong><br>
                Fecha: ${new Date(multa.createdAt).toLocaleDateString()}<br>
                Concepto: ${multa.concept}<br>
                Monto: RD$ ${multa.amount}
            `);
    });
}