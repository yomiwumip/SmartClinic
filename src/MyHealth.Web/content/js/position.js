var SmartClinic = SmartClinic || {};
SmartClinic.Pages = SmartClinic.Pages || {};
SmartClinic.Pages.Home = SmartClinic.Pages.Home || {};

SmartClinic.Pages.Home.Index = function () {
    'use strict';

    var mapElement = document.getElementById('mapDiv');

    var initMap = function (isInExtraSmallScreenWidth) {
        var pinLocation = new Microsoft.Maps.Location(SmartClinic.Config.companyLocation.Latitude, SmartClinic.Config.companyLocation.Longitude),
            latitudeDeviation;

        if (isInExtraSmallScreenWidth) {
            latitudeDeviation = 0.0020;
        } else {
            latitudeDeviation = -0.0050;
        }

        var centerLocation = new Microsoft.Maps.Location(SmartClinic.Config.companyLocation.Latitude + latitudeDeviation, SmartClinic.Config.companyLocation.Longitude);

        var mapOptions = {
                zoom: 15,
                center: centerLocation,
                showScalebar: false,
                enableSearchLogo: false,
                showMapTypeSelector: false,
                showDashboard: false,
                credentials: SmartClinic.Config.bingMapsKey
            },
            pinOptions = {
                icon: '',
                width: 50,
                height: 70
            },
            infoBoxOptions = {
                visible: true,
                offset: new Microsoft.Maps.Point(-100, 85),
                htmlContent: '<div class="map-infoBox"><h2>' + SmartClinic.Config.infoBoxCompanyAddress + '</h2><div class="map-infoBox-nav"><a href="">Indications</a><a href="">Save</a><a href="">Zoom</a><a href="">Send</a></div></div>'
            };

        var map = new Microsoft.Maps.Map(mapElement, mapOptions);
        var pin = new Microsoft.Maps.Pushpin(pinLocation, pinOptions);
        var pinInfoBox = new Microsoft.Maps.Infobox(pin.getLocation(), infoBoxOptions);

        // This hack avoids the map zoom when user scrolls into the page.
        Microsoft.Maps.Events.addHandler(map, 'mousewheel', function (e) {
            e.handled = true;
            return true;
        });

        Microsoft.Maps.Events.addHandler(map, 'dblclick', function (e) {
            e.handled = true;
            return true;
        });

        Microsoft.Maps.Events.addHandler(map, 'mousedown', function (mouseEvent) {
            mouseEvent.handled = true;
            return true;
        });

        map.entities.push(pin);
        map.entities.push(pinInfoBox);
    };

    var initialize = function () {
        if (mapElement) {
            initMap(true);
        }
    };

    return {
        initialize: initialize
    };
}();

SmartClinic.Pages.Home.Index.initialize();


