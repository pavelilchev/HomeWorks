function attachEvents() {
    const appId = 'kid_BJ_Ke8hZg';
    const user = 'guest';
    const pass = 'pass';
    const baseUrl = 'https://baas.kinvey.com/';
    $('#getVenues').click(getVenuesID);

    let token;
    let loginHeaders;

    (function login() {
        let base64 = btoa(user + ':' + pass);
        let loginRequest = {
            method: 'POST',
            url: baseUrl + 'user/kid_BJ_Ke8hZg/login',
            headers: {
                'Authorization': 'Basic ' + base64,
                'Content-Type': 'application/json'
            },
            data: JSON.stringify({"username": "guest", "password": "pass"})
        };

        $.ajax(loginRequest).then(function (credential) {
            token = credential._kmd.authtoken;
            loginHeaders = {
                'Authorization': 'Kinvey ' + token,
                'Content-Type': 'application/json'
            }
        }).catch(displayError)
    })();

    function getVenuesID() {
        let date = $('#venueDate').val();
        $.ajax({
            method: 'POST',
            url: baseUrl + `rpc/kid_BJ_Ke8hZg/custom/calendar?query=${date}`,
            headers: loginHeaders
        }).then(getVenues).catch(displayError);
    }

    function getVenues(venusId) {
        let promises = [];
        for(let id of venusId){
            let promise = $.ajax({
                method : 'GET',
                url : baseUrl + `appdata/kid_BJ_Ke8hZg/venues/${id}`,
                headers : loginHeaders
            });

            promises.push(promise);
        }

        Promise.all(promises)
            .then(displayVenues)
            .catch(displayError);
    }

    function displayVenues(venues) {
        let wrapper = $('#venue-info');
        for(let venue of venues){
            let venueDiv = fillDiv(venue);

            venueDiv.find('.info').click(function () {
                venueDiv.find('.venue-details').toggle();
            });

            venueDiv.find('.purchase').click(function () {

                let purchase = fillPurchase(venue, venueDiv);
                $('#venue-info').html(purchase);

                purchase.find('input').click(function () {
                    let qty = venueDiv.find('.quantity').val();
                    $.ajax({
                        method : 'POST',
                        url : baseUrl + `rpc/kid_BJ_Ke8hZg/custom/purchase?venue=${venue._id}&qty=${qty}`,
                        headers : loginHeaders
                    }).then(function (data) {
                       $('#venue-info').html(data.html);
                    }).catch(displayError)
                });
            });
            wrapper.append(venueDiv);
        }
    }

    function fillPurchase(venue, venueDiv) {
        let qty = venueDiv.find('.quantity').val();
        let total = Number(qty) * Number(venue.price);

        return  $(
            `<span class="head">Confirm purchase</span>
             <div class="purchase-info">
              <span>${venue.name}</span>
              <span>${qty} x ${venue.price}</span>
              <span>Total: ${total} lv</span>
              <input type="button" value="Confirm">
            </div>`
        );
    }

    function fillDiv(venue) {
       return $(`<div class="venue" id="${venue._id}">
          <span class="venue-name"><input class="info" type="button" value="More info">${venue.name}</span>
          <div class="venue-details" style="display: none;">
            <table>
              <tr><th>Ticket Price</th><th>Quantity</th><th></th></tr>
              <tr>
                <td class="venue-price">${venue.price} lv</td>
                <td><select class="quantity">
                  <option value="1">1</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                  <option value="4">4</option>
                  <option value="5">5</option>
                </select></td>
                <td><input class="purchase" type="button" value="Purchase"></td>
              </tr>
            </table>
            <span class="head">Venue description:</span>
            <p class="description">${venue.description}</p>
            <p class="description">Starting time: ${venue.startingHour}</p>
          </div>
        </div>`);
    }

    function displayError(error) {
        console.dir(error);
    }
}