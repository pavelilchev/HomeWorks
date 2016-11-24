function attachEvents() {
    $('#submit').click(getLocations);

    let baseUrl = 'https://judgetests.firebaseio.com/';

    function getLocations() {
        $.get(baseUrl + 'locations.json')
            .then(getCurrentLocationInfo)
            .catch(displayError)
    }

    function getCurrentLocationInfo(locations) {
        let searchedLocation = $('#location').val();
        let code;
        for (let location of locations) {
            if (location.name == searchedLocation) {
                code = location.code;
            }
        }

        if (!code) {
            return displayError();
        }

        let currentUrl = `${baseUrl}forecast/today/${code}.json`;
        let treeDayUrl = `${baseUrl}forecast/upcoming/${code}.json`;
        let currentConditionsRequest = $.get(currentUrl);
        let treeDaysRequest = $.get(treeDayUrl);

        Promise.all([currentConditionsRequest, treeDaysRequest])
            .then(displayWeather)
            .catch(displayError);
    }

    function displayWeather([currentCondition, treeDays]) {
        $('#forecast').show();

        let symbols = {
            'Sunny': '&#x2600',
            'Partly sunny': '&#x26C5',
            'Overcast': '&#x2601',
            'Rain': '&#x2614',
            'Degrees': '&#176'
        };

        let symbol = symbols[currentCondition.forecast.condition];


        $('#current').append($(`
<span class="condition symbol">${symbol}</span>
<span class="condition">
<span class="forecast-data">${currentCondition.name}</span>
<span class="forecast-data">${currentCondition.forecast.low+symbols.Degrees}/${currentCondition.forecast.high+symbols.Degrees}</span>
<span class="forecast-data">${currentCondition.forecast.condition}</span>
</span>
`));

        for (let day of treeDays.forecast) {
            $('#upcoming').append($(`
<span class="upcoming">
<span class="symbol">${symbols[day.condition]}</span>
<span class="forecast-data">${day.low+symbols.Degrees}/${day.high+symbols.Degrees}</span>
<span class="forecast-data">${day.condition}</span>
</span>
`));
        }

    }

    function displayError(error) {
        $('#forecast').text('Error').show();
    }
}